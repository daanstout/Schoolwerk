using MazeAlgorithms.Datastructures;
using MazeAlgorithms.MazeMain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeAlgorithms.Algorithms.Solving {
    public interface ISolvingAlgorithm : IAlgorithm{
        void SolveMaze(Maze maze);
        void reset();
        void UpdateDrawMethod(bool distanceMethod);
    }
}
