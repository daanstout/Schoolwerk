using ResourceGatherer.Entities;
using ResourceGatherer.World.Tiles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.Drawers.TileDrawers {
    public class SimpleTileDrawer : ITileDrawer{
        public void Draw(Graphics g, BaseTile tile) {
            if (tile.sprite == null)
                g.DrawRectangle(new Pen(Color.Black, 1), tile.position.x, tile.position.y, BaseTile.tileWidth - 1, BaseTile.tileHeight - 1);
            else
                g.DrawImage(tile.sprite, tile.position.x, tile.position.y, BaseTile.tileWidth, BaseTile.tileHeight);

            if (tile is TileRiver r) {
                if (r.hasBridge) {
                    if (r.bridgeSprite == null)
                        Console.WriteLine();
                    else
                        g.DrawImage(r.bridgeSprite, r.position.x, r.position.y, BaseTile.tileWidth, BaseTile.tileHeight);
                }
            }

            if(tile.entityCount > 0) {
                foreach(StaticEntity e in tile.entityList) {
                    if (e.sprite == null)
                        Console.WriteLine();
                    else
                        g.DrawImage(e.sprite, e.position.x, e.position.y, BaseTile.tileWidth, BaseTile.tileHeight);
                }
            }
        }
    }
}
