using MazeAlgorithms.Datastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeAlgorithms.Algorithms.Generating {
    public interface ISolvingAlgorithm {
        void SolveMaze(UpTree tree);
    }
}
