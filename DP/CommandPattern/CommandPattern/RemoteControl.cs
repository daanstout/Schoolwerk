using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern {
    public class RemoteControl {
        public ICommand command;

        public void PressExecute() {
            command.Execute();
        }

        public void PressUnDo() {
            command.UnDo();
        }

        public RemoteControl() {
            command = new PlayCommand();
        }

        public void SetCommand(ICommand command) {
            this.command = command;
        }

        public void setPlayer(IMoviePlayer player) {
            command.setPlayer(player);
        }
    }
}
