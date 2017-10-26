using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.Week6.Graven {
    public class Graph : IGraph {
        public static readonly double INFINITY = double.MaxValue;
        Dictionary<string, Vertex> vertexMap = new Dictionary<string, Vertex>();


        public void AddEdge(string source, string dest, double cost) {
            Vertex v = GetVertex(source);
            Vertex w = GetVertex(dest);
            v.adj.Add(new Edge(w, cost));
        }

        public Vertex GetVertex(string name) {
            Vertex v;
            try {
                v = vertexMap[name];
            } catch {
                v = new Vertex(name);
                vertexMap.Add(name, v);
            }
            return v;
        }

        public override string ToString() {
            string returnString = "";
            foreach (Vertex v in vertexMap.Values) {
                returnString += v + "\n";
            }
            return returnString;
        }

        public void Unweighted(string name) {
            ClearAll();

            Vertex start;
            try {
                start = vertexMap[name];
            } catch {
                Console.WriteLine("Vertex does not exist");
                return;
            }

            Queue<Vertex> q = new Queue<Vertex>();
            q.Enqueue(start);
            start.dist = 0;

            while (q.Count > 0) {
                Vertex v = q.Dequeue();

                foreach (Edge e in v.adj) {
                    Vertex w = e.destination;

                    if (w.dist == INFINITY) {
                        w.dist = v.dist + 1;
                        w.prev = v;
                        q.Enqueue(w);
                    }
                }
            }
        }

        public void dijkstra(string name) {
            ClearAll();

            Vertex start;
            try {
                start = vertexMap[name];
            } catch {
                Console.WriteLine("Vertex does not exist");
                return;
            }

            List<Edge> availableRoutes = new List<Edge>();
            foreach (Edge e in start.adj)
                availableRoutes.Add(e);
            int nodesSeen = 0;

            while (availableRoutes.Count > 0 && nodesSeen < vertexMap.Count) {
                Edge route = getClosestEdge(availableRoutes);
                availableRoutes.Remove(route);

                Vertex v = route.destination;
                if (v.scratch)
                    continue;

                v.scratch = true;
                nodesSeen++;

                foreach(Edge e in v.adj) {
                    Vertex w = e.destination;
                    double cvw = e.cost;

                    if(w.dist > v.dist + cvw) {
                        w.dist = v.dist + cvw;
                        w.prev = v;
                        availableRoutes.Add(e);
                    }
                }
            }
        }

        private Edge getClosestEdge(List<Edge> list) {
            Edge v = list[0];
            foreach (Edge e in list) {
                if (e.cost < v.cost)
                    v = e;
            }
            return v;
        }

        private void printPath(Vertex dest) {
            if (dest.prev != null) {
                printPath(dest.prev);
                Console.Write(" to ");
            }
            Console.Write(dest.name);
        }

        public void printPath(string name) {
            Vertex v;
            try {
                v = vertexMap[name];
            } catch {
                Console.WriteLine("Vertex does not exist");
                return;
            }

            if (v.dist == INFINITY) {
                Console.WriteLine(name + " is unreachable");
            } else {
                Console.Write("Cost: " + v.dist + ". Path: ");
                printPath(v);
                Console.WriteLine();
            }
        }

        private void ClearAll() {
            foreach (Vertex v in vertexMap.Values) {
                v.Reset();
            }
        }
    }
}
