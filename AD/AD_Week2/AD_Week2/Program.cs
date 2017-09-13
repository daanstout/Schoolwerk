using AD_Week2.Opdracht1;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_Week2 {
    class Program {
        static void Main(string[] args) {
            MyArraylist list = new MyArraylist(5);


            list.add(4);
            list.add(3);
            list.remove();
            list.add(5);

            list.print();

            Console.WriteLine(list.get(2));
            list.set(1, 6);

            list.print();

            list.add(4);

            Console.WriteLine(list.countOccurences(4));

            list.add(4);
            list.add(4);
            list.add(4);

            list.print();

            Console.ReadKey();
        }
    }
}
