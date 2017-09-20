using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern {
    public class SamsungMoviePlayer : IMoviePlayer {
        bool isPlaying;

        public void PauzeMovie() {
            if (isPlaying) {
                Console.WriteLine("\nNow pausing the movie. Brought to you by Samsumg");
                isPlaying = false;
            }
        }

        public void PlayMovie() {
            if (!isPlaying) {
                Console.WriteLine("\nNow playing the movie. Brought to you by Samsumg");
                isPlaying = true;
            }
        }

        public void StopMovie() {
            Console.WriteLine("\nNow stopping the movie. Brought to you by Samsumg");
        }

        public SamsungMoviePlayer() {
            Console.WriteLine("\nNow using Samsung. Good choice");
        }
    }
}
