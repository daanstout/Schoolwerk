using MazeAlgorithms.Datastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeAlgorithms.Algorithms.Solving {
    public interface IGeneratingAlgorithm {
        void GenerateMaze(UpTree tree);
    }
}
