using ResourceGatherer.Util;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceGatherer.Properties;
using System.Drawing;

namespace ResourceGatherer.World.Tiles {
    /// <summary>
    /// Creates a new river tile
    /// </summary>
    public sealed class TileRiver : BaseTile {
        /// <summary>
        /// If the current river has a bridge
        /// </summary>
        public bool hasBridge;
        /// <summary>
        /// If the bridge is horizontal
        /// </summary>
        public bool horizontalBridge;
        /// <summary>
        /// The sprite of the bridge
        /// </summary>
        public Bitmap bridgeSprite;

        /// <summary>
        /// Creates a new river tile
        /// </summary>
        /// <param name="pos">The position of the tile</param>
        public TileRiver(Vector2D pos) : base(pos) {
            isWalkable = allowDiagonal = false;
        }

        /// <summary>
        /// Adds a bridge to the tile
        /// </summary>
        /// <param name="horizontal">Whether the bridge is horizontal</param>
        public void AddBridge(bool horizontal) {
            horizontalBridge = horizontal;
            hasBridge = isWalkable = true;
        }

        /// <summary>
        /// Removes the bridge
        /// </summary>
        public void RemoveBridge() {
            hasBridge = isWalkable = false;
        }

        /// <summary>
        /// Sets the bridge sprite
        /// </summary>
        /// <param name="sprite">The sprite to be used</param>
        public void AddBridgeSprite(Bitmap sprite) {
            if (horizontalBridge)
                sprite.RotateFlip(RotateFlipType.Rotate90FlipNone);

            bridgeSprite = sprite;
        }
    }
}
