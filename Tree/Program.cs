using Tree.BinaryTree;

namespace Tree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinaryTree.BinaryTree<char> tree = new();
            tree.Insert('A');
            tree.Insert('B');
            tree.Insert('C');
            tree.Insert('D');
            tree.Insert('E');
            tree.Insert('F');
            tree.Insert('G');
            tree.Insert('H');
            tree.Insert('I');
            tree.Print();

            Console.WriteLine("Height: " + tree.Height());
            tree.PreOrder();
            tree.InOrder();
            tree.PostOrder();
         
            tree.Find('k');
            tree.Find('D');

           

        }
    }
}