using ScrollingGame.Utils;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrollingGame.Entity.Obstacles {
    public class Obstacle : Entity{


        public Obstacle(Vector2 location, Vector2 size, Color color, bool tickable) : base(location, size, color, tickable) {

        }
    }
}
