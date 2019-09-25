using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography {
class SimpleColumnTransposition {
    char[][] matrix;
    int innerDimension;
    int[] sequence;
    public SimpleColumnTransposition(int dimension, params int[] sequence) {

        if (dimension != sequence.Length) throw new Exception("Number of columns must be equal to numbers in sequence");
        for (int i = 1; i <= dimension; i++) {
            if (!sequence.Contains(i)) throw new Exception("Sequnce must contain all the columns");
        }

        this.sequence = sequence;
        matrix = new char[dimension][];
        innerDimension = dimension;
    }
    public string Encrypt(string text, int rounds = 1) {
        text = text.Replace(" ", "");
        if (rounds == 0) return text;

        int outerDimension = (int)Math.Ceiling((double)text.Length / innerDimension);
        for (int x = 0; x < innerDimension; x++) {
            matrix[x] = new char[outerDimension];
		}

            

        int i = 0, j = 0, index = 0;
        while (index < text.Length) {
            matrix[i++][j] = text[index++];
            if (i == innerDimension) {
                i = 0; j++;
            }
        }

        StringBuilder result = new StringBuilder();
        for (i = 0; i < sequence.Length; i++) {
            for (j = 0; j < outerDimension; j++) {
                if (matrix[sequence[i] - 1][j] != '\0') {
                    result.Append(matrix[sequence[i] - 1][j]);
                }
            }
        }

        return Encrypt(result.ToString(), rounds - 1);
    }
}
}
