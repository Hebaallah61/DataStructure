using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.QueueBasedOnLinkedList.Queue
{
    public class Queue
    {
        NormalLinkedList.LinkedList q = new();

        public void Enqueue(int data)
        {
            q.InsertLast(data);
        }

        public int Dequeue()
        {
            if (q.head == null) return-1;
            int r= q.head.Data;
            q.DeleteHead();
            return r;
        }

        public int Peek()
        {
            if (q.head == null) return -1;
            return q.head.Data;
        }

        public int Size()
        {
            return q.Length();
        }

        public bool IsEmpty()
        {
            return q.Length()==0;
        }

        public void Print()
        {
            q.PrintList();
        }
    }
}
