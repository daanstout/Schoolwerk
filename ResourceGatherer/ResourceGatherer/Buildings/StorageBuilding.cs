using ResourceGatherer.Properties;
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
    public sealed class StorageBuilding : BaseBuilding{
        public StorageBuilding(Vector2D pos, Vector2D scale) : base(Building_Types.StorageBuilding, pos, scale) {
            sprite = Resources.StorageShed_01;

            entrancePosition = TileSystem.GetIndexOfTile(position + scale - new Vector2D(1, 1));
            //Console.WriteLine(entrancePosition);
            //entrancePosition = GameWorld.instance.tiles.tiles[TileSystem.GetIndexOfTile(position + scale)].position;
        }

        public override void Render(Graphics g) {
            if (sprite == null)
                Console.WriteLine();
            else
                g.DrawImage(sprite, new RectangleF(position, scale));
        }
    }
}
