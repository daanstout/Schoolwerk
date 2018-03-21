using ResourceGatherer.Entities;
using ResourceGatherer.Entities.StaticEntities;
using ResourceGatherer.Properties;
using ResourceGatherer.Util;
using ResourceGatherer.World.Graphs;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.World.Tiles {
    /// <summary>
    /// The tile system. This holds all the tiles and allows for easy manipulation
    /// </summary>
    public sealed class TileSystem {
        /// <summary>
        /// The tiles
        /// </summary>
        public BaseTile[] tiles;
        /// <summary>
        /// The number of tiles
        /// </summary>
        public int tileCount;

        /// <summary>
        /// The number of tiles in a row
        /// </summary>
        public int tilesPerRow;

        /// <summary>
        /// An random instance
        /// </summary>
        Random rand;

        /// <summary>
        /// Creates a new tilesystem
        /// </summary>
        /// <param name="world">The world instance</param>
        public TileSystem() {
            rand = new Random();
        }

        /// <summary>
        /// Initializes the tiles
        /// </summary>
        public void initTiles() {
            tileCount = (GameWorld.instance.gameWidth / BaseTile.tileWidth) * (GameWorld.instance.gameHeight / BaseTile.tileHeight);
            tilesPerRow = GameWorld.instance.gameWidth / BaseTile.tileWidth;
            tiles = new BaseTile[tileCount];

            float curX = 0, curY = 0;
            for (int i = 0; i < tileCount; i++) {
                tiles[i] = new TileLand(new Vector2D(new Vector2D(curX, curY)));
                curX += BaseTile.tileWidth;
                if (curX >= GameWorld.instance.gameWidth) {
                    curX = 0;
                    curY += BaseTile.tileHeight;
                }
            }

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

        public void AddResources() {
            int random;
            for(int index = 0; index < tileCount; index++) {
                if (tiles[index].isWalkable) {
                    random = Rand.rand.Next(0, 50);
                    if (random == 0)
                        if (rand.Next(0, 2) == 1)
                            tiles[index].AddEntityToTile(new MaterialEntity(BaseEntity.Entity_Types.WOOD, tiles[index].position, 3, rand.Next(1, 4)));
                        else
                            tiles[index].AddEntityToTile(new MaterialEntity(BaseEntity.Entity_Types.STONE, tiles[index].position, 3, rand.Next(1, 4)));
                }
            }
        }

        /// <summary>
        /// Sets the sprites for all the tiles based on what the tile is
        /// </summary>
        private void SetSprites() {
            for (int i = 0; i < tileCount; i++) {
                if (tiles[i] is TileRiver) {
                    SetRiverTile(i);
                } else if (tiles[i] is TileLand) {
                    SetLandTile(i);
                }
            }
        }

        /// <summary>
        /// Sets the sprite for a land tile and adds resources
        /// </summary>
        /// <param name="index">The index of the tile in the array</param>
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

                tiles[index].sprite = sprite;
            }
        }

        /// <summary>
        /// Sets the sprite for a river and checks whether we want a bridge there
        /// </summary>
        /// <param name="index">The index of the tile</param>
        private void SetRiverTile(int index) {
            if (index >= 0 && index < tileCount) {
                int tilesPerRow = GameWorld.instance.gameWidth / BaseTile.tileWidth;

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

        /// <summary>
        /// Gets a list of the neighbours of the tile
        /// </summary>
        /// <param name="tile">The tile to check for</param>
        /// <returns>A list of neighbouring tiles</returns>
        public List<BaseTile> GetNeighbours(BaseTile tile) {
            List<BaseTile> list = new List<BaseTile>();
            if (tile.position.x >= BaseTile.tileWidth)
                list.Add(tiles[GetIndexOfTile(tile.position - new Vector2D(BaseTile.tileWidth, 0))]);
            if (tile.position.x < GameWorld.instance.gameWidth - BaseTile.tileWidth)
                list.Add(tiles[GetIndexOfTile(tile.position + new Vector2D(BaseTile.tileWidth, 0))]);

            if (tile.position.y >= BaseTile.tileHeight)
                list.Add(tiles[GetIndexOfTile(tile.position - new Vector2D(0, BaseTile.tileHeight))]);
            if (tile.position.y < GameWorld.instance.gameHeight - BaseTile.tileWidth)
                list.Add(tiles[GetIndexOfTile(tile.position + new Vector2D(0, BaseTile.tileHeight))]);

            return list;
        }

        /// <summary>
        /// Gets a list of all tiles, both diagonal and non-diagonal
        /// </summary>
        /// <param name="tile">The tile to check for</param>
        /// <returns>A list of all neighbouring tiles</returns>
        public List<BaseTile> GetAllNeighbours(BaseTile tile) {
            List<BaseTile> list = new List<BaseTile>();
            bool up = false, down = false, left = false, right = false;

            if (tile.position.x >= BaseTile.tileWidth)
                left = true;

            if (tile.position.x < GameWorld.instance.gameWidth - BaseTile.tileWidth)
                right = true;

            if (tile.position.y >= BaseTile.tileHeight)
                up = true;

            if (tile.position.y < GameWorld.instance.gameHeight - BaseTile.tileWidth)
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

        /// <summary>
        /// Gets a list of neighbours that allow an agent to walk to
        /// </summary>
        /// <param name="tile">The tile to check for</param>
        /// <returns>A list of walkable neighbours</returns>
        public List<BaseTile> GetWalkableNeighbours(BaseTile tile) {
            List<BaseTile> list = new List<BaseTile>();
            if (tile.position.x >= BaseTile.tileWidth) {
                BaseTile newTile = tiles[GetIndexOfTile(tile.position + new Vector2D(-BaseTile.tileWidth, 0))];
                if (newTile.isWalkable)
                    list.Add(newTile);
            }
            if (tile.position.x < GameWorld.instance.gameWidth - BaseTile.tileWidth) {
                BaseTile newTile = tiles[GetIndexOfTile(tile.position + new Vector2D(BaseTile.tileWidth, 0))];
                if (newTile.isWalkable)
                    list.Add(newTile);
            }

            if (tile.position.y >= BaseTile.tileHeight) {
                BaseTile newTile = tiles[GetIndexOfTile(tile.position + new Vector2D(0, -BaseTile.tileHeight))];
                if (newTile.isWalkable)
                    list.Add(newTile);
            }
            if (tile.position.y < GameWorld.instance.gameHeight - BaseTile.tileWidth) {
                BaseTile newTile = tiles[GetIndexOfTile(tile.position + new Vector2D(0, BaseTile.tileHeight))];
                if (newTile.isWalkable)
                    list.Add(newTile);
            }

            return list;
        }

        public List<BaseTile> GetAllWalkableNeighbours(BaseTile tile) {
            List<BaseTile> list = new List<BaseTile>();
            bool up = false, down = false, left = false, right = false;

            if (tile.position.x >= BaseTile.tileWidth)
                left = true;

            if (tile.position.x < GameWorld.instance.gameWidth - BaseTile.tileWidth)
                right = true;

            if (tile.position.y >= BaseTile.tileHeight)
                up = true;

            if (tile.position.y < GameWorld.instance.gameHeight - BaseTile.tileWidth)
                down = true;

            if (up) {
                BaseTile newTile = tiles[GetIndexOfTile(tile.position + new Vector2D(0, -BaseTile.tileHeight))];
                if (newTile.isWalkable)
                    list.Add(tiles[GetIndexOfTile(tile.position + new Vector2D(0, -BaseTile.tileHeight))]);

                if (left) {
                    newTile = tiles[GetIndexOfTile(tile.position + new Vector2D(-BaseTile.tileWidth, -BaseTile.tileHeight))];
                    if (newTile.isWalkable)
                        list.Add(tiles[GetIndexOfTile(tile.position + new Vector2D(-BaseTile.tileWidth, -BaseTile.tileHeight))]);
                }
                if (right) {
                    newTile = tiles[GetIndexOfTile(tile.position + new Vector2D(BaseTile.tileWidth, -BaseTile.tileHeight))];
                    if (newTile.isWalkable)
                        list.Add(tiles[GetIndexOfTile(tile.position + new Vector2D(BaseTile.tileWidth, -BaseTile.tileHeight))]);
                }
            }

            if (down) {
                BaseTile newTile = tiles[GetIndexOfTile(tile.position + new Vector2D(0, BaseTile.tileHeight))];
                if (newTile.isWalkable)
                    list.Add(tiles[GetIndexOfTile(tile.position + new Vector2D(0, BaseTile.tileHeight))]);

                if (left) {
                    newTile = tiles[GetIndexOfTile(tile.position + new Vector2D(-BaseTile.tileWidth, BaseTile.tileHeight))];
                    if (newTile.isWalkable)
                        list.Add(tiles[GetIndexOfTile(tile.position + new Vector2D(-BaseTile.tileWidth, BaseTile.tileHeight))]);
                }
                if (right) {
                    newTile = tiles[GetIndexOfTile(tile.position + new Vector2D(BaseTile.tileWidth, BaseTile.tileHeight))];
                    if (newTile.isWalkable)
                        list.Add(tiles[GetIndexOfTile(tile.position + new Vector2D(BaseTile.tileWidth, BaseTile.tileHeight))]);
                }
            }

            if (left) {
                BaseTile newTile = tiles[GetIndexOfTile(tile.position + new Vector2D(-BaseTile.tileWidth, 0))];
                if (newTile.isWalkable)
                    list.Add(tiles[GetIndexOfTile(tile.position + new Vector2D(-BaseTile.tileWidth, 0))]);
            }

            if (right) {
                BaseTile newTile = tiles[GetIndexOfTile(tile.position + new Vector2D(BaseTile.tileWidth, 0))];
                if (newTile.isWalkable)
                    list.Add(tiles[GetIndexOfTile(tile.position + new Vector2D(BaseTile.tileWidth, 0))]);
            }

            return list;
        }

        public List<BaseTile> GetWalkableDiagonalNeighbours(BaseTile tile) {
            List<BaseTile> list = new List<BaseTile>();

            bool up = false, down = false, left = false, right = false;

            if (tile.position.x >= BaseTile.tileWidth)
                left = true;

            if (tile.position.x < GameWorld.instance.gameWidth - BaseTile.tileWidth)
                right = true;

            if (tile.position.y >= BaseTile.tileHeight)
                up = true;

            if (tile.position.y < GameWorld.instance.gameHeight - BaseTile.tileWidth)
                down = true;

            if (up) {
                BaseTile newTile;

                if (left) {
                    newTile = tiles[GetIndexOfTile(tile.position + new Vector2D(-BaseTile.tileWidth, -BaseTile.tileHeight))];
                    if (newTile.isWalkable)
                        list.Add(tiles[GetIndexOfTile(tile.position + new Vector2D(-BaseTile.tileWidth, -BaseTile.tileHeight))]);
                }
                if (right) {
                    newTile = tiles[GetIndexOfTile(tile.position + new Vector2D(BaseTile.tileWidth, -BaseTile.tileHeight))];
                    if (newTile.isWalkable)
                        list.Add(tiles[GetIndexOfTile(tile.position + new Vector2D(BaseTile.tileWidth, -BaseTile.tileHeight))]);
                }
            }

            if (down) {
                BaseTile newTile;

                if (left) {
                    newTile = tiles[GetIndexOfTile(tile.position + new Vector2D(-BaseTile.tileWidth, BaseTile.tileHeight))];
                    if (newTile.isWalkable)
                        list.Add(tiles[GetIndexOfTile(tile.position + new Vector2D(-BaseTile.tileWidth, BaseTile.tileHeight))]);
                }
                if (right) {
                    newTile = tiles[GetIndexOfTile(tile.position + new Vector2D(BaseTile.tileWidth, BaseTile.tileHeight))];
                    if (newTile.isWalkable)
                        list.Add(tiles[GetIndexOfTile(tile.position + new Vector2D(BaseTile.tileWidth, BaseTile.tileHeight))]);
                }
            }


            return list;
        }

        /// <summary>
        /// Gets the index of a position
        /// </summary>
        /// <param name="pos">The position of the vector</param>
        /// <returns>The index this vector is in</returns>
        public static int GetIndexOfTile(Vector2D pos) {
            int tilesPerRow = GameWorld.instance.gameWidth / BaseTile.tileWidth;
            int index = (int)(pos.y / BaseTile.tileHeight) * tilesPerRow;
            index += (int)(pos.x / BaseTile.tileWidth);
            return index;
        }

        /// <summary>
        /// Draws all the tiles
        /// </summary>
        /// <param name="g"></param>
        public void Render(Graphics g) {
            for (int i = 0; i < tileCount; i++) {
                tiles[i].Render(g);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tiles"></param>
        public static void Prepare(BaseTile[] tiles) {
            if (tiles != null) {
                if (tiles.Count() > 0) {
                    foreach (BaseTile b in tiles) {
                        Vertex.ResetVertex(b.tileVertex);
                    }
                }
            }
        }
    }
}
