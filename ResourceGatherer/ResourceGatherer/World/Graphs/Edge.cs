using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.World.Graphs {
    public class Edge {
        public Vertex destination;
        public float cost;

        public Edge(Vertex dest, float cost) {
            destination = dest;
            this.cost = cost;
        }
    }
}
