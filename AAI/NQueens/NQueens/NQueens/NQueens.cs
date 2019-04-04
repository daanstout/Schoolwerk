using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQueens {
    internal class NQueens {
        private bool[][] queens;
        private readonly int n;

        public bool ShowSolutions { get; set; }

        // initializes the board
        public NQueens(int n) {
            queens = new bool[n][];
            for (int i = 0; i < n; i++) {
                queens[i] = new bool[n];
            }
            this.n = n;
        }

        // driver method
        public void SolveBacktracking() => solveBacktracking(0);

        private void solveBacktracking(int row) {
            for (int i = 0; i < n; i++) {
                queens[row][i] = true;
                if (checkBoard())
                    if (countQueens() == n)
                        Print();
                    else if (row < n)
                        solveBacktracking(row + 1);

                queens[row][i] = false;
            }
        }

        /********** Helper methods **********/

        // counts the total number of queens on the board
        private int countQueens() => queens.Sum(line => line.Count(q => q));

        // check if there is no conflicting situation on the board
        private bool checkBoard() {
            // iterate through all rows
            for (int r = 0; r < n; r++) {
                int queenCol = -1;
                int nrOfQueens = 0;

                // check horizontally
                for (int c = 0; c < n; c++) {
                    if (queens[r][c]) {
                        nrOfQueens++;
                        queenCol = c;
                    }
                    if (nrOfQueens > 1)
                        return false;
                    if (nrOfQueens > 0) {
                        // check column
                        for (int qr = r + 1; qr < n; qr++) //start from next row
                        {
                            if (queens[qr][queenCol])
                                return false; // there is another queen on this column
                        }

                        // check diagonal -> r
                        int dc = queenCol + 1;
                        for (int qr = r + 1; qr < n && dc < n; qr++) //start from next row
                        {
                            if (queens[qr][dc])
                                return false; // there is another queen on this column
                            dc++;
                        }
                        // check diagonal -> l
                        dc = queenCol - 1;
                        for (int qr = r + 1; qr < n && dc >= 0; qr++) //start from next row
                        {
                            if (queens[qr][dc])
                                return false; // there is another queen on this column
                            dc--;
                        }
                    }
                }
            }
            return true;
        }

        public void Print() {
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                    string s = queens[i][j] ? "Q" : "-";
                    Console.Write(s);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
