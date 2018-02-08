using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesOpgaven {
    class Program {
        static void Main(string[] args) {
            Vector2 v1 = new Vector2(3, 4);
            Vector2 v2 = new Vector2(5, 6);
            Vector2 v3 = v1 + v2;

            Console.WriteLine(v1);
            Console.WriteLine(v2);
            Console.WriteLine("v1 + v2 = " + v3);

            Console.ReadKey();
        }
    }
}
