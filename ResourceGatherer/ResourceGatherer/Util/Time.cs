using ResourceGatherer.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.Util {
    public class Time {
        private Stopwatch tickWatch;

        private long previousTick;

        public static long deltaTimeMillis;
        public static float deltaTimeSeconds {
            get {
                return (float)deltaTimeMillis / 1000;
            }
        }

        public Time() {
            onLoad();
        }

        public void onLoad() {
            tickWatch = new Stopwatch();
            tickWatch.Start();
        }

        public void Update() {
            deltaTimeMillis = tickWatch.ElapsedMilliseconds - previousTick;
            previousTick = tickWatch.ElapsedMilliseconds;
        }

        public void onPause() {
            tickWatch.Stop();
        }

        public void onResume() {
            tickWatch.Start();
        }
    }
}
