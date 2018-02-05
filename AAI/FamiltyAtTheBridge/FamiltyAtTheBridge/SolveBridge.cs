using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamiltyAtTheBridge {
    public class SolveBridge {
        readonly int lampTime = 30;

        public SolveBridge() { }

        public void Solve() {
            Solve("", new Person[5] { new Person(1), new Person(3), new Person(6), new Person(8), new Person(12) }, 0, false, 0);
        }

        private void Solve(string solution, Person[] family, int timeSpent, bool lampCrossed, int steps) {
            if (IsSolved(family)) {
                PrintSolution(solution, timeSpent, steps);
                return;
            }

            List<int> moves = GetAllMoves(family, timeSpent, lampCrossed);

            foreach (int move in moves) {
                if (lampCrossed) {
                    int p = 0;
                    switch (move) {
                        case 1:
                            p = 0;
                            break;
                        case 2:
                            p = 1;
                            break;
                        case 4:
                            p = 2;
                            break;
                        case 8:
                            p = 3;
                            break;
                        case 16:
                            p = 4;
                            break;
                        default:
                            continue;
                    }
                    family[p].crossed = false;
                    Solve(solution + "--> person@speed" + family[p].speed + "\n", family, timeSpent + family[p].speed, !lampCrossed, steps + 1);
                    family[p].crossed = true;
                } else {
                    int p1 = 0;
                    int p2 = 0;
                    switch (move) {
                        case 3:
                            p1 = 0;
                            p2 = 1;
                            break;
                        case 5:
                            p1 = 0;
                            p2 = 2;
                            break;
                        case 6:
                            p1 = 1;
                            p2 = 2;
                            break;
                        case 9:
                            p1 = 0;
                            p2 = 3;
                            break;
                        case 10:
                            p1 = 1;
                            p2 = 3;
                            break;
                        case 12:
                            p1 = 2;
                            p2 = 3;
                            break;
                        case 17:
                            p1 = 0;
                            p2 = 4;
                            break;
                        case 18:
                            p1 = 1;
                            p2 = 4;
                            break;
                        case 20:
                            p1 = 2;
                            p2 = 4;
                            break;
                        case 24:
                            p1 = 3;
                            p2 = 4;
                            break;
                        default:
                            continue;
                    }
                    family[p1].crossed = family[p2].crossed = true;
                    Solve(solution + "<-- person@speed" + family[p1].speed + " + person@speed" + family[p2].speed + "\n", family, timeSpent + family[p2].speed, !lampCrossed, steps + 1);
                    family[p1].crossed = family[p2].crossed = false;
                }
            }
        }

        private void PrintSolution(string solution, int timeSpent, int steps) {
            Console.WriteLine(solution + "Solution in " + steps + " steps using " + timeSpent + " lamp energy.\n\n");
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
                    if (timeSpent + family[j].speed <= lampTime) {
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
                if (timeSpent + family[i].speed <= lampTime)
                    crossings.Add(1 << i);
            }
            return crossings;
        }
    }
}
