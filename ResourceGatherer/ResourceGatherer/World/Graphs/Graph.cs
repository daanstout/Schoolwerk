using ResourceGatherer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.World.Graphs {
    public class Graph {
        public static readonly float INFINITY = float.MaxValue;
        Dictionary<Vector2D, Vertex> vertexMap = new Dictionary<Vector2D, Vertex>();

        public void AddVertexToMap(Vertex v) {
            if (!vertexMap.ContainsKey(v.parentTile.position))
                vertexMap.Add(v.parentTile.position, v);
        }

        public Vertex GetVertex(Vector2D v) {
            try {
                return vertexMap[v];
            } catch {
                return null;
            }
        }

        public void AddEdge(Vector2D a, Vector2D b, float cost) {
            Vertex v1 = GetVertex(a);
            Vertex v2 = GetVertex(b);

            if (v1 == null || v2 == null)
                return;

            v1.adj.Add(new Edge(v2, cost));
            v2.adj.Add(new Edge(v1, cost));
        }

        public bool IsPresent(Vertex v) {
            return vertexMap.ContainsValue(v);
        }
    }
}
