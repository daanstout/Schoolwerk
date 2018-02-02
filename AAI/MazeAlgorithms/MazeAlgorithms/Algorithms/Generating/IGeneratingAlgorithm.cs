using MazeAlgorithms.Datastructures;
using MazeAlgorithms.MazeMain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeAlgorithms.Algorithms.Generating {
    public interface IGeneratingAlgorithm : IAlgorithm {
        void GenerateMaze(Maze maze);
    }
}
