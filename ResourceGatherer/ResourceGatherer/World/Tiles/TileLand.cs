using ResourceGatherer.Util;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.World.Tiles {
    /// <summary>
    /// A land tile
    /// </summary>
    public sealed class TileLand : BaseTile {
        /// <summary>
        /// Creates a new land tile
        /// </summary>
        /// <param name="pos">The position of the tile</param>
        public TileLand(Vector2D pos) : base(pos) {
            isWalkable = allowDiagonal = true;
        }
    }
}
