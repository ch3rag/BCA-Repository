using System;

namespace AI.Util {
    public class Edge : IComparable<Edge> {
        Node to;
        Node from;
        double weight;
        string label;

        public string Label { get { return label; } }
        public Node To { get { return to; } }
        public Node From { get { return from; } }
        public double Weight { get { return weight; } }

        public Edge(Node to, Node from, double weight) {
            this.to = to;
            this.from = from;
            this.weight = weight;
            this.label = GetLabel(to, from);
        }

        public static string GetLabel(Node to, Node from) {
            return String.Format("{0} --> {1}", to.Label, from.Label);
        }

        public int CompareTo(Edge other) {
            return To.CompareTo(other.To) - From.CompareTo(other.From);
        }
    }
}
