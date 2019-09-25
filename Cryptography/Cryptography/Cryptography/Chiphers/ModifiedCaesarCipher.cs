using System;
using System.Text;
using System.Collections.Generic;
using Cryptography.Util;

namespace Cryptography {
    class ModifiedCaesarCipher {
        public List<string> GenerateStrings(string key) {
            key = key.ToUpper();
            List<string> sequences = new List<string>();
            StringBuilder result = new StringBuilder();
            for (int x = 0; x < 26; x++) {
                for (int i = 0; i < key.Length; i++) {
                    if (key[i] == ' ') result.Append(' ');
                    else result.Append(CharUtil.NextChar(key[i]));
                }
                string sequence = result.ToString();
                sequences.Add(sequence);
                key = sequence;
                result.Clear();
            }
            return sequences;
        }
    }
}
