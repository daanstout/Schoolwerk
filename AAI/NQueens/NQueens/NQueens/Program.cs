using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQueens {
    class Program {
        static void Main(string[] args) {
            NQueens board = new NQueens(4);

            board.SolveBacktracking();

            board = new NQueens(5);

            board.SolveBacktracking();

            Console.ReadKey();
        }
    }
}
