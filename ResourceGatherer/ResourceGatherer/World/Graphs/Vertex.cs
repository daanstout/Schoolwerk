using ResourceGatherer.World.Tiles;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.World.Graphs {
    /// <summary>
    /// The vertex class. These are points an agent can move to, using the edges to calculate its path
    /// </summary>
    public sealed class Vertex {
        /// <summary>
        /// The name of the vertex
        /// </summary>
        public string name;
        /// <summary>
        /// The tile this vertex resides on
        /// </summary>
        public BaseTile parentTile;
        /// <summary>
        /// A list of adjacent edges
        /// </summary>
        public List<Edge> adj;

        // The following constructors are used to calculate paths with
        /// <summary>
        /// The distance from the start to here
        /// </summary>
        public float dist;
        /// <summary>
        /// The previous Vertex. This will give the path from the source to this vertex
        /// </summary>
        public Vertex prev;
        /// <summary>
        /// Whether the current vertex has been visited yet
        /// </summary>
        public bool Scratch;

        /// <summary>
        /// Creates a new vertex
        /// </summary>
        /// <param name="name">The name of the vertex</param>
        /// <param name="parentTile">The parenttile of the vertex</param>
        public Vertex(string name, BaseTile parentTile) {
            this.name = name;
            this.parentTile = parentTile;
            adj = new List<Edge>();

            Reset();
        }

        /// <summary>
        /// Resets the vertex
        /// </summary>
        public void Reset() {
            dist = Graph.INFINITY;
            prev = null;
            Scratch = false;
        }

        /// <summary>
        /// Resets the vertex
        /// </summary>
        /// <param name="v">The vertex to be reset</param>
        public static void ResetVertex(Vertex v) {
            if (v == null)
                return;
            v.Reset();
        }
    }
}
