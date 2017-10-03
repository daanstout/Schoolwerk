using BinarySearchTree.BinaryTree;
using BinarySearchTree.BinaryIntTree;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree {
    class Program {
        static void Main(string[] args) {
            BinaryIntTree.BinaryTree tree = new BinaryIntTree.BinaryTree();
            tree.Insert(6);
            tree.Insert(4);
            tree.Insert(7);
            tree.Insert(2);
            tree.Insert(5);
            tree.Insert(8);
            tree.Insert(10);
            tree.Insert(9);

            Console.WriteLine(tree.InOrder());

            tree.RemoveMin();
            tree.Remove(7);

            Console.WriteLine(tree);



            //BinaryTree<int> tree = new BinaryTree<int>(new Node<int>(5));
            //tree.insert(new Node<int>(3));
            //tree.addNode(new Node<int>(4));
            //tree.addNode(new Node<int>(7));
            //tree.addNode(new Node<int>(10));
            //tree.inPrintTree();
            Console.WriteLine();
            //tree.RemoveAllNode(7);


            //tree.inPrintTree();



            Console.ReadKey();
        }
    }
}
