using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.Week4.Binary {
    public interface IBinaryTree<T> where T : IComparable {
        BinaryNode<T> GetRoot();
        int Size();
        int Height();

        void PrintPreOrder();
        void PrintInOrder();
        void PrintPostOrder();

        void MakeEmpty();
        bool IsEmpty();
        void Merge(T rootItem, BinaryTree<T> t1, BinaryTree<T> t2);
    }
}
