using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrollingGame.Utils{
    public interface IBehaviour {
        void onLoad();
        void onUpdate();
        void onPause();
        void onResume();
        void onDraw(Graphics g);
        void onDestroy();
    }
}
