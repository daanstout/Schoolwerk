using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.World.Graphs {
    /// <summary>
    /// An edge, it connects 2 Verteces with a cost
    /// </summary>
    public sealed class Edge {
        /// <summary>
        /// The destination Vertex
        /// </summary>
        public Vertex destination;
        /// <summary>
        /// The cost to move between vectors
        /// </summary>
        public float cost;

        /// <summary>
        /// Creates a new edge
        /// </summary>
        /// <param name="dest">The destination, the source Vertex contains the edge</param>
        /// <param name="cost">The cost to move from source to destination</param>
        public Edge(Vertex dest, float cost) {
            destination = dest;
            this.cost = cost;
        }
    }
}
