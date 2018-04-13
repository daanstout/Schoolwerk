using ResourceGatherer.World.Tiles;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.World.Graphs {
    /// <summary>
    /// The graph class. It makes sure our Game can have a working graph system
    /// </summary>
    public sealed class Graph {
        /// <summary>
        /// The max value of a float
        /// </summary>
        public static readonly float INFINITY = float.MaxValue;

        /// <summary>
        /// The constructor
        /// </summary>
        public Graph() { }

        /// <summary>
        /// Initializes the graph, first destroying every vertex and then recreating them where possible
        /// </summary>
        public void initGraph() {
            // Destroying every vertex
            for (int i = 0; i < GameWorld.instance.tiles.tileCount; i++)
                GameWorld.instance.tiles.tiles[i].DestroyTileVertex();

            // Look through our world and whenever we find a tile that can be walked on and doesn't have a vertex yet, we create a new graph
            for (int i = 0; i < GameWorld.instance.tiles.tileCount; i++) {
                if (GameWorld.instance.tiles.tiles[i].isWalkable && GameWorld.instance.tiles.tiles[i].tileVertex == null) {
                    CreateGraph(GameWorld.instance.tiles.tiles[i]);
                }
            }
        }

        /// <summary>
        /// Adds an edge with a cost, going both way between a and b
        /// </summary>
        /// <param name="a">The first tile</param>
        /// <param name="b">The second tile</param>
        /// <param name="cost">The cost of the edge</param>
        public void AddEdge(BaseTile a, BaseTile b, float cost) {
            // If either is 0, we can't do anything
            if (a.tileVertex == null || b.tileVertex == null)
                return;

            a.tileVertex.adj.Add(new Edge(b.tileVertex, cost));
            b.tileVertex.adj.Add(new Edge(a.tileVertex, cost));
        }

        /// <summary>
        /// Creates a graph from the starting tile
        /// </summary>
        /// <param name="tile">The starting tile</param>
        private void CreateGraph(BaseTile tile) {
            if (tile == null)
                return;

            // A queue to house the tiles yet to be created
            Util.Datastructures.Queue<BaseTile> q = new Util.Datastructures.Queue<BaseTile>();

            q.Enqueue(tile);

            float diag = (float)Math.Sqrt(2);

            // While we have unvisited tiles
            while (!q.isEmpty) {
                // Get a tile
                BaseTile current = q.Dequeue();

                // Create a vertex
                current.CreateTileVertex();

                // Get all neighbours
                List<BaseTile> neighbours = GameWorld.instance.tiles.GetWalkableNeighbours(current);

                // For every tile, check if there already is an edge connecting the 2, if not, create it and add the neighbour to the queue
                foreach (BaseTile t in neighbours) {
                    if (current.HasAdjacent(t) || (current is TileRiver && t is TileRiver))
                        continue;
                    t.CreateTileVertex();
                    AddEdge(current, t, 1);
                    q.Enqueue(t);
                }

                if (current.allowDiagonal) {
                    neighbours = GameWorld.instance.tiles.GetWalkableDiagonalNeighbours(current);
                    foreach (BaseTile t in neighbours) {
                        if (current.HasAdjacent(t) || !t.allowDiagonal)
                            continue;
                        t.CreateTileVertex();
                        AddEdge(current, t, diag);
                        q.Equals(t);
                    }
                }
            }
        }
    }
}
