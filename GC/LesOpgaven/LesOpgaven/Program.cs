using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesOpgaven {
    class Program {
        static void Main(string[] args) {
            //Vector2 v1 = new Vector2(3, 4);
            //Vector2 v2 = new Vector2(5, 6);
            //Vector2 v3 = v1 + v2;

            //Console.WriteLine(v1);
            //Console.WriteLine(v2);
            //Console.WriteLine("v1 + v2 = " + v3);

            Matrix m1 = new Matrix(2, 2);
            m1.matrix[0, 0] = 1;
            m1.matrix[0, 1] = 2;
            m1.matrix[1, 0] = 3;
            m1.matrix[1, 1] = 4;

            Matrix m2 = new Matrix(2, 2);
            m2.matrix[0, 0] = 5;
            m2.matrix[0, 1] = 6;
            m2.matrix[1, 0] = 7;
            m2.matrix[1, 1] = 8;

            Matrix m3 = m1 * m2;

            Console.WriteLine(m3);

            Console.ReadKey();
        }
    }
}
