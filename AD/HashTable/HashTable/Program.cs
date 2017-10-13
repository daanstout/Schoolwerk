using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable {
    class Program {
        static void Main(string[] args) {
            HashTable table = new HashTable();

            table.insert(2);
            table.insert(4);
            table.insert(5);
            table.insert(1);
            table.insert(4);
            table.insert(14);
            table.insert(12);

            table.PrintTable();


            Console.ReadKey();
        }
    }
}
