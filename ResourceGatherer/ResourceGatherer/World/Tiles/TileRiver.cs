using ResourceGatherer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceGatherer.Properties;
using System.Drawing;

namespace ResourceGatherer.World.Tiles {
    public class TileRiver : BaseTile {
        public bool hasBridge;
        public bool horizontalBridge;
        public Bitmap bridgeSprite;

        public TileRiver(Vector2D pos) : base(pos) {
            isWalkable = false;
        }

        public void AddBridge(bool horizontal) {
            horizontalBridge = horizontal;
            hasBridge = isWalkable = true;
        }

        public void RemoveBridge() {
            hasBridge = isWalkable = false;
        }

        public void AddBridgeSprite(Bitmap sprite) {
            if (horizontalBridge)
                sprite.RotateFlip(RotateFlipType.Rotate90FlipNone);

            bridgeSprite = sprite;
        }
    }
}
