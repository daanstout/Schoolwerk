using ResourceGatherer.World.Graphs;
using ResourceGatherer.World.Tiles;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.Drawers.TileDrawers {
    /// <summary>
    /// Draws tiles including their verteces
    /// </summary>
    public class VertexDrawer : ITileDrawer {
        /// <summary>
        /// Draws the tile
        /// </summary>
        /// <param name="g">The graphics instance</param>
        /// <param name="tile">The tile to be drawn</param>
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
