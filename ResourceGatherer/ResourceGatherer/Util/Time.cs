using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.Util {
    /// <summary>
    /// The time class. Keeps track of the time passed between updates
    /// </summary>
    public sealed class Time {
        /// <summary>
        /// The stopwatch used to calculate the time with
        /// </summary>
        private Stopwatch tickWatch;

        /// <summary>
        /// The previous time
        /// </summary>
        private long previousTick;

        /// <summary>
        /// The difference in milliseconds between 2 updates
        /// </summary>
        public static long deltaTimeMillis { get; private set; }
        /// <summary>
        /// The difference in seconds between 2 updates
        /// </summary>
        public static float deltaTimeSeconds {
            get {
                return (float)deltaTimeMillis / 1000;
            }
        }

        /// <summary>
        /// Total elapsed time since the start
        /// </summary>
        public static long totalElapsedTime { get; private set; }

        /// <summary>
        /// Constructor creates a new stopwatch and starts it
        /// </summary>
        public Time() {
            onLoad();
        }

        /// <summary>
        /// Creates a new stopwatch and starts it
        /// </summary>
        public void onLoad() {
            tickWatch = new Stopwatch();
            tickWatch.Start();
        }

        /// <summary>
        /// Updates the time
        /// </summary>
        public void Update() {
            deltaTimeMillis = tickWatch.ElapsedMilliseconds - previousTick;
            previousTick = tickWatch.ElapsedMilliseconds;
            totalElapsedTime = tickWatch.ElapsedMilliseconds;
        }

        /// <summary>
        /// Pauses the stopwatch
        /// </summary>
        public void onPause() {
            tickWatch.Stop();
        }

        /// <summary>
        /// Resumes the stopwatch
        /// </summary>
        public void onResume() {
            tickWatch.Start();
        }
    }
}
