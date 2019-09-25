using System;
using Cryptography.Util;
using System.Linq;

namespace Cryptography.KeyGeneration {
public class DeffieHellmanKeyExchange {
    public void GenerateKeys(int n, int g, int x, out int y, out int a, out int b, out int k1, out int k2) {
        y = Enumerable.Range(2, 10)
                .Where(num => MathUtil
                .IsPrime(num))
                .Select(num => num)
                .ToList()
                .Random();

        a = (int)Math.Pow(g, x) % n;
        b = (int)Math.Pow(g, y) % n;
        k1 = (int)Math.Pow(b, x) % n;
        k2 = (int)Math.Pow(a, y) % n;
    }
}
}
