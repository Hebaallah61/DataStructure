namespace Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Queue Based On Linked List
            //Queue.QueueBasedOnLinkedList.Queue.Queue q = new();
            //q.Enqueue(1);
            //q.Enqueue(2);
            //q.Enqueue(3);
            //q.Enqueue(4);
            //q.Print();
            //Console.WriteLine("Item: " + q.Dequeue());
            //Console.WriteLine("Queue Size: " + q.Size());
            //q.Print();
            //Console.WriteLine("Item: " + q.Peek());
            //Console.WriteLine("Queue Size: " + q.Size());
            //q.Print();
            #endregion

            #region Queue Based On Array
            Queue.QueueBasedOnArray.Queue.Queue queue = new();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Print();
            Console.WriteLine("Item: " + queue.Dequeue());
            Console.WriteLine("Queue Size: " + queue.Size());
            queue.Print();
            Console.WriteLine("Item: " + queue.Peek());
            Console.WriteLine("Queue Size: " + queue.Size());
            queue.Print();
            #endregion
        }
    }
}