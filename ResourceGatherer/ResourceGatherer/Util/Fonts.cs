using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.Util {
    public static class Fonts {
        private static readonly string font_family_user_interface = "Bookman Old Style";
        private static readonly string font_family_debug = "Arial";

        public static readonly Font font_debug = new Font(font_family_debug, 7);
        public static readonly Font font_user_interface = new Font(font_family_user_interface, 11);
    }
}
