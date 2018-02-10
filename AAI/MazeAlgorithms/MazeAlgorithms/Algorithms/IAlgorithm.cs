using MazeAlgorithms.Datastructures;
using MazeAlgorithms.MazeMain;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeAlgorithms.Algorithms {
    public interface IAlgorithm {
        void Draw(Graphics g, Maze maze);
        int GetIterations();
        string GetAbout();
    }
}
