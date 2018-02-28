using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceGatherer.Util;

namespace ResourceGatherer.World.Tiles {
    public class TileLand : BaseTile {
        public TileLand(Vector2D pos) : base(pos) {
            isWalkable = true;
        }
    }
}
