using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DW_Week3_Opgaves {
    class Program {
        static void Main(string[] args) {
            Product p1 = new Product("Step", "Voertuig", 49.99f, true);
            Product p2 = new Product("Fiets", "Voertuig", 199.99f, false);
            Product p3 = new Product("Pan", "Kookgerei", 6.99f, true);
            Product p4 = new Product("Lepel", "Bestek", 0.49f, true);
            Product p5 = new Product("Vork", "Bestek", 0.49f, false);
            Product p6 = new Product("Mes", "Bestek", 0.49f, true);
            Product p7 = new Product("Snijplankt", "Kookgerei", 0.99f, true);
        }
    }
}
