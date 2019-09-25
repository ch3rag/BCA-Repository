using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Util {
    public class Tree  {
        Dictionary<string, Node> nodes;
        public List<Node> Nodes { get { return nodes.Values.ToList<Node>(); } }

        Dictionary<string, Edge> edges;
        public List<Edge> Edges { get { return edges.Values.ToList<Edge>(); } }


        public void AddNode(Node node) {
            if (nodes.ContainsKey(node.Label)) {
                throw new Exception("Node Already Exists.");
            } else {
                nodes.Add(node.Label, node);
            }
        }
    }
}
