using ScrollingGame.Entity.Characters;
using ScrollingGame.Jump;
using ScrollingGame.Utils;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrollingGame.Items {
    public class DoubleJumpItem : AItem {
        private IJumpStrategy strategy;

        public override void onPickUp(Character c, float duration) {
            base.onPickUp(c, duration);
            if (strategy == null)
                strategy = c.jumpStrategy;
            c.jumpStrategy = new DoubleJump();
            if (c is Player p) {
                p.addItem = this;
            }
        }

        public override void onExpire(Character c) {
            Console.WriteLine("test");
            c.jumpStrategy = strategy;
        }

        public DoubleJumpItem(Vector2 location, int radius, Color color) {
            this.location = location;
            this.radius = radius;
            this.color = color;
        }

        public override void onUpdate() {
            if (location.X < Singleton.player.location.X + Singleton.player.size.X &&
                location.X + radius > Singleton.player.location.X &&
                location.Y < Singleton.player.location.Y + Singleton.player.size.Y &&
                location.Y + radius > Singleton.player.location.Y) {
                onPickUp(Singleton.player, 5);
            }
        }
    }
}
