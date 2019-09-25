using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Lib {
    public static class MatrixUtil {
        public static Tuple<int, int> GetIndex<T>(T c, T[,] matrix) {
            for (int i = 0; i < matrix.GetLength(0); i++) {
                for (int j = 0; j < matrix.GetLength(1); j++) {
                    if (matrix[i, j].Equals(c)) {
                        return Tuple.Create<int, int>(i, j);
                    }
                }
            }
            return Tuple.Create<int, int>(-1, -1);
        }

        public static void PrintMatrix<T>(T[,] matrix) {
            for (int i = 0; i < matrix.GetLength(0); i++) {
                for (int j = 0; j < matrix.GetLength(1); j++) {
                    if (matrix[i, j].Equals(double.MaxValue)) Console.Write("INF\t");
                    else Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public static T[,] Clone<T>(T[,] matrix) {
            T[,] copy = new T[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++) {
                for (int j = 0; j < matrix.GetLength(1); j++) {
                    copy[i, j] = matrix[i, j];
                }
            }
            return copy;
        }

        public static T[,] Mult<T>(T[,] m1, T[,] m2) {

            int r1 = m1.GetLength(0), r2 = m2.GetLength(0);
            int c1 = m1.GetLength(1), c2 = m2.GetLength(1);

            if (c1 != r2) {
                throw new ArgumentException("Columns of the first matrix must be equal to the rows of second matrix");
            }

            T[,] result = new T[r1, c2];

            for (int i = 0; i < r1; i++) {
                for (int j = 0; j < c2; j++) {
                    T sum = default(T);
                    for (int k = 0; k < c1; k++) {
                        sum += (dynamic)m1[i, k] * m2[k, j];
                    }
                    result[i, j] = sum;
                }
            }
            return result;
        }

        public static T[,] Map<T>(T[,] matrix, Func<T, T> func) {
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
            T[,] output = new T[rows, cols];
            for (int i = 0; i < matrix.GetLength(0); i++) {
                for (int j = 0; j < matrix.GetLength(1); j++) {
                    output[i, j] = func(matrix[i, j]);
                }
            }
            return output;
        }

        public static T[,] Transpose<T>(T[,] matrix) {
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
            T[,] transpose = new T[rows, cols];
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < cols; j++) {
                    transpose[i, j] = matrix[j, i];
                }
            }
            return transpose;
        }


        public static T[,] Inverse<T>(T[,] matrix) {
            T[,] adj = Adjugate<T>(matrix);
            T determinant = Determinant<T>(matrix);
            return Map<T>(adj, x => (dynamic)x / determinant);
        }

        public static T[,] Adjugate<T>(T[,] matrix) {
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
            T[,] adj = new T[rows, cols];

            List<T[,]> minors = Minors<T>(matrix);
            for (int i = 0; i < rows; i++) {
                int sign = i % 2;
                for (int j = 0; j < cols; j++) {
                    adj[i, j] = (dynamic)Determinant<T>(minors[i * rows + j]) * (int)Math.Pow(-1, sign++);
                }
            }
            return Transpose<T>(adj);
        }

        public static T Determinant<T>(T[,] matrix) {
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
            if (rows != cols) throw new Exception("Determinant only exists for square matrices");
            if (rows == 1) return matrix[0, 0];
            if (rows == 2) return (dynamic)matrix[0, 0] * matrix[1, 1] - (dynamic)matrix[0, 1] * matrix[1, 0];
            else {
                T determinant = default(T);
                for (int i = 0; i < cols; i++) {
                    determinant += (dynamic)(int)Math.Pow(-1, i) * Determinant<T>(SubMatrix<T>(matrix, 0, i)) * matrix[0, i];
                }
                return determinant;
            }
        }

        public static List<T[,]> Minors<T>(T[,] matrix) {
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
            List<T[,]> minors = new List<T[,]>();
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < cols; j++) {
                    T[,] minor = SubMatrix<T>(matrix, i, j);
                    minors.Add(minor);
                }
            }
            return minors;
        }

        public static T[,] SubMatrix<T>(T[,] matrix, int y, int x) {
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
            T[,] subMatrix = new T[rows - 1, cols - 1];
            int k = 0, l = 0;
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < cols; j++) {
                    if (i != y && j != x) {
                        subMatrix[k, l] = matrix[i, j];
                        if ((l = (l + 1) % (cols - 1)) == 0) k++;
                    }
                }
            }
            return subMatrix;
        }

        public static T RowMinima<T>(T[,] matrix, int row) {
            if (row >= matrix.GetLength(0)) throw new ArgumentException("Row index out of bounds of the matrix");
            T min = matrix[row, 0];
            for (int i = 0; i < matrix.GetLength(1); i++) {
                if ((dynamic)min > matrix[row, i]) min = matrix[row, i];
            }
            return min;
        }

        public static T ColumnMinima<T>(T[,] matrix, int column) {
            if (column >= matrix.GetLength(1)) throw new ArgumentException("Column index out of bounds of the matrix");
            T min = matrix[0, column];
            for (int i = 0; i < matrix.GetLength(0); i++) {
                if ((dynamic)min > matrix[i, column]) min = matrix[i, column];
            }
            return min;
        }
    }
}
