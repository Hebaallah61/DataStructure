using System;

namespace PriorityQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue.PriorityQueue<int> queue = new();
            queue.Enqueue(5, 24);
            queue.Enqueue(5, 32);
            queue.Enqueue(3, 16);
            queue.Enqueue(3, 45);
            queue.Enqueue(1, 20);
            queue.Enqueue(1, 53);
            queue.Enqueue(2, 14);
            queue.Enqueue(2, 27);

            queue.Print();
            queue.Draw();
           
            while (queue.HasData())
            {
                
                var result = queue.Dequeue();
                Console.WriteLine(result.Item1 + "[" + result.Item2 + "]");
            }
        }
    }
}