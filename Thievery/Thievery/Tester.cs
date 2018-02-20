using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thievery.Behaviours;
using Thievery.Utils;

namespace Thievery {
    public class Tester : ABase{
        private PointF location;
        private SizeF size;
        private int speed;

        private RectangleF rectangle {
            get {
                return new RectangleF(location, size);
            }
        }

        public Tester(PointF loc, SizeF sz, int spd) {
            location = loc;
            size = sz;
            speed = spd;
        }

        public override void Draw(Graphics e) {
            e.FillRectangle(new SolidBrush(Color.Red), rectangle);
        }

        public override void Update() {
            location.X += (float)(speed * Time.elapsedSeconds);
        }
    }
}
