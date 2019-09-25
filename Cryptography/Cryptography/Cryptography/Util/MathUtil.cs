using System;

namespace Cryptography.Util {
    public static class MathUtil {
        public static bool IsPrime(int x) {
            if (x <= 1) return false;
            if (x == 2) return true;
            if (x % 2 == 0) return false;
            for (int i = 3, max = (int)Math.Floor(Math.Sqrt(x)) + 1; i < max; i += 2) {
                if (x % i == 0) return false; 
            }
            return true;
        }
    }
}
