using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable {
    public class HashTable {
        int[] table;

        public HashTable() {
            table = new int[11];
        }

        public void insert(int x) {
            table[Hash(x)] = x;
        }

        private int Hash(int x) {
            return (x * 7) % 11;
        }

        public void PrintTable() {
            for(int i = 0; i < table.Length; i++) {
                Console.WriteLine("index " + i + " contains: " + table[i]);
            }
        }
    }
}
