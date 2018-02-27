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
                g.DrawImage(tile.sprite, tile.position.x, tile.position.y);
        }
    }
}
