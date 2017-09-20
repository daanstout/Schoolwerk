using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern {
    public class SonyMoviePlayer : IMoviePlayer {
        bool isPlaying = false;

        public void PauzeMovie() {
            if (isPlaying) {
                Console.WriteLine("\nNow pausing the movie. Brought to you by Sony");
                isPlaying = false;
            }
        }

        public void PlayMovie() {
            if (!isPlaying) {
                Console.WriteLine("\nNow playing the movie. Brought to you by Sony");
                isPlaying = true;
            }
        }

        public void StopMovie() {
            Console.WriteLine("\nNow stopping the movie. Brought to you by Sony");
        }

        public SonyMoviePlayer() {
            Console.WriteLine("\nNow using Sony. Even better choice");
        }
    }
}
