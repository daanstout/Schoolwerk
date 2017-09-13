using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrollingGame.Entity {
    public interface IBehaviour {
        void onLoad();
        void onUpdate(long delta);
        void onPause();
        void onResume();
        void onDraw(Graphics g);
    }
}
