using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_Week2.Opdracht1 {
    public class MyArraylist : ISimpleArrayList {
        int[] array;
        int index;
        int size;

        public MyArraylist(int size) {
            array = new int[size];
            index = 0;
            this.size = size;
        }

        public void remove() {
            index--;
        }

        public void add(int n) {
            array[index] = n;
            index++;
            if (index >= size) {
                int[] temp = new int[size * 2];
                int tempIndex = 0;
                foreach (int i in array) {
                    temp[tempIndex] = i;
                    tempIndex++;
                }
                array = temp;
                size *= 2;
            }
        }

        public void clear() {
            array = new int[size];
            index = 0;
        }

        public int countOccurences(int n) {
            int count = 0;
            for (int i = 0; i <= size; i++)
                if (array[i] == n)
                    count++;
            return count;
        }

        public int get(int index) {
            if (index < 0 || index >= this.index)
                return 0;
            return array[index];
        }

        public void print() {
            Console.WriteLine("Printing numbers:");
            for (int i = 0; i < index; i++)
                Console.Write(array[i] + ", ");
            Console.WriteLine("\n");
        }

        public void set(int index, int n) {
            if (index < 0 || index >= this.index)
                return;
            array[index] = n;
        }
    }
}
