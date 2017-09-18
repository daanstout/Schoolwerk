using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrollingGame {
    public static class Global {
        public static int Game_Top = 100;
        public static int Game_Bottom = 600;
        public static int Game_Left = 0;
        public static int Game_Right = 800;
        public static int UI_Top = 0;
        public static int UI_Bottom = Game_Top;
        public static int UI_Left = Game_Left;
        public static int UI_Right = Game_Right;
        public static int width = Game_Right;
        public static int heigth = Game_Bottom;
    }
}
