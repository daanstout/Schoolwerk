using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thievery.Utils {
    public static class Time {
        private static Stopwatch stopwatch;

        private static decimal previous;

        public static decimal elapsedMilliSeconds {
            get;
            private set;
        }

        public static decimal elapsedSeconds {
            get {
                return elapsedMilliSeconds / 1000;
            }
        }

        public static void Init() {
            stopwatch = new Stopwatch();

            stopwatch.Start();
        }

        public static void Update() {
            decimal elapsedTime = stopwatch.ElapsedMilliseconds;
            elapsedMilliSeconds = elapsedTime - previous;
            previous = elapsedTime;
        }
    }
}
