using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADToets.Opgave3 {
    public class Wereld : IWereld {
        bool[,] locaties;
        int[,] afstand;

        int hoogte;
        int breedte;

        public Wereld(int hoogte, int breedte) {
            this.hoogte = hoogte;
            this.breedte = breedte;

            locaties = new bool[this.hoogte, this.breedte];
            afstand = new int[this.hoogte, this.breedte];

            for (int i = 0; i < this.hoogte; i++)
                for (int j = 0; j < this.breedte; j++) {
                    locaties[i, j] = true;
                    afstand[i, j] = int.MaxValue;
                }

        }

        public void MaakMuur(int row, int col) {
            locaties[row, col] = false;
        }

        public void MaakOpenPlek(int row, int col) {
            locaties[row, col] = true;
        }

        public void Print() {
            Console.WriteLine(this.ToString());
        }

        public override string ToString() {
            string returnString = "";

            for (int i = 0; i < hoogte; i++) {
                for (int j = 0; j < breedte; j++) {
                    if (locaties[i, j])
                        returnString += ".";
                    else
                        returnString += "#";
                }
                returnString += "\n";
            }

            return returnString;
        }

        public void KortstePad(int rij_start, int kol_start) {
            if (rij_start < 0 || rij_start >= hoogte || kol_start < 0 || kol_start >= breedte)
                return;

            if (!locaties[rij_start, kol_start])
                return;

            resetAfstand();

            afstand[rij_start, kol_start] = 0;

            if (rij_start >= 1)
                KortstePad(rij_start - 1, kol_start, 1);

            if (kol_start >= 1)
                KortstePad(rij_start, kol_start - 1, 1);

            if (rij_start + 1 <= hoogte)
                KortstePad(rij_start + 1, kol_start, 1);

            if (kol_start + 1 <= breedte)
                KortstePad(rij_start, kol_start + 1, 1);

        }

        private void KortstePad(int rij_start, int kol_start, int currentDistance) {
            if (rij_start < 0 || rij_start >= hoogte || kol_start < 0 || kol_start >= breedte)
                return;

            if (!locaties[rij_start, kol_start])
                return;

            if (afstand[rij_start, kol_start] > currentDistance) {
                afstand[rij_start, kol_start] = currentDistance;

                if (rij_start >= 1)
                    KortstePad(rij_start - 1, kol_start, currentDistance + 1);

                if (kol_start >= 1)
                    KortstePad(rij_start, kol_start - 1, currentDistance + 1);

                if (rij_start + 1 <= hoogte)
                    KortstePad(rij_start + 1, kol_start, currentDistance + 1);

                if (kol_start + 1 <= breedte)
                    KortstePad(rij_start, kol_start + 1, currentDistance + 1);
            }
        }

        private void resetAfstand() {
            for (int i = 0; i < hoogte; i++)
                for (int j = 0; j < breedte; j++)
                    afstand[i, j] = int.MaxValue;
        }

        public void PrintMetAfstand() {
            string printString = "";

            for (int i = 0; i < hoogte; i++) {
                for (int j = 0; j < breedte; j++) {
                    if (locaties[i, j]) {
                        if (afstand[i, j] != int.MaxValue)
                            printString += afstand[i, j];
                        else
                            printString += ".";
                    } else
                        printString += "#";
                }
                printString += "\n";
            }

            Console.WriteLine(printString);
        }

        public Graph ConverteerNaarGraaf() {
            Graph g = new Graph();

            for (int i = 0; i < hoogte; i++) {
                for (int j = 0; j < breedte; j++) {
                    if (!locaties[i, j])
                        continue;

                    g.addVertex(getVertexName(i, j));

                    if (i > 0)
                        if (locaties[i - 1, j])
                            g.AddEdge(getVertexName(i, j), getVertexName(i - 1, j), 1);

                    if (i + 2 <= hoogte)
                        if (locaties[i + 1, j])
                            g.AddEdge(getVertexName(i, j), getVertexName(i + 1, j), 1);

                    if (j > 0)
                        if (locaties[i, j - 1])
                            g.AddEdge(getVertexName(i, j), getVertexName(i, j - 1), 1);

                    if (j + 2 <= breedte)
                        if (locaties[i, j + 1])
                            g.AddEdge(getVertexName(i, j), getVertexName(i, j + 1), 1);
                }
            }
            return g;
        }

        private string getVertexName(int row, int col) {
            return String.Format("Vertex{rij={0},kolom={1}}", row, col);
        }
    }
}
