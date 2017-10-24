using AD.Week4.Binary;
using AD.Week4.FCNS;
using AD.Week_5.BinaryTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AD.Week_5.BinaryHeap;

namespace AD {
    class Program {
        static void Main(string[] args) {
            //FCNS();
            //Binary();
            //BinarySearch();
            BinaryHeap();


            Console.ReadKey();
        }

        public static void FCNS() {
            FCNSTree<char> tree = new FCNSTree<char>(null);

            FCNSNode<char> A = new FCNSNode<char>('A', null, null);
            FCNSNode<char> B = new FCNSNode<char>('B', null, null);
            FCNSNode<char> C = new FCNSNode<char>('C', null, null);
            FCNSNode<char> D = new FCNSNode<char>('D', null, null);
            FCNSNode<char> E = new FCNSNode<char>('E', null, null);
            FCNSNode<char> F = new FCNSNode<char>('F', null, null);
            FCNSNode<char> G = new FCNSNode<char>('G', null, null);
            FCNSNode<char> H = new FCNSNode<char>('H', null, null);
            FCNSNode<char> I = new FCNSNode<char>('I', null, null);
            FCNSNode<char> J = new FCNSNode<char>('J', null, null);
            FCNSNode<char> K = new FCNSNode<char>('K', null, null);

            tree.root = A;
            A.child = B;
            B.child = F;
            F.sibling = G;
            B.sibling = C;
            C.sibling = D;
            D.child = H;
            D.sibling = E;
            E.child = I;
            I.sibling = J;
            J.child = K;

            Console.WriteLine(tree.Size());
            tree.PrintPreOrder();
        }

        public static void Binary() {
            BinaryTree<int> tree = new BinaryTree<int>(null);

            BinaryNode<int> a = new BinaryNode<int>(1, null, null);
            BinaryNode<int> b = new BinaryNode<int>(2, null, null);
            BinaryNode<int> c = new BinaryNode<int>(3, null, null);
            BinaryNode<int> d = new BinaryNode<int>(4, null, null);
            BinaryNode<int> e = new BinaryNode<int>(5, null, null);
            BinaryNode<int> f = new BinaryNode<int>(6, null, null);
            BinaryNode<int> g = new BinaryNode<int>(7, null, null);
            BinaryNode<int> h = new BinaryNode<int>(8, null, null);
            BinaryNode<int> i = new BinaryNode<int>(9, null, null);
            BinaryNode<int> j = new BinaryNode<int>(10, null, null);

            tree.root = f;
            f.left = b;
            f.right = g;
            b.left = a;
            b.right = e;
            g.right = i;
            e.left = d;
            i.left = h;
            i.right = j;
            d.left = c;

            Console.WriteLine(tree.Size());
            Console.WriteLine(tree.Height());
            tree.PrintPreOrder();
            tree.PrintInOrder();
            tree.PrintPostOrder();
            Console.WriteLine(tree.getLeaves());
            Console.WriteLine(tree.getSingleChilds());
            Console.WriteLine(tree.getDualChilds());

            BinaryTree<int> tree2 = new BinaryTree<int>(null);

            tree2.addNode(new BinaryNode<int>(4, null, null));
            tree2.addNode(new BinaryNode<int>(2, null, null));
            tree2.addNode(new BinaryNode<int>(1, null, null));
            tree2.addNode(new BinaryNode<int>(3, null, null));
            tree2.addNode(new BinaryNode<int>(6, null, null));

            Console.WriteLine(tree2);
        }

        public static void BinarySearch() {
            BinarySearchTree tree = new BinarySearchTree(null);

            Console.WriteLine(tree);
            tree.Insert(6);
            Console.WriteLine(tree);
            tree.Insert(4);
            tree.Insert(2);
            tree.Insert(5);
            tree.Insert(7);
            
            Console.WriteLine(tree.FindMin());
            Console.WriteLine(tree);
            Console.WriteLine(tree.InOrder());
            tree.RemoveMin();
            Console.WriteLine(tree);
        }

        public static void BinaryHeap() {
            BinaryHeap heap = new BinaryHeap();
            //heap.add(10);
            //heap.add(15);
            //heap.add(1);
            //heap.add(14);
            //heap.add(13);
            //heap.add(3);
            //heap.add(10);
            heap.add(1);
            heap.add(2);
            heap.add(3);
            heap.add(4);
            heap.add(5);
            heap.add(6);
            heap.add(2);
            Console.WriteLine(heap.FindMin());
            heap.printPreOrder();
        }
    }
}
