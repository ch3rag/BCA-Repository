using System;
using System.Collections.Generic;
using System.Linq;

namespace AI.Util {
    public class Graph {

        Dictionary<string, Node> nodes;
        public List<Node> Nodes { get { return nodes.Values.ToList<Node>(); } }

        Dictionary<string, Edge> edges;
        public List<Edge> Edges { get { return edges.Values.ToList<Edge>(); } }

        

        public Graph() {
            nodes = new Dictionary<string, Node>();
            edges = new Dictionary<string, Edge>();
        }

        public Graph(double[,] matrix, string[] labels = null) : this() {

            int rows = matrix.GetLength(0); int cols = matrix.GetLength(1);
            if (rows != cols) throw new Exception("Graph Can Only Be Generated From Square Matrices.");
            if (labels != null && labels.Length < rows) throw new Exception("Must Provide All The Labels If Passed.");

            
            for (int i = 0; i < rows; i++) {
                AddNode(i.ToString());
            }

            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < cols; j++) {
                    AddEdge(i.ToString(), j.ToString(), matrix[i, j], false);
                }
            }
        }

        public void AddNode(string label) {
            AddNode(new Node(label, Nodes.Count));
        }

        public void AddNode(Node node) {
            if(nodes.ContainsKey(node.Label)) {
                throw new Exception("Node Already Exists.");
            } else {
                nodes.Add(node.Label, node);
            }
        }

        public void AddEdge(Edge e) {
            if (edges.ContainsKey(e.Label)) {
                throw new Exception("Edge Already Exists.");
            } else {
                edges.Add(e.Label, e);
                e.From.Update(e);
                e.To.Update(e);
            }
        }

        public void AddEdge(string from, string to) {
            AddEdge(from, to, 0, false);
        }

        public void AddEdge(string from, string to, bool bidirectional) {
            AddEdge(from, to, 0, bidirectional);
        }

        public void AddEdge(string from, string to, double weight) {
            AddEdge(from, to, weight, false);
        }

        public void AddEdge(string from, string to, double weight, bool bidirectional) {
            if (weight < 0) throw new Exception("Weight Cannot Be Negative.");
            if (nodes.ContainsKey(from) && nodes.ContainsKey(to)) {
                Node toNode = nodes[to];
                Node fromNode = nodes[from];
                AddEdge(new Edge(toNode, fromNode, weight));
                if(bidirectional) AddEdge(new Edge(fromNode, toNode, weight));
            } else {
                throw new Exception("Invalid Nodes Specified For Edge.");
            }
        }

        public Edge GetLeastCostEdgeFromNode(string label) {
            return GetLeastCostEdgeFromNode(nodes[label]);
        }

        public Edge GetEdgeBetween(Node n1, Node n2) {
            return edges[Edge.GetLabel(n1, n2)];
        }

        public double LowerBound {
            get {
                double lb = 0;
                foreach (Node n in this.Nodes) {
                    lb += this.GetLeastCostEdgeFromNode(n).Weight;
                }
                return lb;
            }
        }

        public double[,] GetMatrix() {
            int dimension = this.Nodes.Count;
            double[,] matrix = new double[dimension, dimension];

            for (int i = 0; i < matrix.GetLength(0); i++) {
                for (int j = 0; j < matrix.GetLength(1); j++) {
                    matrix[i,j] = Weight.Infinity;        
                }
            }

            foreach (Edge edge in Edges) {
                matrix[edge.From.Index, edge.To.Index] = edge.Weight;   
            }

            return matrix;
        }

        public Edge GetLeastCostEdgeFromNode(Node node) {
            if (node == null) throw new Exception("Invalid Node.");
            else {
                Edge min = node.ConnectedEdgesOut[0];
                foreach (Edge e in node.ConnectedEdgesOut) {
                    if (min.Weight > e.Weight) {
                        min = e;
                    }
                }
                return min;
            }
        }
    }
}
