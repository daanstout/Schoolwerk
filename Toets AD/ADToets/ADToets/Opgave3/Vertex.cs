using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADToets.Opgave3 {
    public class Vertex {
        public string name;
        public List<Edge> adj;
        public double dist;
        public Vertex prev;
        public bool scratch;

        public Vertex(string name) {
            this.name = name;
            adj = new List<Edge>();
            Reset();
        }


        public void Reset() {
            dist = Graph.INFINITY;
            prev = null;
            scratch = false;
        }

        public override string ToString() {
            string returnString = string.Format("{0} -->", name);
            foreach (Edge e in adj) {
                returnString = string.Format("{0} {1}({2})", returnString, e.destination.name, e.cost);
            }
            return returnString;
        }
    }
}
