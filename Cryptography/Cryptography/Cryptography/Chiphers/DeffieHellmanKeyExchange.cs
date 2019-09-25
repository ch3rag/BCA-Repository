class DeffieHellmanKeyExchange {
        public void GenerateKeys(long n, long g, long x, out long y, out long a, out long b, out long k1, out long k2) {
            checked {
                a = (long)Math.Pow(g, x) % n;
                List<int> primes = Enumerable.Range(2, 20).Where(num => {
                    int factors = 0;
                    for (int i = 1; i <= x; i++) {
                        if (num % i == 0) factors++;
                    }
                    return factors <= 2;
                }).Select(num => num).ToList();
                Random rand = new Random();
                y = primes[rand.Next(primes.Count)];
                b = (long)Math.Pow(g, y) % n;
                k1 = (long)Math.Pow(b, x) % n;
                k2 = (long)Math.Pow(a, y) % n;
            }
        }
    }
}