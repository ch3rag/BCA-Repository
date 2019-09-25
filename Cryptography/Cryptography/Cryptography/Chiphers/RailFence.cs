using System;
using System.Text;

namespace Cryptography {
class RailFence {
    public string Encrypt(string text) {
        StringBuilder left = new StringBuilder();
        StringBuilder right = new StringBuilder();
        for (int i = 0; i < text.Length; i++) {
            if (i % 2 == 0) {
                left.Append(text[i]);
            } else {
                right.Append(text[i]);
            }
        }
        return left.Append(right.ToString()).ToString();
    }

    public string Decrypt(string text) {
        StringBuilder result = new StringBuilder();
        int offset = (text.Length % 2 == 0) ? 0 : 1;
        int max = text.Length / 2;
        for (int i = 0; i < max; i++) {
            result.Append(text[i]).Append(text[max + i + offset]);
        }
        if (offset > 0) result.Append(text[max + 1]);
        return result.ToString();
    }
}
}
