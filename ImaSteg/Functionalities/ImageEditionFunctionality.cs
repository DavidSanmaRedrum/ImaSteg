using ImaSteg.Controllers;
using ImaSteg.Utils;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace ImaSteg.Functionalities {
    class ImageEditionFunctionality {

        public static bool CheckImageSize(int area) {
            int commandsLength = (Constants.CONTROL_COMMAND.Length + Constants.INITIAL_COMMAND.Length) * 2;
            return area - commandsLength >= Constants.MIN_TEXT_LENGTH;
        }

        public static void WriteTextInsideImage(Bitmap bitmap, string message) {
            int letterCounter = 0;
            int y = 0;
            int xAux, yAux;
            for (int x = 0; x < bitmap.Width; x += 2) { // Se hace así, porque la Y va de 1 en 1 y la X de 2 en 2
                if (ISBreakThreadController.Listen()) return; // Si se ha parado devuelve sale del método.
                int secondaryValue = x + 1;
                if (y < bitmap.Height) {
                    xAux = x;
                    yAux = y;
                    Color firstPixel = bitmap.GetPixel(x, y);
                    if (secondaryValue == bitmap.Width) { // Si el valor secundario es igual al ancho es impar
                        secondaryValue = 0; // El valor secundario se deja a cero
                        x = -1; //Se pone a -1 la x para que cuando itere de nuevo al pegar un salto de 2 vaya a parar a la segunda posición (1).
                        y++; // Se avanza una fila
                        if (y == bitmap.Height) break;
                    } else if (secondaryValue == bitmap.Width - 1) { // PAR
                        x = -2; // Se pone a -2 para que cuando vuelva a iterar lo ponga a 0.
                        if (y == bitmap.Height - 1 && x == bitmap.Width - 2) break;
                    }
                    Color secondPixel = bitmap.GetPixel(secondaryValue, y);
                    if (letterCounter < message.Length) {
                        string binaryValue = BinaryFunctionality.DecimalToBits8(message[letterCounter]);
                        SetModifiedColor(bitmap, firstPixel.ToString(), binaryValue.Substring(0, 4), xAux, yAux);
                        SetModifiedColor(bitmap, secondPixel.ToString(), binaryValue.Substring(4), secondaryValue, y);
                        if (secondaryValue == bitmap.Width - 1) y++;
                    } else {
                        x = bitmap.Width;
                    }
                    letterCounter++;
                }
            }
        }

        public static string ReadTextInsideImage(Bitmap bitmap) {
            string text = "";
            string initialCommand = Constants.INITIAL_COMMAND;
            string controlCommand = Constants.CONTROL_COMMAND;
            string binaryValue;
            int decimalValueFirstLetter, decimalValueSecondLetter;

            // Se usa LockBits para hacerlo más eficiente, investigarlo mejor.
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            int byteCount = bitmapData.Stride * bitmap.Height; // Esto da la longitud de bytes equivalente a el área * 4 canales de color argb. 
            byte[] bgraBytes = new byte[byteCount];
            //El array que obtengo con el Marshal es el de los bytes de los colores ordenados.
            Marshal.Copy(bitmapData.Scan0, bgraBytes, 0, byteCount);
            bitmap.UnlockBits(bitmapData);

            for (int i = 0; i < bgraBytes.Length; i += Constants.MAX_READ_STEP) {
                if (ISBreakThreadController.Listen()) return ""; // Si se ha parado devuelve sale del método.
                Color firstPixelFirstLetter = Color.FromArgb(bgraBytes[i + 3], bgraBytes[i + 2], bgraBytes[i + 1], bgraBytes[i]); // BGRA (GDI+)
                Color secondPixelFirstLetter = Color.FromArgb(bgraBytes[i + 7], bgraBytes[i + 6], bgraBytes[i + 5], bgraBytes[i + 4]);

                Color firstPixelSecondLetter = Color.FromArgb(bgraBytes[i + 11], bgraBytes[i + 10], bgraBytes[i + 9], bgraBytes[i + 8]);
                Color secondPixelSecondLetter = Color.FromArgb(bgraBytes[i + 15], bgraBytes[i + 14], bgraBytes[i + 13], bgraBytes[i + 12]);

                binaryValue = BinaryFunctionality.TwoLettersWithPixelsToBinary(firstPixelFirstLetter, secondPixelFirstLetter, firstPixelSecondLetter, secondPixelSecondLetter);

                int letterByteLength = binaryValue.Length / 2; // Siempre 4.

                decimalValueFirstLetter = BinaryFunctionality.Bits8ToDecimal(binaryValue.Substring(0, letterByteLength));
                decimalValueSecondLetter = BinaryFunctionality.Bits8ToDecimal(binaryValue.Substring(letterByteLength, letterByteLength));

                if (decimalValueFirstLetter != -1 && decimalValueSecondLetter != -1) {
                    text += (char)decimalValueFirstLetter + "" + (char)decimalValueSecondLetter;
                    if (!text.Contains(initialCommand) && text.Length >= initialCommand.Length) {
                        i = bgraBytes.Length;
                        text = Constants.VOID_INFORMATION;
                    } else if (text.Contains(controlCommand)) {
                        i = bgraBytes.Length;
                        // Si contiene el comando de control pero no termina con el comando de control,
                        // significa que al hacerse dos letras por iteración no es múltiplo de 16 y entonces se
                        // debe restar la última letra.
                        if (!text.EndsWith(controlCommand)) text = text.Substring(0, text.Length - 1);
                    }
                }           
            }
            return text;
        }

        private static void SetModifiedColor(Bitmap bitmap, string pixel, string binaryValue, int x, int y) {
            MatchCollection pixelParams = Regex.Matches(pixel.ToString(), Constants.ONLY_NUMBERS_REGEX);
            int binaryIndex = -1;
            Color color = Color.Empty;
            foreach (Match match in pixelParams) {
                binaryIndex++;
                int binValue = Convert.ToInt32(binaryValue[binaryIndex] + "");
                
                int colorValue = Convert.ToInt32(match.Value);
                if ((binValue % 2 == 0 && colorValue % 2 != 0) || (binValue % 2 != 0 && colorValue % 2 == 0)) { // Pares e impares
                    if (colorValue < Constants.MAX_LIMIT_BYTE) {
                        colorValue++;
                    } else {
                        colorValue--;
                    }
                }

                byte alphaColor;
                byte redColor;
                byte greenColor;
                switch (binaryIndex) {
                    case 0:
                        color = Color.FromArgb(colorValue, 0, 0, 0);
                        break;
                    case 1:
                        alphaColor = color.A;
                        color = Color.FromArgb(alphaColor, colorValue, 0, 0);
                        break;
                    case 2:
                        alphaColor = color.A;
                        redColor = color.R;
                        color = Color.FromArgb(alphaColor, redColor, colorValue, 0);
                        break;
                    case 3:
                        alphaColor = color.A;
                        redColor = color.R;
                        greenColor = color.G;
                        color = Color.FromArgb(alphaColor, redColor, greenColor, colorValue);
                        break;
                }
            }
            bitmap.SetPixel(x, y, color);
        }
    }
}
