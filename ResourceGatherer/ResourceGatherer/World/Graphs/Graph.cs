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

        public void AddEdge(BaseTile a, BaseTile b, float cost) {
            if (a.tileVertex == null || b.tileVertex == null)
                return;

            a.tileVertex.adj.Add(new Edge(b.tileVertex, cost));
            b.tileVertex.adj.Add(new Edge(a.tileVertex, cost));
        }

        public void CreateGraph(BaseTile tile) {
            if (tile == null)
                return;

            Util.Datastructures.Queue<BaseTile> q = new Util.Datastructures.Queue<BaseTile>();

            q.Enqueue(tile);

            int count = 0;

            while (!q.isEmpty) {
                count++;

                BaseTile current = q.Dequeue();

                current.CreateTileVertex();

                List<BaseTile> neighbours = GetWalkableNeighbours(current);

                foreach (BaseTile t in neighbours) {
                    if (current.HasAdjacent(t))
                        continue;
                    t.CreateTileVertex();
                    AddEdge(current, t, 1);
                    q.Enqueue(t);
                }
            }
        }

        private List<BaseTile> GetNeighbours(BaseTile tile) {
            List<BaseTile> list = new List<BaseTile>();
            if (tile.position.x >= BaseTile.tileWidth)
                list.Add(world.tiles[GetIndexOfTile(tile.position - new Vector2D(BaseTile.tileWidth, 0))]);
            if (tile.position.x < world.gameWidth - BaseTile.tileWidth)
                list.Add(world.tiles[GetIndexOfTile(tile.position + new Vector2D(BaseTile.tileWidth, 0))]);

            if (tile.position.y >= BaseTile.tileHeight)
                list.Add(world.tiles[GetIndexOfTile(tile.position - new Vector2D(0, BaseTile.tileHeight))]);
            if (tile.position.y < world.gameHeight - BaseTile.tileWidth)
                list.Add(world.tiles[GetIndexOfTile(tile.position + new Vector2D(0, BaseTile.tileHeight))]);

            return list;
        }

        private List<BaseTile> GetAllNeighbours(BaseTile tile) {
            List<BaseTile> list = new List<BaseTile>();
            bool up = false, down = false, left = false, right = false;

            if (tile.position.x >= BaseTile.tileWidth)
                left = true;

            if (tile.position.x < world.gameWidth - BaseTile.tileWidth)
                right = true;

            if (tile.position.y >= BaseTile.tileHeight)
                up = true;

            if (tile.position.y < world.gameHeight - BaseTile.tileWidth)
                down = true;

            if (up) {
                list.Add(world.tiles[GetIndexOfTile(tile.position + new Vector2D(0, -BaseTile.tileHeight))]);
                if (left)
                    list.Add(world.tiles[GetIndexOfTile(tile.position + new Vector2D(-BaseTile.tileWidth, -BaseTile.tileHeight))]);
                if (right)
                    list.Add(world.tiles[GetIndexOfTile(tile.position + new Vector2D(BaseTile.tileWidth, -BaseTile.tileHeight))]);
            }

            if (down) {
                list.Add(world.tiles[GetIndexOfTile(tile.position + new Vector2D(0, BaseTile.tileHeight))]);
                if (left)
                    list.Add(world.tiles[GetIndexOfTile(tile.position + new Vector2D(-BaseTile.tileWidth, BaseTile.tileHeight))]);
                if (right)
                    list.Add(world.tiles[GetIndexOfTile(tile.position + new Vector2D(BaseTile.tileWidth, BaseTile.tileHeight))]);
            }

            if (left)
                list.Add(world.tiles[GetIndexOfTile(tile.position + new Vector2D(-BaseTile.tileWidth, 0))]);

            if (right)
                list.Add(world.tiles[GetIndexOfTile(tile.position + new Vector2D(BaseTile.tileWidth, 0))]);

            return list;
        }

        private List<BaseTile> GetWalkableNeighbours(BaseTile tile) {
            List<BaseTile> list = new List<BaseTile>();
            if (tile.position.x >= BaseTile.tileWidth) {
                BaseTile newTile = world.tiles[GetIndexOfTile(tile.position - new Vector2D(BaseTile.tileWidth, 0))];
                if (newTile.isWalkable)
                    list.Add(newTile);
            }
            if (tile.position.x < world.gameWidth - BaseTile.tileWidth) {
                BaseTile newTile = world.tiles[GetIndexOfTile(tile.position + new Vector2D(BaseTile.tileWidth, 0))];
                if (newTile.isWalkable)
                    list.Add(newTile);
            }

            if (tile.position.y >= BaseTile.tileHeight) {
                BaseTile newTile = world.tiles[GetIndexOfTile(tile.position - new Vector2D(0, BaseTile.tileHeight))];
                if (newTile.isWalkable)
                    list.Add(newTile);
            }
            if (tile.position.y < world.gameHeight - BaseTile.tileWidth) {
                BaseTile newTile = world.tiles[GetIndexOfTile(tile.position + new Vector2D(0, BaseTile.tileHeight))];
                if (newTile.isWalkable)
                    list.Add(newTile);
            }

            return list;
        }

        public int GetIndexOfTile(Vector2D pos) {
            int tilesPerRow = world.gameWidth / BaseTile.tileWidth;
            int index = (int)(pos.y / BaseTile.tileHeight) * tilesPerRow;
            index += (int)(pos.x / BaseTile.tileWidth);
            return index;
        }
    }
}
