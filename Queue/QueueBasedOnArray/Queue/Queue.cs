using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.QueueBasedOnArray.Queue
{
    public class Queue
    {
        private int front, tail, capacity;
        private int[] queue;
        int c = 5;

        public Queue()
        {
            front = tail = 0;
            capacity = c;
            queue = new int[capacity];
        }

        public void Enqueue(int data)
        {
            if (capacity == tail)
            {
                Console.WriteLine("Queue Is Full We Will Resize");
                queue = Resize(queue);
                c = c + 5;
            }
            queue[tail++] = data;
        }

        private int[] Resize(int[] queue)
        {
            int temp = c + 5;
            int[] result = new int[c];
            queue.CopyTo(result, 0);
            return result;
            
        }

        public int Dequeue()
        {
            int temp;
            if (tail == front) return -1;
            else
            {
                temp = queue[front];
                for (int i = 0; i < tail - 1; i++)
                {
                    queue[i] = queue[i + 1];
                }
            }
            if (tail < capacity) queue[tail] = -1;
            tail--;
            return temp;
        }

        public int Peek()
        {
            if (tail == front) return -1;
            return queue[front];
        }

        public int Size()
        {
            return tail;
        }

        public bool IsEmpty()
        {
            return queue.Length == 0;
        }

        public void Print()
        {
            for(int i=0; i < tail; i++)
            {
                Console.Write(queue[i]+"->");
            }
            Console.WriteLine();
        }


    }
}
