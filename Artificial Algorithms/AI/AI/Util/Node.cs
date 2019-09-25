using System;
using System.Collections.Generic;
using System.Linq;

namespace AI.Util {
    public class Node {//: IComparable<Node> {

        string label;
        int inDegree;
        int outDegree;
        int index;
        int level;

        HashSet<Edge> connectedEdgesIn;
        HashSet<Edge> connectedEdgesOut;
        HashSet<Node> childNodes;
        HashSet<Node> parentNodes;

        public int Level { get { return level; } }
        public Object Data { get; set; }
        public int InDegree { get { return inDegree; } }
        public int OutDegree { get { return outDegree; } }
        public int Index { get { return index; } }
        public List<Edge> ConnectedEdgesIn { get { return connectedEdgesIn.ToList<Edge>(); } }
        public List<Edge> ConnectedEdgesOut { get { return connectedEdgesOut.ToList<Edge>(); } }
        public List<Node> ParentNodes { get { return parentNodes.ToList<Node>(); } }
        public List<Node> ChildNodes { get { return childNodes.ToList<Node>(); } }
        public string Label { get { return label; } }

        public Node(string label, int index, int level = 0) {
            connectedEdgesIn = new HashSet<Edge>();
            connectedEdgesOut = new HashSet<Edge>();
            childNodes = new HashSet<Node>();
            parentNodes = new HashSet<Node>();
            this.index = index;
            this.label = label;
            this.level = level;
        }

        public int CompareTo(Node other) {
            return this.label.CompareTo(other.label);
        }

        public void Update(Edge e) {
            if (e.From == this) {
                connectedEdgesOut.Add(e);
                childNodes.Add(e.To);
                outDegree++;
            } else {
                ConnectedEdgesIn.Add(e);
                parentNodes.Add(e.From);
                inDegree++;
            }
        }


    }
}
