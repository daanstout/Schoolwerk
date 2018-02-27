using ResourceGatherer.World.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.World.Graphs {
    public class Vertex {
        public string name;
        public BaseTile parentTile;
        public List<Edge> adj;
        public float dist;
        public Vertex prev;
        public bool Scratch;

        public Vertex(string name, BaseTile parentTile) {
            this.name = name;
            this.parentTile = parentTile;
            adj = new List<Edge>();
        }

        public void Reset() {
            dist = Graph.INFINITY;
            prev = null;
            Scratch = false;
        }
    }
}
