using ScrollingGame.Utils;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrollingGame.Utils {
    public abstract class ABehaviour : IBehaviour {
        private bool _doDraw;
        private bool _doTick;

        public bool doDraw { get => _doDraw; set => _doDraw = value; }
        public bool doTick { get => _doTick; set => _doTick = value; }

        public virtual void onDraw(Graphics g) { }

        public virtual void onLoad() { }

        public virtual void onPause() { }

        public virtual void onResume() { }

        public virtual void onUpdate() { }

        public virtual void onDestroy() { }
    }
}
