using ImaSteg.Controllers;
using ImaSteg.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ImaSteg.Functionalities {
    class EncryptDecryptFunctionality {

        public static string GetPreparedMessage(bool mode, string message, string password) {
            int byteLimitMax = Constants.MAX_LIMIT_BYTE + 1;
            int passwordChar = 0;
            int messageEnd;
            string output = "";

            if (mode) {
                message = TokenCipher(message, true);
                if (message.Length == 0) return "";
                messageEnd = message.Length;
            } else {
                messageEnd = message.IndexOf(Constants.CONTROL_COMMAND); // Posición inicial del final.
            }

            for (int msgChar = Constants.INITIAL_COMMAND.Length; msgChar < messageEnd; msgChar++) {
                if (ISBreakThreadController.Listen()) return ""; // Si se ha parado devuelve sale del método.
                if (passwordChar > password.Length - 1) passwordChar = 0; // Si se termina la contraseña empezamos por el principio.
                if (mode) {
                    int preparedValue = (int)message[msgChar] + (int)password[passwordChar]; // Se suma el parámetro del pixel al valor del byte del fichero.
                    if (preparedValue > Constants.MAX_LIMIT_BYTE) { // Si entra, debe ser mayor a 255
                                                                    // Se resta el máximo de bytes posibles (256) para reducirlo a un valor aceptable en función del pixelParam.
                        preparedValue -= byteLimitMax;
                    }
                    output += (char)preparedValue;
                } else {
                    int preparedValue = (int)message[msgChar] - (int)password[passwordChar];
                    if (preparedValue < 0) {
                        preparedValue += byteLimitMax;
                    }
                    output += (char)preparedValue;
                }
                passwordChar++;
            }

            if (!mode) {
                output = TokenCipher(output, false);
                if (output.Length == 0) return "";
            } else {
                output = Constants.INITIAL_COMMAND + output + Constants.CONTROL_COMMAND;
            }

            return output;
        }


        public static string TokenCipher(string message, bool mode) {
            string token = ImaStegController.GetToken();
            string tokenCharacters = Constants.TOKEN_CHARACTERS;
            int length = tokenCharacters.Length;
            
            Dictionary<char, char> associationTokenCharsEncrypt = new Dictionary<char, char>();
            Dictionary<char, char> associationTokenCharsDecrypt = new Dictionary<char, char>();

            char[] messageArray = message.ToCharArray();

            for (int i = 0; i < length; i++) {
                if (ISBreakThreadController.Listen()) return "";
                if (mode) {
                    associationTokenCharsEncrypt.Add(tokenCharacters[i], token[i]);
                } else {
                    associationTokenCharsDecrypt.Add(token[i], tokenCharacters[i]);
                }
            }

            for (int j = 0; j < messageArray.Length; j++) {
                if (ISBreakThreadController.Listen()) return "";
                try {
                    if (mode) {
                        messageArray[j] = associationTokenCharsEncrypt[messageArray[j]];
                    } else {
                        messageArray[j] = associationTokenCharsDecrypt[messageArray[j]];
                    }
                } catch (Exception) {
                    // Por si hay algún char en el mensaje que no lo tiene la constante de chars definida, en ese caso
                    // entrará dentro del catch e ignorará dicho char en esta parte del proceso y solo será cifrado en
                    // la sustitución principal.
                    //Console.WriteLine(e.ToString() + "INDEX: " + j);
                    continue;
                }
            }
            return new string(messageArray);
        }

        public static string CreateToken() {
            Random random = new Random();
            HashSet<char> token = new HashSet<char>();
            string tokenChars = Constants.TOKEN_CHARACTERS;
            int tokenLength = tokenChars.Length;

            while (token.Count < tokenLength) {
                token.Add(tokenChars[random.Next(0, tokenLength)]);
            }

            return new string(token.ToArray());
        }

        public static bool CheckToken(string token) {
            for (int i = 0; i < token.Length; i++) {
                if (!Constants.TOKEN_CHARACTERS.Contains(token[i].ToString())) return false;
                for (int j = i + 1; j < token.Length; j++) {
                    if (token[i] == token[j]) {
                        return false;
                    }
                }
            }
            return true;
        }

    }
}
