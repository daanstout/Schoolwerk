using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQueens {
    class Program {
        static void Main(string[] args) {
            NQueens board = new NQueens(5);

            Stopwatch sw = new Stopwatch();
            sw.Start();

            board.SolveBacktracking();

            sw.Stop();

            Console.WriteLine(sw.ElapsedMilliseconds);

            Console.ReadKey();
        }
    }
}
