using ImaSteg.Utils;
using System;
using System.Drawing;
using System.Text.RegularExpressions;

namespace ImaSteg.Functionalities {
    class BinaryFunctionality {

        public static string TwoLettersWithPixelsToBinary(Color firstPixel, Color secondPixel, Color thirdPixel, Color fourthPixel) {
            MatchCollection[] matchCollections = new MatchCollection[4];
            matchCollections[0] = Regex.Matches(firstPixel.ToString(), Constants.ONLY_NUMBERS_REGEX);
            matchCollections[1] = Regex.Matches(secondPixel.ToString(), Constants.ONLY_NUMBERS_REGEX);
            matchCollections[2] = Regex.Matches(thirdPixel.ToString(), Constants.ONLY_NUMBERS_REGEX);
            matchCollections[3] = Regex.Matches(fourthPixel.ToString(), Constants.ONLY_NUMBERS_REGEX);

            string binaryValue = "";
            for (int i = 0; i < matchCollections.Length; i++) {
                foreach (Match match in matchCollections[i]) {
                    if (Convert.ToInt32(match.Value) % 2 == 0) {
                        binaryValue += '0';
                    } else {
                        binaryValue += '1';
                    }
                }
            }
            return binaryValue;
        }

        public static string DecimalToBits8(int decimalValue) {
            if (decimalValue > Constants.MAX_LIMIT_BYTE) return "-1";
            if (decimalValue == 0) return "00000000";
            string output = "";
            while (decimalValue > 0) {
                int dividend = decimalValue / 2;
                decimalValue %= 2;                
                output = decimalValue.ToString() + output;
                decimalValue = dividend;
            }
            int nBits = Constants.N_BITS;
            int difference = nBits - output.Length;
            if (difference < nBits && difference >= 0) {
                for (int i = 0; i < difference; i++) {
                    output = '0' + output;
                }
            }
            return output;
        }

        public static int Bits8ToDecimal(string bits8Value) {
            if (bits8Value.Length > Constants.N_BITS) return -1;
            int output = 0;
            int bits8ValuePos = bits8Value.Length - 1;
            for (int i = 0; i < bits8Value.Length; i ++) {
                //string binaryPartNumber = bits8Value[bits8ValuePos] + "";
                //output += Convert.ToInt32(binaryPartNumber) * Convert.ToInt32(Math.Pow(2, i));
                int bit = bits8Value[bits8ValuePos] - '0'; // Convertir char a int eficientemente
                output += bit << i; // Usar desplazamiento en lugar de Math.Pow()
                bits8ValuePos--;
            }
            return output;
        }

    }
}
