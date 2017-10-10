using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScrollingGame.Utils;

namespace ScrollingGame.Entity.Projectiles {
    public class Bullet : AProjectile {
        public Bullet(Vector2 direction, float movementSpeed, Vector2 location, Vector2 size, Color color, bool doTick, bool doDraw) : 
            base(direction, movementSpeed, location, size, color, doTick, doDraw) { }

        public override void onUpdate() {
            location += direction * movementSpeed * Time.deltaTimeSeconds;
        }

        public override void onDraw(Graphics g) {
            g.FillEllipse(new SolidBrush(color), new Rectangle(location, size));
        }
    }
}
