using ResourceGatherer.World.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.Util {
    public class Path {
        private List<Vertex> path;

        public Path() : this(new List<Vertex>()) { }

        public Path(List<Vertex> path) {
            this.path = path;
        }
    }
}
