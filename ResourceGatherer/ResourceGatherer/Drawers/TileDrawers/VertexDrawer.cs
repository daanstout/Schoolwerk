using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceGatherer.World.Graphs;
using ResourceGatherer.World.Tiles;

namespace ResourceGatherer.Drawers.TileDrawers {
    public class VertexDrawer : ITileDrawer {
        public void Draw(Graphics g, BaseTile tile) {
            new SimpleTileDrawer().Draw(g, tile);

            if (tile.tileVertex == null)
                return;
            else {
                g.FillEllipse(new SolidBrush(Color.Red), tile.vertexRectangle);
                if(tile.tileVertex.adj != null) {
                    PointF a, b;
                    a = new PointF(tile.position.x + BaseTile.tileWidth / 2, tile.position.y + BaseTile.tileHeight / 2);
                    foreach(Edge e in tile.tileVertex.adj) {
                        b = new PointF(e.destination.parentTile.position.x + BaseTile.tileWidth / 2, e.destination.parentTile.position.y + BaseTile.tileWidth / 2);
                        g.DrawLine(new Pen(Color.Red, 1), a, b);
                    }
                }
            }
        }
    }
}
