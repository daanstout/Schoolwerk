using System;
using System.Threading;

namespace StateMachinePatrollerTest {
    class Program {
        static void Main(string[] args) {
            Patroller p = new Patroller();

            while (true) {
                p.Update();

                Thread.Sleep(2000);
            }
        }
    }

    public class Patroller {
        public int strength;
        private State state;

        public Patroller() {
            strength = 10;
            state = Patrol.Instance;

            Console.WriteLine("I'm ol' man Greg an this' me farm. Now get off it!\n");
        }

        public void Update() {
            state.Execute(this);
        }

        public void ChangeState(State state) {
            Thread.Sleep(500);
            this.state.Exit(this);
            this.state = state;
            Thread.Sleep(1000);
            this.state.Enter(this);
        }
    }
}
