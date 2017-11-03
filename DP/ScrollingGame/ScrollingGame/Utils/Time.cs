using ScrollingGame.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrollingGame.Utils {
    public class Time : ABehaviour{
        private Stopwatch tickWatch;

        private long previousTick;

        public static long deltaTimeMillis;
        public static float deltaTimeSeconds {
            get {
                return (float)deltaTimeMillis / 1000;
            }
        }

        public override void onLoad() {
            tickWatch = new Stopwatch();
            tickWatch.Start();
        }

        public override void onUpdate() {
            deltaTimeMillis = tickWatch.ElapsedMilliseconds - previousTick;
            previousTick = tickWatch.ElapsedMilliseconds;
        }

        public override void onPause() {
            tickWatch.Stop();
        }

        public override void onResume() {
            tickWatch.Start();
        }
    }
}
