using ScrollingGame.Entity;
using ScrollingGame.Entity.Characters;
using ScrollingGame.Utils;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ScrollingGame.Items {
    public abstract class AItem : ABehaviour, IItem {
        public Vector2 location;
        public int radius;
        public Color color;
        public string itemName;

        public float remainingDuration;

        public AItem(bool doTick, bool doDraw) {
            this.doTick = doTick;
            this.doDraw = doDraw;
        }

        private Rectangle rectangle {
            get {
                return new Rectangle(location - new Vector2(Singleton.gameXLocation, 0), new Size(radius * 2, radius * 2));
            }
        }

        public override void onDraw(Graphics g) {
            g.FillEllipse(Fonts.getSolidBrush(color), rectangle);
        }

        public virtual void onExpire(Character c) { }

        public virtual void onPickUp(Character c, float duration) {
            remainingDuration = duration;
            Singleton.unsubscribeFromTick = this;
        }
    }
}
