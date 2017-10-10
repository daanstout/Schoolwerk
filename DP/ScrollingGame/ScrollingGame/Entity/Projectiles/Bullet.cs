using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScrollingGame.Utils;
using ScrollingGame.Entity.Characters;

namespace ScrollingGame.Entity.Projectiles {
    public class Bullet : AProjectile {
        public Bullet(Vector2 direction, float movementSpeed, Vector2 location, Vector2 size, Color color, bool doTick, bool doDraw) : 
            base(direction, movementSpeed, location, size, color, doTick, doDraw) { }

        public override void onUpdate() {
            location += direction * movementSpeed * Time.deltaTimeSeconds;
            if(location.X < Singleton.player.location.X + Singleton.player.size.X && location.X + size.X > Singleton.player.location.X && location.Y < Singleton.player.location.Y + Singleton.player.size.Y && location.Y + size.Y > Singleton.player.location.Y) {
                Singleton.player.damagePlayer = 10;
                Singleton.unsubscribeFromTick = this;
            }
        }

        public override void onDraw(Graphics g) {
            g.FillEllipse(new SolidBrush(color), new Rectangle(location, size));
        }
    }
}
