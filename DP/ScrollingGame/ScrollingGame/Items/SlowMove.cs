using ScrollingGame.Move;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScrollingGame.Entity.Characters;
using ScrollingGame.Utils;
using System.Drawing;

namespace ScrollingGame.Items {
    public class SlowMove : AItem{
        private IMoveStrategy defaultStrategy;

        public override void onPickUp(Character c, float duration) {
            base.onPickUp(c, duration);
            if (defaultStrategy == null)
                defaultStrategy = c.moveStrategy;
            c.moveStrategy = new SlowMoveHalf();
            if (c is Player p)
                p.addItem = this;
        }

        public override void onExpire(Character c) {
            c.moveStrategy = defaultStrategy;
        }

        public SlowMove(Vector2 location, int radius, Color color, bool doTick, bool doDraw) : base(doTick, doDraw) {
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

        public override void onLoad() {
            itemName = "Wither";
        }
    }
}
