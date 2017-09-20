using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrollingGame.Utils {
    public static class Fonts {
        public static SolidBrush getSolidBrush(Color color) => new SolidBrush(color);
        public static Pen getPen(Color color) => new Pen(color);

        public static Font getFont(string fontName, int fontSize) => new Font(fontName, fontSize);
    }
}
