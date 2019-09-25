using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI.Lib;
using AI.Util;
namespace AI {
    class Program {
        static void Main(string[] args) {
            Graph g = new Graph();
            g.AddNode("A");
            g.AddNode("B");
            g.AddNode("C");
            g.AddNode("D");
            g.AddNode("E");

            g.AddEdge("A", "B", 10, true);
            g.AddEdge("A", "C", 8, true);
            g.AddEdge("A", "D", 9, true);
            g.AddEdge("A", "E", 7, true);

            g.AddEdge("B", "C", 10, true);
            g.AddEdge("B", "D", 5, true);
            g.AddEdge("B", "E", 6, true);

            g.AddEdge("C", "D", 8, true);
            g.AddEdge("C", "E", 9, true);

            g.AddEdge("D", "E", 6, true);

            TravelingSalesman ts = new TravelingSalesman(g);
            Console.WriteLine("Matrix(adj): \n");
            MatrixUtil.PrintMatrix(g.GetMatrix());
            int[] path = ts.Path;
            Console.WriteLine();
            for (int i = 0; i < path.Length; i++) {
                Console.Write((path[i] + 1));
                if (i != path.Length - 1) Console.Write(" ===> ");
            }
            Console.WriteLine("\n");
            Console.WriteLine("Cost: {0}\n", ts.Cost);
        }
    }
}