using System;
using System.Collections.Generic;
using System.Text;
using Cryptography.Util;

namespace Cryptography {
class VernamCipher {
    public string Encrypt(string text, string oneTimePad) {
            
        text = text.ToUpper().Replace(" ", "");
        oneTimePad = oneTimePad.ToUpper().Replace(" ", "");
        if (text.Length != oneTimePad.Length) return "";

        StringBuilder result = new StringBuilder();

        for (int i = 0; i < text.Length; i++) {
            int sum = CharUtil.GetAlphaPosition(text[i]) + CharUtil.GetAlphaPosition(oneTimePad[i]);
            char c = CharUtil.GetAlphaFromPosition(sum);
            result.Append(c);

		}
        return result.ToString();
    }

    public string Decrypt(string text, string oneTimePad) {
        text = text.ToUpper().Replace(" ", "");
        oneTimePad = oneTimePad.ToUpper().Replace(" ", "");
        if (text.Length != oneTimePad.Length) return "";

        StringBuilder result = new StringBuilder();
        for (int i = 0; i < text.Length; i++) {
            int sum = CharUtil.GetAlphaPosition(text[i]) - CharUtil.GetAlphaPosition(oneTimePad[i]);
            char c = CharUtil.GetAlphaFromPosition(sum);
            result.Append(c);

        }
        return result.ToString();
    }
}
}
