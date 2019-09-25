using System;
using System.Linq;
using System.Collections.Generic;
using Cryptography.Util;
using System.Text;

namespace Cryptography {

    class PlayFair {

        string key;
        char[,] matrix = new char[5, 5];

        public string Key { get { return key; } }
        public char[,] Matrix { get { return matrix; } }
        
        public PlayFair(string key) {
            this.key = key.ToUpper().Replace(" ", "");
            string queryString;
         
            if (this.Key.Contains('J') && this.Key.Contains('I')) {
                queryString = this.Key.Replace('J', 'I') + "ABCDEFGHKLMNOPQRSTUVWXYZ";
            } else if (this.Key.Contains('J')) {
                queryString = this.Key.Replace("J", "") + "ABCDEFGHIKLMNOPQRSTUVWXYZ";
            } else {
                queryString = this.Key + "ABCDEFGHIKLMNOPQRSTUVWXYZ";
            }
            
            List<char> characters = queryString.Select(character => character).Distinct().ToList();

            for (int i = 0; i < 5; i++) {
                for (int j = 0; j < 5; j++) {
                    matrix[i, j] = characters[i * 5 + j];
                }
            }
        }

        public string Encrypt(string word) {
            List<string> words = SplitText(word);
            StringBuilder result = new StringBuilder();
            foreach (string pair in words) {
                var c1 = MatrixUtil.GetIndex<char>(pair[0], matrix);
                var c2 = MatrixUtil.GetIndex<char>(pair[1], matrix);
                if (c1.Item1 == c2.Item1) {             // SAME ROW
                    result.Append(matrix[c1.Item1, (c1.Item2 + 1) % 5]);
                    result.Append(matrix[c2.Item1, (c2.Item2 + 1) % 5]);
                } else if (c1.Item2 == c2.Item2) {      // SAME COLUMN
                    result.Append(matrix[(c1.Item1 + 1) % 5, c1.Item2]);
                    result.Append(matrix[(c2.Item1 + 1) % 5, c2.Item2]);
                } else {                                // DIAGONAL
                    result.Append(matrix[c1.Item1, c2.Item2]);
                    result.Append(matrix[c2.Item1, c1.Item2]);
                }
                result.Append(" ");
            }
            return result.ToString();
        }

        public List<string> SplitText(string word) {
            word = word.ToUpper().Replace(" ", "").Replace('J', 'I');
            List<string> splittedText = new List<string>();
            StringBuilder temp = new StringBuilder();
            for (int i = 0; i < word.Length; i++) {
                if (temp.Length == 2) {
                    if ((i - 3) > 0 && word[i - 3] == temp[0]) {
                        temp[1] = temp[0]; temp[0] = 'X'; 
                        i--;
                    } else if (temp[0] == temp[1]) {
                        temp[1] = 'X';
                        i--;
                    }
                    splittedText.Add(temp.ToString());
                    temp.Clear();
                }
                temp.Append(word[i]);
            }

            if (temp.Length >= 1) {
                temp.Append('X');
                splittedText.Add(temp.ToString());
            }
            return splittedText;
        }
    }
}
