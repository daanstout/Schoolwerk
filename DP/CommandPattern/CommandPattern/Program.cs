using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern {
    class Program {
        static void Main(string[] args) {
            char playCommand = 'o';
            char pauzeCommand = 'p';
            char samsung = 'g';
            char sony = 'y';
            char execute = 'e';
            char undo = 'u';
            char stop = 's';

            RemoteControl control = new RemoteControl();

            char input = Console.ReadKey().KeyChar;

            while (input != stop) {
                if (input == playCommand)
                    control.SetCommand(new PlayCommand());
                else if (input == pauzeCommand)
                    control.SetCommand(new PauzeCommand());
                else if (input == execute)
                    control.PressExecute();
                else if (input == undo)
                    control.PressUnDo();
                else if (input == sony)
                    control.setPlayer(new SonyMoviePlayer());
                else if (input == samsung)
                    control.setPlayer(new SamsungMoviePlayer());

                input = Console.ReadKey().KeyChar;
            }


            Console.WriteLine("Now stopping");


            Console.ReadKey();
        }
    }
}
