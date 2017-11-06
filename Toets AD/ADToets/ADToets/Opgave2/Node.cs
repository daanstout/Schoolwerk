using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADToets.Opgave2 {
    public class Node {
        public int aantal;
        public Node nul;
        public Node een;

        public Node() {
            aantal = 0;
            nul = een = null;
        }
    }
}
