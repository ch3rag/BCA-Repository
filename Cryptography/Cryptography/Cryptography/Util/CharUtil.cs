using System;

namespace Cryptography.Util {
    public static class CharUtil {
        public static int GetAlphaPosition(char c) {
            if (c >= 97 && c <= 122) return c - 97;
            else if (c >= 65 && c <= 90) return c - 65;
            else return -1;
        }

        public static char GetAlphaFromPosition(int pos) {
            if (pos > 25) return (char)((pos % 26) + 65);
            else if (pos < 0) return (char)(((pos + 26) % 26) + 65);
            else return (char)(pos + 65);
        }

        public static char NextChar(char c) {
            if (c == 'Z') return 'A';
            else if (c == 'z') return 'a';
            else return (char)(c + 1);
        }
    }

}
