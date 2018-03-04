﻿using ResourceGatherer.Entities;
using ResourceGatherer.Util;
using ResourceGatherer.World.Tiles;
using ResourceGatherer.World.Graphs;
using ResourceGatherer.Entities.MovingEntities;
using ResourceGatherer.Entities.StaticEntities;
using ResourceGatherer.Properties;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ResourceGatherer.World {
    public class GameWorld {
        public readonly int gameWidth;
        public readonly int gameHeight;

        public BaseTile[] tiles;
        private int tileCount;
        private Graph graph;

        private Random rand;

        private List<BaseEntity> _entites;
        private List<BaseEntity> entites {
            get {
                if (_entites == null)
                    _entites = new List<BaseEntity>();
                return _entites;
            }
        }

        private Time time;

        public GameWorld(int width, int height) {
            gameWidth = width;
            gameHeight = height;

            rand = new Random();
            time = new Time();
            FriendlyNPC npc = new FriendlyNPC(new Vector2D(20, 100),
                                                20,
                                                new Vector2D(0, 0),
                                                10,
                                                new Vector2D(0, 0),
                                                1,
                                                new Vector2D(15, 15),
                                                10,
                                                10);

            entites.Add(npc);

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
            graph = new Graph(this);

            for (int i = 0; i < tileCount; i++)
                tiles[i].DestroyTileVertex();

            for (int i = 0; i < tileCount; i++) {
                if (tiles[i].isWalkable && tiles[i].tileVertex == null) {
                    graph.CreateGraph(tiles[i]);
                }
            }
        }

        public void Update() {
            time.Update();

            Console.WriteLine(1 / Time.deltaTimeSeconds);

            if (_entites != null)
                for (int i = 0; i < entites.Count; i++)
                    entites[i].Update(Time.deltaTimeSeconds);
        }

        public void Draw(Graphics g) {
            if (_entites != null)
                for (int i = 0; i < entites.Count; i++)
                    entites[i].Render(g);
        }

        public void GetBackground(Graphics g) {
            for (int i = 0; i < tileCount; i++) {
                tiles[i].Render(g);
            }
        }
    }
}
