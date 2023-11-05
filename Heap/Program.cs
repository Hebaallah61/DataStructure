namespace Heap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Heap.Heap heap = new();
            heap.Insert(14);
            heap.Insert(16);
            heap.Insert(45);
            heap.Insert(24);
            heap.Insert(20);
            heap.Insert(32);
            heap.Insert(53);
            heap.Insert(27);

            heap.Print();
            Console.WriteLine();

            heap.Draw();

            heap.Pop();

            heap.Print();
            Console.WriteLine();

            heap.Draw();

            heap.Pop();

            heap.Print();
            Console.WriteLine();

            heap.Draw();
        }
    }
}