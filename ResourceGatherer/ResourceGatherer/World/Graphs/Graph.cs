using ResourceGatherer.Util;
using ResourceGatherer.World.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.World.Graphs {
    public class Graph {
        public static readonly float INFINITY = float.MaxValue;
        private GameWorld world;

        public Graph(GameWorld world) {
            this.world = world;
        }

        public void initGraph() {
            for (int i = 0; i < world.tiles.tileCount; i++)
                world.tiles.tiles[i].DestroyTileVertex();

            for (int i = 0; i < world.tiles.tileCount; i++) {
                if (world.tiles.tiles[i].isWalkable && world.tiles.tiles[i].tileVertex == null) {
                    CreateGraph(world.tiles.tiles[i]);
                }
            }
        }

        private void AddEdge(BaseTile a, BaseTile b, float cost) {
            if (a.tileVertex == null || b.tileVertex == null)
                return;

            a.tileVertex.adj.Add(new Edge(b.tileVertex, cost));
            b.tileVertex.adj.Add(new Edge(a.tileVertex, cost));
        }

        private void CreateGraph(BaseTile tile) {
            if (tile == null)
                return;

            Util.Datastructures.Queue<BaseTile> q = new Util.Datastructures.Queue<BaseTile>();

            q.Enqueue(tile);

            int count = 0;

            while (!q.isEmpty) {
                count++;

                BaseTile current = q.Dequeue();

                current.CreateTileVertex();

                List<BaseTile> neighbours = world.tiles.GetWalkableNeighbours(current);

                foreach (BaseTile t in neighbours) {
                    if (current.HasAdjacent(t))
                        continue;
                    t.CreateTileVertex();
                    AddEdge(current, t, 1);
                    q.Enqueue(t);
                }
            }
        }
    }
}
