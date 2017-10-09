using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrollingGame.Utils{
    public interface IBehaviour {
        bool doDraw { get; set; }
        bool doTick { get; set; }

        void onLoad();
        void onUpdate();
        void onPause();
        void onResume();
        void onDraw(Graphics g);
        void onDestroy();
    }
}
