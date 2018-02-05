using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamiltyAtTheBridge {
    public class SolveBridge {
        readonly int lampTime = 30;
        //bool lampCrossed;
        //int timeSpent = 0;
        //Person[] family;

        public SolveBridge() {
            //family = new Person[5] { new Person(1), new Person(3), new Person(6), new Person(8), new Person(12) };
        }

        public void Solve() {
            //Solve("", new Person[5] { new Person(1), new Person(3), new Person(6), new Person(8), new Person(12) }, 0, false);
            List<int> ints = GetAllMoves(new Person[5] { new Person(1), new Person(3), new Person(6), new Person(8), new Person(12) }, 0, false);
            foreach (int i in ints)
                Console.WriteLine(i);
        }

        private void Solve(string solution, Person[] family, int timeSpent, bool lampCrossed) {
            if (IsSolved(family))
                PrintSolution(solution);

            List<int> moves = GetAllMoves(family, timeSpent, lampCrossed);

            foreach(int move in moves) {
                if (lampCrossed) {
                    switch (move) {
                        case 1:
                            family[0].crossed = true;
                            solution += "--> person@speed" + family[0].speed + "\n";
                            Solve(solution, family, timeSpent + family[0].speed, !lampCrossed);
                            break;
                        case 2:
                            break;
                        case 4:
                            break;
                        case 8:
                            break;
                        case 16:
                            break;
                    }
                }
            }
        }

        private void PrintSolution(string solution) {
            Console.WriteLine(solution);
        }

        private bool IsSolved(Person[] family) {
            foreach (Person p in family)
                if (!p.crossed)
                    return false;
            return true;
        }

        private List<int> GetAllMoves(Person[] family, int timeSpent, bool lampCrossed) {
            if (lampCrossed)
                return GetAllReturnMoves(family, timeSpent, lampCrossed);
            else
                return GetAllCrossMoves(family, timeSpent, lampCrossed);
        }

        private List<int> GetAllCrossMoves(Person[] family, int timeSpent, bool lampCrossed) {
            List<int> crossings = new List<int>();
            for (int i = 0; i < 5; i++) {
                if (family[i].crossed)
                    continue;
                for (int j = i + 1; j < 5; j++) {
                    if (family[j].crossed)
                        continue;
                    Console.WriteLine(i + " - " + j);
                    if (timeSpent + family[j].speed < lampTime) {
                        int toAdd = (1 << i) + (1 << j);
                        crossings.Add(toAdd);
                    }
                }
            }
            return crossings;
        }

        private List<int> GetAllReturnMoves(Person[] family, int timeSpent, bool lampCrossed) {
            List<int> crossings = new List<int>();
            for (int i = 0; i < 5; i++) {
                if (!family[i].crossed)
                    continue;
                if (timeSpent + family[i].speed < lampTime)
                    crossings.Add(1 << i);
            }
            return crossings;
        }
    }
}
