using System;
using System.Text;
using System.Collections.Generic;

namespace Cryptography.Chiphers {
public class BlockCipher {

    public string Decrypt(string text, byte[] keyBytes) {
        return Encrypt(text, keyBytes);
    }

    public string Encrypt(string text, byte[] keyBytes) {
            
        if (keyBytes.Length > 8) throw new ArgumentException("Key Can't Be Greater Than 64 Bits");

        int keyLength = keyBytes.Length;
        List<string> textBlocks = SplitText(text, keyLength);

        char[] encrypted = new char[text.Length];
            
        for (int i = 0; i < textBlocks.Count; i++) {
            for (int j = 0; j < keyLength; j++) {
                int index = i * keyLength + j;
                if (index < encrypted.Length) {
                    encrypted[index] = (char)(textBlocks[i][j] ^ keyBytes[j]);
                }
            }
        }

        return new String(encrypted);

    }

    public List<string> SplitText(string text, int blockSize) {
        StringBuilder result = new StringBuilder();
        List<string> splittedText = new List<string>();
        for (int i = 0; i < text.Length; i++) {
            if (result.Length == blockSize) {
                splittedText.Add(result.ToString()); 
                result.Clear();
            }
            result.Append(text[i]);
        }
        splittedText.Add(result.ToString());
        return splittedText;
    }
}
}
