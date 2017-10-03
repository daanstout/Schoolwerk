using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.BinaryIntTree {
    interface IBinarySearchTree {
        void Insert(int x);
        void Remove(int x);
        void RemoveMin();
        int FindMin();
        string InOrder();
        string ToString();
    }
}
