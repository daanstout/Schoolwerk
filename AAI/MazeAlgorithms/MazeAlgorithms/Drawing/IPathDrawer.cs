using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeAlgorithms.Drawing {
    public interface IPathDrawer {
        void Draw(Graphics g, int a, int b, int width, int length, Color color);
    }
}
