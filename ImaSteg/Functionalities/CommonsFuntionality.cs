
using ImaSteg.Utils;

namespace ImaSteg.Functionalities {
    class CommonsFuntionality {

        public static bool HasNotAsciiCharacters(string msg) {
            for (int i = 0; i < msg.Length; i++) {
                if (((int)msg[i]) > Constants.MAX_LIMIT_BYTE) return true;
            }
            return false;
        }

    }
}
