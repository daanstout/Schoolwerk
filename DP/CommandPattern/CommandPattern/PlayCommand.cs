using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern {
    public class PlayCommand : ICommand {
        public IMoviePlayer player;

        public void Execute() {
            player.PlayMovie();
        }

        public void UnDo() {
            player.PauzeMovie();
        }

        public void setPlayer(IMoviePlayer player) {
            this.player = player;
        }

        public PlayCommand() {
            player = new SamsungMoviePlayer();
        }
    }
}
