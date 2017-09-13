using ScrollingGame.Utils;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrollingGame.Entity {
    public class ABehaviour : IBehaviour {
        public bool tickable = true;

        public virtual void onDraw(Graphics g) {}

        public virtual void onLoad() {
            Console.WriteLine("adding");
            if (tickable)
                Singleton.subscribeToTick = this;
        }

        public virtual void onPause() {}

        public virtual void onResume() {}

        public virtual void onUpdate(long delta) { }
    }
}
