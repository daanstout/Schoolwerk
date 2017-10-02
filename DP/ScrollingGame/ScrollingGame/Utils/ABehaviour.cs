using ScrollingGame.Utils;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrollingGame.Utils {
    public abstract class ABehaviour : IBehaviour {
        public bool doTick = true;
        public bool doDraw = true;

        public virtual void onDraw(Graphics g) { }

        public virtual void onLoad() { }

        public virtual void onPause() { }

        public virtual void onResume() { }

        public virtual void onUpdate() { }

        public virtual void onDestroy() { }
    }
}
