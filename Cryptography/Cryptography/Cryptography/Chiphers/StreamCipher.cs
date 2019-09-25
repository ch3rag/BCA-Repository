using System;
using System.Text;

namespace Cryptography.Chiphers {
public class StreamCipher {
    public string Encrypt(string text, byte key) {
        char[] result = new char[text.Length];
        for (int i = 0; i < text.Length; i++) {
            result[i] = (char)(text[i] ^ key);
        }

        return new String(result);
    }

    public string Decrypt(string text, byte key) {
        return Encrypt(text, key);
    }
}
}
