using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.Sorting {
    public static class InsertionSort {
        public static int[] SortList(int[] input) {
            int[] temp = new int[input.Length];
            for(int i = 0; i < input.Length; i++) {
                temp[i] = input[i];
                for(int j = i; j > 0; j--) {
                    if(temp[j] < temp[j - 1]) {
                        int tempint = temp[j];
                        temp[j] = temp[j - 1];
                        temp[j - 1] = tempint;
                    }
                }
            }
            return temp;
        }
    }
}
