using System;
using System.Collections.Generic;
using Cryptography.Util;
using Cryptography.KeyGeneration;
using Cryptography.Chiphers;

namespace Cryptography {
    class Program {
        static void Main(string[] args) {
            // RunBlockCipher();
            RunHillCipher();
        }

        public static void RunBlockCipher() {
            Console.WriteLine("Block Cipher\n\n");
            string text = "FOUR_AS_FOUR";
            byte[] key = { 1, 4, 9 };
            Console.Write("Key: ");
            for (int i = 0; i < key.Length; i++) {
                Console.Write(key[i] + " ");
            }
            Console.WriteLine();
            BlockCipher algo = new BlockCipher();
            string encrypted = algo.Encrypt(text, key);
            string decrypted = algo.Encrypt(encrypted, key);
            Console.WriteLine("Text: {0}", text);
            Console.WriteLine("Encrypted: {0}", encrypted);
            Console.WriteLine("Decrypted: {0}", decrypted);
        }


        public static void RunStreamCipher() {
            Console.WriteLine("Stream Cipher\n\n");
            string text = "PAY100";
            byte key = 12;
            StreamCipher algo = new StreamCipher();
            string encrypted = algo.Encrypt(text, key);
            string decrypted = algo.Encrypt(encrypted, key);
            Console.WriteLine("Text: {0}", text);
            Console.WriteLine("Key: {0}", key);
            Console.WriteLine("Encrypted: {0}", encrypted);
            Console.WriteLine("Decrypted: {0}", decrypted);
        }

        public static void RunDeffieHellmanKeyExchange() {
            Console.WriteLine("Deffie Hellman Key Exchange\n\n");
            int n = 11;
            int g = 7;
            int x = 3;
            int y, a, b, k1, k2;
            DeffieHellmanKeyExchange algo = new DeffieHellmanKeyExchange();
            algo.GenerateKeys(n, g, x, out y, out a, out b, out k1, out k2);
            Console.WriteLine("N: {0}, G: {1}\nX: {2}, Y: {3}\nA: {4}, B: {5}\nK1: {6}, K2: {7}", n, g, x, y, a, b, k1, k2);
        }

        public static void RunHillCipher() {

            Console.WriteLine("Hill Cipher\n\n");
            int[,] key = {{  2, 9, 8  },
                          { 2, 0, 1 },
                          { 9, 1, 2 }};


            string text = "CAT";
            Console.WriteLine("Key Matrix:\n");
            for (int i = 0; i < key.GetLength(0); i++) {
                for (int j = 0; j < key.GetLength(1); j++) {
                    Console.Write(key[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            HillCipher algo = new HillCipher();

            string encrypted = algo.Encrypt(text, key);
            string decrypted = algo.Decrypt(encrypted, key);
            Console.WriteLine("Text: {0}", text);
            Console.WriteLine("Encrypted: {0}", encrypted);
            Console.WriteLine("Decrypted: {0}", decrypted);
        }

        public static void RunModifiedCaesarCipher() {
            string text = "KWUM PMZM";
            ModifiedCaesarCipher algo = new ModifiedCaesarCipher();
            List<string> sequences = algo.GenerateStrings(text);
            for (int i = 0; i < sequences.Count; i++) {
                Console.WriteLine("{0}\t{1}", i + 1, sequences[i]);
            }
        }

        public static void RunCaesarCipher() {
            string text = "CHIRAG SINGH RAJPUT";
            int offset = 5;
            CaesarChiper algo = new CaesarChiper();
            string encrypted = algo.Encrypt(text, offset);
            string decrypted = algo.Decrypt(encrypted, offset);
            Console.WriteLine("Text: {0}", text);
            Console.WriteLine("Key: {0}", offset);
            Console.WriteLine("Encrypted: {0}", encrypted);
            Console.WriteLine("Decrypted: {0}", decrypted);
        }

        public static void RunSimpleColumnTransposition() {
            Console.WriteLine("Simple Column Transposition w/ Multiple Rounds\n\n");
            string text = "COME HOME TOMORROW";
            int[] sequence = { 1, 5, 3, 4, 6, 2 };
            SimpleColumnTransposition algo = new SimpleColumnTransposition(6, sequence);
            Console.WriteLine("Text: {0}", text);
            Console.WriteLine("Number Of Columns: {0}", 6);
            Console.Write("Sequence: ");
            for (int i = 0; i < sequence.Length; i++) {
                Console.Write(sequence[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("One Round : {0}", algo.Encrypt(text, 1));
            Console.WriteLine("Two Rounds: {0}", algo.Encrypt(text, 2));
            Console.WriteLine("Three Rounds: {0}", algo.Encrypt(text, 3));
        }

        public static void RunVernam() {
            Console.WriteLine("Vernam Cipher\n\n");
            string text = "HOW ARE YOU";
            string oneTimePad = "NC BTZQ ARX";
            VernamCipher algo = new VernamCipher(); 
            string encrypted = algo.Encrypt(text, oneTimePad);
            string decrypted = algo.Decrypt(encrypted, oneTimePad);
            Console.WriteLine("Text: {0}", text);
            Console.WriteLine("One Time Pad: {0}", oneTimePad);
            Console.WriteLine("Encrypted: {0}", encrypted);
            Console.WriteLine("Decrypted: {0}", decrypted);
        }

        public static void RunRailFence() {
            Console.WriteLine("Rail Fence\n\n");
            RailFence algo = new RailFence();
            string text = "COME HOME TOMORROW";
            string encrypted = algo.Encrypt(text);
            string decrypted = algo.Decrypt(encrypted);
            Console.WriteLine("Text: {0}", text);
            Console.WriteLine("Encrypted: {0}", encrypted);
            Console.WriteLine("Decrypted: {0}", decrypted);
        }

        public static void RunPlayfair() {
            PlayFair algo = new PlayFair("HARSH");
            string text = "MY NAME IS JUI KAHATE I AM HARSHUHS SISTER";
            Console.WriteLine("Key: {0}", algo.Key);
            Console.WriteLine("Text: {0}", text);

            Console.WriteLine("Matrix: ");
            Console.WriteLine();
            for (int i = 0; i < 5; i++) {
                for (int j = 0; j < 5; j++) {
                    Console.Write(" {0} ", algo.Matrix[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.Write("Splitting: ");

            foreach (string pair in algo.SplitText(text)) {
                Console.Write(pair + " ");
            }

            Console.WriteLine();
            Console.WriteLine("Encrypted: {0}", algo.Encrypt(text));
        }
    }
}
