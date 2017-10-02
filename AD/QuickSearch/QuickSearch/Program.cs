using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSearch {
    class Program {
        static void Main(string[] args) {
            List<int> list = new List<int>() { 6, 4, 3, 1, 9, 7, 2, 8, 5, 0 };

            foreach (int i in list)
                Console.Write(i);


            Console.WriteLine();

            QuickSort(list, 0, list.Count - 1);




            Console.ReadKey();
        }

        static void swap(List<int> list, int one, int two) {
            int temp = list[one];
            list[one] = list[two];
            list[two] = temp;
        }

        static void QuickSort(List<int> list, int left, int right) {
            int middle = (left + right) / 2;

            if (list[middle] < list[left])
                swap(list, middle, left);

            if (list[right] < list[left])
                swap(list, right, left);

            if (list[right] < list[middle])
                swap(list, right, middle);

            //swap middle and high
            /*
             *pivo is high - 1 
             * 
             * 
             * loo pfrom low to high - 1;
             * 
             * loop till we get a number that doesn't belong
             * 
             * break if we get to break point
             * 
             * swap points eles whise
             * 
             * 
             * end loop
             * 
             * swap i with pivot
             * 
             * recursion
             */
        }
    }
}
