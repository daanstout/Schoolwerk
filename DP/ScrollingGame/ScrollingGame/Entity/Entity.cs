using ScrollingGame.Jump;
using ScrollingGame.Move;
using ScrollingGame.Utils;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ScrollingGame.Entity {
    public class EntityBase : ABehaviour{
        public Vector2 location;
        public Vector2 size;

        public float entityMass;
        public float fallSpeed = 0;

        protected Rectangle rectangle {
            get {
                return new Rectangle(location, size);
            }
        }

        public Color color;

        public EntityBase(Vector2 location, Vector2 size, Color color, bool tickable) {
            this.location = location;
            this.size = size;
            this.color = color;
            this.tickable = tickable;
        }

        public override void onLoad() {
            base.onLoad();
        }

        public override void onDraw(Graphics g) {
            g.FillRectangle(Fonts.getSolidBrush(color), rectangle);
        }

        public override void onUpdate(long delta) {
            base.onUpdate(delta);
            //moveStrategy.Move();
        }
    }
}
