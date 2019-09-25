using System;
using System.Text;
using Cryptography.Util;

namespace Cryptography {
    class CaesarChiper {
        public string Encrypt(string text, int offset) {
            text = text.ToUpper().Replace(" ", "");
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < text.Length; i++) {
                int absolute = CharUtil.GetAlphaPosition(text[i]);
                int sum = absolute + offset;
                result.Append(CharUtil.GetAlphaFromPosition(sum));
            }
            return result.ToString();
        }

        public string Decrypt(string text, int offset) {
            text = text.ToUpper().Replace(" ", "");
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < text.Length; i++) {
                int absolute = CharUtil.GetAlphaPosition(text[i]);
                int diff = absolute - offset;
                result.Append(CharUtil.GetAlphaFromPosition(diff));
            }
            return result.ToString();
        }
    }
}
