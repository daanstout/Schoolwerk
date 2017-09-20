using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern {
    class PauzeCommand : ICommand {
        public IMoviePlayer player;

        public void Execute() {
            player.PauzeMovie();
        }

        public void UnDo() {
            player.PlayMovie();
        }

        public void setPlayer(IMoviePlayer player) {
            this.player = player;
        }

        public PauzeCommand() {
            player = new SamsungMoviePlayer();
        }
    }
}
