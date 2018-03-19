using ResourceGatherer.World.Tiles;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.Drawers.TileDrawers {
    /// <summary>
    /// The TileDrawer interface, used for tile drawers
    /// </summary>
    public interface ITileDrawer {
        /// <summary>
        /// Draws the tile
        /// </summary>
        /// <param name="g">The graphics instance</param>
        /// <param name="tile">The tile to be drawn</param>
        void Draw(Graphics g, BaseTile tile);
    }
}
