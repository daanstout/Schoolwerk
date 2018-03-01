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
using ResourceGatherer.Properties;
using ResourceGatherer.Entities.StaticEntities;

namespace ResourceGatherer.World {
    public class GameWorld {
        public readonly int gameWidth;
        public readonly int gameHeight;

        private BaseTile[] tiles;
        private int tileCount;
        private Graph graph;

        private Random rand;

        public GameWorld(int width, int height) {
            gameWidth = width;
            gameHeight = height;

            rand = new Random();

            initTiles();
            initGraph();
        }

        private void initTiles() {
            tileCount = (gameWidth / BaseTile.tileWidth) * (gameHeight / BaseTile.tileHeight);
            tiles = new BaseTile[tileCount];

            float curX = 0, curY = 0;
            for (int i = 0; i < tileCount; i++) {
                tiles[i] = new TileLand(new Vector2D(new Vector2D(curX, curY)));
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

            for (int i = 80; i < 120; i++) {
                tiles[i] = tiles[i].GetRiverTile();

                bool bridge = rand.Next(0, 10) == 0;
                if (bridge) {
                    TileRiver tile = (TileRiver)tiles[i];
                    tile.AddBridge(false);
                    tile.AddBridgeSprite(Resources.Bridge_01);
                }
            }

            for (int i = 8; i < tileCount; i += 40) {
                tiles[i] = tiles[i].GetRiverTile();

                bool bridge = rand.Next(0, 10) == 0;
                if (bridge) {
                    TileRiver tile = (TileRiver)tiles[i];
                    tile.AddBridge(true);
                    tile.AddBridgeSprite(Resources.Bridge_01);
                }
            }

            SetSprites();
        }

        private void SetSprites() {
            for (int i = 0; i < tileCount; i++) {
                if (tiles[i] is TileRiver) {
                    SetRiverTile(i);
                } else if (tiles[i] is TileLand) {
                    SetLandTile(i);
                }
            }
        }

        private void SetLandTile(int index) {
            if (index >= 0 && index < tileCount) {
                int random = rand.Next(0, 4);
                Bitmap sprite = Resources.Land_01;

                switch (random) {
                    case 0:
                        sprite.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        break;
                    case 1:
                        sprite.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        break;
                    case 2:
                        sprite.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        break;
                }

                random = rand.Next(0, 100);
                if (random == 0)
                    if (rand.Next(0, 2) == 1)
                        tiles[index].AddEntityToTile(new MaterialEntity(BaseEntity.Entity_types.WOOD, tiles[index].position, 3, 1));
                    else
                        tiles[index].AddEntityToTile(new MaterialEntity(BaseEntity.Entity_types.STONE, tiles[index].position, 3, 1));

                tiles[index].sprite = sprite;
            }
        }

        private void SetRiverTile(int index) {
            if (index >= 0 && index < tileCount) {
                int tilesPerRow = gameWidth / BaseTile.tileWidth;

                bool up = false, down = false, left = false, right = false;
                if (index > tilesPerRow)
                    up = tiles[index - tilesPerRow] is TileRiver;
                else
                    up = true;

                if (index % tilesPerRow != 0)
                    left = tiles[index - 1] is TileRiver;
                else
                    left = true;

                if (index < tileCount - tilesPerRow)
                    down = tiles[index + tilesPerRow] is TileRiver;
                else
                    down = true;

                if ((index + 1) % tilesPerRow != 0)
                    right = tiles[index + 1] is TileRiver;
                else
                    right = true;

                if (left && right && !up && !down) {
                    tiles[index].sprite = Resources.River_01;
                } else if (up && down && !left && !right) {
                    Bitmap river = Resources.River_01;
                    river.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    tiles[index].sprite = river;
                } else if (up && down && left && right) {
                    tiles[index].sprite = Resources.RIver_02;
                }
            }
        }

        private void initGraph() {
            graph = new Graph();

            for (int i = 0; i < tileCount; i++) {
                if (tiles[i].isWalkable && tiles[i].tileVertex == null) {
                    CreateGraph(tiles[i]);
                }
            }
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
