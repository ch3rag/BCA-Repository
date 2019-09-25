using System;
using Cryptography.Util;
using System.Text;

namespace Cryptography {
class HillCipher {
    public string Encrypt(string text, int[,] key) {
        if ((key.GetLength(0) != key.GetLength(1)) || text.Length != key.GetLength(0)) {
            throw new ArgumentException("Matrix should of size NxN where N is length of the text to be encrypted");
        }

        int[,] textMat = new int[text.Length, 1];

        for (int i = 0; i < text.Length; i++) {
            textMat[i,0] = CharUtil.GetAlphaPosition(text[i]);
        }

        int[,] mult = MatrixUtil.Mult(key, textMat);
        mult = MatrixUtil.Map(mult, x => x % 26);

        StringBuilder result = new StringBuilder();

        for (int i = 0; i < text.Length; i++) {
            result.Append(CharUtil.GetAlphaFromPosition(mult[i, 0]));
        }
        return result.ToString();
    }

    public string Decrypt(string text, int[,] key) {

        int determinant  =  MatrixUtil.Determinant(key);
        determinant = determinant < 0? 26 - (Math.Abs(determinant) % 26) : determinant % 26;

        int inverseDeterminant = 0;
        for (int i = 1; i < 26; i++) {
            if ((i * determinant) % 26 == 1) {
                inverseDeterminant = i;
                break;
            }
        }

        key = MatrixUtil.Adjugate(key);
        key = MatrixUtil.Map(key, x => x < 0 ? 26 - (Math.Abs(x) % 26) : x % 26);
        key = MatrixUtil.Map(key, x => x * inverseDeterminant);
        key = MatrixUtil.Map(key, x => x % 26);
            Console.WriteLine("Inverse ==> ");
            MatrixUtil.PrintMatrix(key);
            Console.WriteLine();
        int[,] textMat = new int[text.Length, 1];

        for (int i = 0; i < text.Length; i++) {
            textMat[i, 0] = CharUtil.GetAlphaPosition(text[i]);
        }

        StringBuilder result = new StringBuilder();

        int[,] mult = MatrixUtil.Mult(key, textMat);
        mult = MatrixUtil.Map(mult, x => x % 26);

        for (int i = 0; i < text.Length; i++) {
            result.Append(CharUtil.GetAlphaFromPosition(mult[i, 0]));
        }

        return result.ToString();

    }
}
}
