using ResourceGatherer.Util;
using ResourceGatherer.World;
using ResourceGatherer.World.Tiles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.Buildings {
    public abstract class BaseBuilding {
        public static readonly Building_Types default_building_type = Building_Types.default_building_type;

        public enum Building_Types {
            default_building_type = -1,

            StorageBuilding
        }

        private static int validId;
        private static int nextValidId {
            get {
                return ++validId;
            }
        }

        public readonly int buildingId;
        public Building_Types buildingType;

        public Vector2D position;
        public Vector2D scale;

        public Bitmap sprite;

        public int currentGrid;

        public int entrancePosition { get; protected set; }

        protected BaseBuilding() {
            buildingId = nextValidId;
            buildingType = default_building_type;
            position = new Vector2D();
            scale = new Vector2D(1, 1);
        }

        protected BaseBuilding(Building_Types type) {
            buildingId = nextValidId;
            buildingType = type;
            position = new Vector2D();
            scale = new Vector2D(1, 1);
        }

        protected BaseBuilding(Building_Types type, Vector2D pos, Vector2D scale) {
            buildingId = nextValidId;
            buildingType = type;
            position = pos;
            this.scale = scale;

            SetTiles();
        }

        private void SetTiles() {
            GameWorld world = GameWorld.instance;
            for(int i = TileSystem.GetIndexOfTile(position); i < TileSystem.GetIndexOfTile(position + new Vector2D(0, scale.y)); i += world.tiles.tilesPerRow) {
                for(int j = 0; j < scale.x / BaseTile.tileWidth; j++) {
                    world.tiles.tiles[i + j].isWalkable = false;
                }
            }
        }

        public virtual void Render(Graphics g) { }

        public void SetEntranceEdge() {
            GameWorld.instance.tiles.tiles[entrancePosition].isWalkable = true;
            GameWorld.instance.tiles.tiles[entrancePosition].CreateTileVertex();
            GameWorld.instance.graph.AddEdge(GameWorld.instance.tiles.tiles[entrancePosition], GameWorld.instance.tiles.tiles[entrancePosition + GameWorld.instance.tiles.tilesPerRow], 1);
        }
    }
}
