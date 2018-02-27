using ResourceGatherer.Entities;
using ResourceGatherer.Util;
using ResourceGatherer.World.Tiles;
using ResourceGatherer.World.Graphs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.World {
    public class GameWorld {
        public readonly int gameWidth;
        public readonly int gameHeight;

        private BaseTile[] tiles;
        private int tileCount;
        private Graph graph;

        public GameWorld(int width, int height) {
            gameWidth = width;
            gameHeight = height;

            initTiles();
            initGraph();
        }

        private void initTiles() {
            tileCount = (gameWidth / BaseTile.tileWidth) * (gameHeight / BaseTile.tileHeight);
            tiles = new BaseTile[tileCount];

            float curX = 0, curY = 0;
            for (int i = 0; i < tileCount; i++) {
                tiles[i] = new BaseTile(new Vector2D(new Vector2D(curX, curY)));
                curX += BaseTile.tileWidth;
                if (curX >= gameWidth) {
                    curX = 0;
                    curY += BaseTile.tileHeight;
                }
            }
            tiles[132].isWalkable = false;
            tiles[133].isWalkable = false;
            tiles[134].isWalkable = false;
            tiles[172].isWalkable = false;
            tiles[173].isWalkable = false;
            tiles[174].isWalkable = false;
        }

        private void initGraph() {
            graph = new Graph();

            BaseTile start = null;
            for (int i = 0; i < tileCount; i++) {
                if (tiles[i].isWalkable) {
                    start = tiles[i];
                    break;
                }
            }

            if (start == null)
                return;

            Util.Datastructures.Queue<BaseTile> q = new Util.Datastructures.Queue<BaseTile>();

            q.Enqueue(start);

            int count = 0;

            while (!q.isEmpty) {
                count++;

                BaseTile current = q.Dequeue();

                current.CreateTileVertex();

                graph.AddVertexToMap(current.tileVertex);

                List<BaseTile> neighbours = GetWalkableNeighbours(current);

                foreach (BaseTile t in neighbours) {
                    if (current.HasAdjacent(t))
                        continue;
                    t.CreateTileVertex();
                    graph.AddVertexToMap(t.tileVertex);
                    graph.AddEdge(current.position, t.position, 1);
                    q.Enqueue(t);
                }
            }
        }

        private List<BaseTile> GetNeighbours(BaseTile tile) {
            List<BaseTile> list = new List<BaseTile>();
            if (tile.position.x >= BaseTile.tileWidth)
                list.Add(tiles[GetIndexOfTile(tile.position - new Vector2D(BaseTile.tileWidth, 0))]);
            if (tile.position.x < gameWidth - BaseTile.tileWidth)
                list.Add(tiles[GetIndexOfTile(tile.position + new Vector2D(BaseTile.tileWidth, 0))]);

            if (tile.position.y >= BaseTile.tileHeight)
                list.Add(tiles[GetIndexOfTile(tile.position - new Vector2D(0, BaseTile.tileHeight))]);
            if (tile.position.y < gameHeight - BaseTile.tileWidth)
                list.Add(tiles[GetIndexOfTile(tile.position + new Vector2D(0, BaseTile.tileHeight))]);

            return list;
        }

        private List<BaseTile> GetAllNeighbours(BaseTile tile) {
            List<BaseTile> list = new List<BaseTile>();
            bool up = false, down = false, left = false, right = false;

            if (tile.position.x >= BaseTile.tileWidth)
                left = true;

            if (tile.position.x < gameWidth - BaseTile.tileWidth)
                right = true;

            if (tile.position.y >= BaseTile.tileHeight)
                up = true;

            if (tile.position.y < gameHeight - BaseTile.tileWidth)
                down = true;

            if (up) {
                list.Add(tiles[GetIndexOfTile(tile.position + new Vector2D(0, -BaseTile.tileHeight))]);
                if (left)
                    list.Add(tiles[GetIndexOfTile(tile.position + new Vector2D(-BaseTile.tileWidth, -BaseTile.tileHeight))]);
                if (right)
                    list.Add(tiles[GetIndexOfTile(tile.position + new Vector2D(BaseTile.tileWidth, -BaseTile.tileHeight))]);
            }

            if (down) {
                list.Add(tiles[GetIndexOfTile(tile.position + new Vector2D(0, BaseTile.tileHeight))]);
                if (left)
                    list.Add(tiles[GetIndexOfTile(tile.position + new Vector2D(-BaseTile.tileWidth, BaseTile.tileHeight))]);
                if (right)
                    list.Add(tiles[GetIndexOfTile(tile.position + new Vector2D(BaseTile.tileWidth, BaseTile.tileHeight))]);
            }

            if (left)
                list.Add(tiles[GetIndexOfTile(tile.position + new Vector2D(-BaseTile.tileWidth, 0))]);

            if (right)
                list.Add(tiles[GetIndexOfTile(tile.position + new Vector2D(BaseTile.tileWidth, 0))]);

            return list;
        }

        private List<BaseTile> GetWalkableNeighbours(BaseTile tile) {
            List<BaseTile> list = new List<BaseTile>();
            if (tile.position.x >= BaseTile.tileWidth) {
                BaseTile newTile = tiles[GetIndexOfTile(tile.position - new Vector2D(BaseTile.tileWidth, 0))];
                if (newTile.isWalkable)
                    list.Add(newTile);
            }
            if (tile.position.x < gameWidth - BaseTile.tileWidth) {
                BaseTile newTile = tiles[GetIndexOfTile(tile.position + new Vector2D(BaseTile.tileWidth, 0))];
                if (newTile.isWalkable)
                    list.Add(newTile);
            }

            if (tile.position.y >= BaseTile.tileHeight) {
                BaseTile newTile = tiles[GetIndexOfTile(tile.position - new Vector2D(0, BaseTile.tileHeight))];
                if (newTile.isWalkable)
                    list.Add(newTile);
            }
            if (tile.position.y < gameHeight - BaseTile.tileWidth) {
                BaseTile newTile = tiles[GetIndexOfTile(tile.position + new Vector2D(0, BaseTile.tileHeight))];
                if (newTile.isWalkable)
                    list.Add(newTile);
            }

            return list;
        }

        public int GetIndexOfTile(Vector2D pos) {
            int tilesPerRow = gameWidth / BaseTile.tileWidth;
            int index = (int)(pos.y / BaseTile.tileHeight) * tilesPerRow;
            index += (int)(pos.x / BaseTile.tileWidth);
            return index;
        }

        public void Update() {

        }

        public void Draw(Graphics g) {

        }

        public void GetBackground(Graphics g) {
            for (int i = 0; i < tileCount; i++) {
                tiles[i].Render(g);
            }
        }
    }
}
