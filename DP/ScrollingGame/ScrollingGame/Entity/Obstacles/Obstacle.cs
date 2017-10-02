using ScrollingGame.Utils;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrollingGame.Entity.Obstacles {
    public class Obstacle : EntityBase{
        public Obstacle(Vector2 location, Vector2 size, Color color, bool doTick, bool doDraw) : base(location, size, color, doTick, doDraw) {

        }
    }
}
