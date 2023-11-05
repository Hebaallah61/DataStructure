using System.Runtime.InteropServices;

namespace BinarySearchTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree.BinarySearchTree<int> tree = new();
            /*
            tree.BSInsert(1);
            tree.BSInsert(2);
            tree.BSInsert(3);
            tree.BSInsert(4);
            tree.BSInsert(5);
            tree.BSInsert(6);
            tree.Print();
            */
            /*
            tree.BSInsert(1);
            tree.BSInsert(4);
            tree.BSInsert(2);
            tree.BSInsert(3);
            tree.BSInsert(6);
            tree.BSInsert(5);
            tree.Print();
            */

            tree.BSInsert(4);
            tree.BSInsert(2);
            tree.BSInsert(1);
            tree.BSInsert(3);
            tree.BSInsert(6);
            tree.BSInsert(5);
            tree.BSInsert(7);
            tree.Print();

           Console.WriteLine(tree.IsExsit(6));

            tree.BsDelete(4);
            tree.Print();

            tree.BsDelete(6);
            tree.Print();

            tree.BsDelete(1);
            tree.Print();

            BinarySearchTree.BinarySearchTree<int> T = new();

            T.BSInsert(1);
            T.BSInsert(2);
            T.BSInsert(3);
            T.BSInsert(4);
            T.BSInsert(5);
            T.BSInsert(6);
            T.Print();

            T.Balance();
            T.Print();
        }
    }
}