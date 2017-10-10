using ScrollingGame.Utils;
using ScrollingGame.Entity.Projectiles;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrollingGame.Entity.Characters.NPC {
    public class Shooter : Character {
        private readonly float interval;
        private float currentInterval; 

        public Shooter(Vector2 location, Vector2 size, Color color, bool doTick, bool doDraw, float interval) : base(location, size, color, doTick, doDraw) {
            this.interval = interval;
        }

        public override void onLoad() {
            base.onLoad();
            currentInterval = interval;
        }

        public override void onUpdate() {
            base.onUpdate();
            currentInterval -= Time.deltaTimeSeconds;
            if(currentInterval <= 0) {
                Singleton.loadNewBehaviour = new Bullet(Vector2.Left, 50, new Vector2(location.X, location.Y + (size.Y / 2)), new Vector2(5, 5), Color.Black, true, true);
                currentInterval = interval;
            }
        }
    }
}
