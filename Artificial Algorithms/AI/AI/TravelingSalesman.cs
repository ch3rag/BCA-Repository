using System;
using System.Collections.Generic;
using System.Linq;
using AI.Util;
using AI.Lib;

namespace AI {
    public class TravelingSalesman {

        struct TSPNodeData : IComparable<TSPNodeData> {
            public double cost;
            public double[,] matrix;
            public bool[] visited;
            public int[] path;
            public int level;
            public int index;
            public int CompareTo(TSPNodeData other) {
                return this.cost.CompareTo(other.cost);
            }
            public override string ToString() {
                return String.Format("Cost: {0}, Level: {1}, Index: {2}", cost, level, index);
            }
        }

        List<TSPNodeData> nodes = new List<TSPNodeData>();
        readonly int dimension;
        int[] path;
        double cost;

        public int[] Path { get { return path; } }
        public double Cost { get { return cost; } }

        public TravelingSalesman(Graph graph) {
            double cost;
            double[,] matrix = ReduceMatrix(graph.GetMatrix(), out cost);
            dimension = matrix.GetLength(0);
            bool[] visited = new bool[dimension];
            visited[0] = true;
            int[] path = new int[dimension + 1];
            TSPNodeData root = new TSPNodeData() {
                cost = cost,
                matrix = matrix,
                visited = visited,
                level = 0,
                index = 0,
                path = path
            };
            nodes.Add(root);
            calculate(root);
        }

        
        

        void calculate(TSPNodeData node) {

            nodes.Remove(node);
            if (node.level == dimension - 1) {
                this.path =  node.path;
                this.cost = node.cost;
                return;
            }

            for (int k = 0; k < dimension; k++) {
                if (node.visited[k] == false) {
                    double[,] newMatrix = MatrixUtil.Clone(node.matrix);
                    double cij = newMatrix[node.index, k];
                    newMatrix[k, node.index] = Weight.Infinity;
                    for (int i = 0; i < dimension; i++) {
                        for (int j = 0; j < dimension; j++) {
                            if (i == node.index || j == k) newMatrix[i, j] = Weight.Infinity;
                        }
                    }
                    double cost;
                    double[,] reducedNewMatrix = ReduceMatrix(newMatrix, out cost);
                    cost += cij + node.cost;
                    bool[] visited = new bool[dimension];
                    int[] path = new int[dimension + 1];
                    Array.Copy(node.visited, visited, dimension);
                    Array.Copy(node.path, path, dimension);
                    visited[k] = true;
                    path[node.level + 1] = k;
                    nodes.Add(new TSPNodeData() {
                        matrix = reducedNewMatrix,
                        cost = cost,
                        level = node.level + 1,
                        visited = visited,
                        index = k,
                        path = path
                    });
                }
            }
            nodes.Sort();   
            calculate(nodes[0]);
        }

        double[,] ReduceMatrix(double[,] mat, out double cost) {
            cost = 0;
            double[,] matrix = MatrixUtil.Clone(mat);
            for (int i = 0; i < matrix.GetLength(0); i++) {
                double min = Weight.Infinity;
                for (int j = 0; j < matrix.GetLength(1); j++) { 
                    if (min > matrix[i, j]) min = matrix[i, j];
                }
                if (min > 0 && min != Weight.Infinity) {
                    for (int j = 0; j < matrix.GetLength(1); j++) {
                        matrix[i, j] -= min;
                    }
                    cost += min;
                }
            }

            for (int i = 0; i < matrix.GetLength(1); i++) {
                double min = Weight.Infinity;
                for (int j = 0; j < matrix.GetLength(0); j++) {
                    if (min > matrix[j, i]) min = matrix[j, i];
                }
                if (min > 0 && min != Weight.Infinity) {
                    for (int j = 0; j < matrix.GetLength(1); j++) {
                        matrix[j, i] -= min;
                    }
                    cost += min;
                }
            }
            return matrix;
        }
    }
}