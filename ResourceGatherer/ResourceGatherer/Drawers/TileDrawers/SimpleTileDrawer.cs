using ResourceGatherer.Entities.StaticEntities;
using ResourceGatherer.World.Tiles;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.Drawers.TileDrawers {
    /// <summary>
    /// Simply draws the tile, along with a bridge if it is a river and has a bridge and every entity on the tile
    /// </summary>
    public class SimpleTileDrawer : ITileDrawer{
        /// <summary>
        /// Draws the tile
        /// </summary>
        /// <param name="g">The graphics instance</param>
        /// <param name="tile">The tile to be drawn</param>
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
                foreach(MaterialEntity m in tile.entityList) {
                    if (m.sprite == null)
                        Console.WriteLine();
                    else {
                        g.DrawImage(m.sprite, m.position.x, m.position.y, BaseTile.tileWidth, BaseTile.tileHeight);
                    }
                }
            }
        }
    }
}
