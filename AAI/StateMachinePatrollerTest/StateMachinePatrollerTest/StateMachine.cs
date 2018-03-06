using System;
using System.Collections.Generic;
using System.Text;

namespace StateMachinePatrollerTest {
    public interface State {
        void Enter(Patroller owner);
        void Execute(Patroller owner);
        void Exit(Patroller owner);
    }

    public class Patrol : State {
        public void Enter(Patroller owner) {
            Console.WriteLine("Imma start watchin' me farm.");
        }

        public void Execute(Patroller owner) {
            Console.WriteLine("Nothin' suspicious a' me farm.");

            owner.strength++;

            if (new Random().Next(0, 7) == 0) {
                if (owner.strength > 10)
                    owner.ChangeState(Attack.instance);
                else
                    owner.ChangeState(Hide.instance);
            }
        }

        public void Exit(Patroller owner) {
            Console.WriteLine("Oi, get o' me farm!");
        }

        public static Patrol Instance = new Patrol();
    }

    public class Attack : State {
        public void Enter(Patroller owner) {
            Console.WriteLine("Prepare yar buttocks, son!!");
        }

        public void Execute(Patroller owner) {
            Console.WriteLine("Imma kick ya so hard, ya can't sit for a fortnigh'!!");

            owner.strength -= 2;

            if (owner.strength < 5)
                owner.ChangeState(Hide.instance);
        }

        public void Exit(Patroller owner) {
            Console.WriteLine("Oeh, me back!");
        }

        public static Attack instance = new Attack();
    }

    public class Hide : State {
        public void Enter(Patroller owner) {
            Console.WriteLine("Ya filthy rascal, if it wasn' for me back!!");
        }

        public void Execute(Patroller owner) {
            Console.WriteLine("Just ya wait, I'm smackin' ya on ya behind real soon!");

            owner.strength++;

            if (new Random().Next(0, 5) == 0)
                owner.ChangeState(Patrol.Instance);
            else if (owner.strength > 10)
                owner.ChangeState(Attack.instance);
        }

        public void Exit(Patroller owner) {
            Console.WriteLine("Stupid kids, finally got o' me farm.");
        }

        public static Hide instance = new Hide();
    }
}
