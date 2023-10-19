using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Stack.StackBasedOnLinkedList.Stack
{
    public class Stack
    {
        NormalLinkedList.LinkedList s = new();
        public void Push(int data)
        {
            s.InsertFirst(data);
        }

        public int Pop()
        {
            if (s.head == null)
            {
                throw new InvalidOperationException("The Stack is empty.");
            }

            int r = s.head.Data;
            s.DeleteHeadV2();
            return r;
        }

        public int Peek()
        {
            if (s.head == null)
            {
                throw new InvalidOperationException("The Stack is empty.");
            }

            return s.head.Data;
        }

        public int Size()
        {
            return s.Length();
        }

        public bool IsEmpty() 
        {
            return s.Length() <= 0;
        }

        public void Print()
        {
            s.PrintList();
        }
    }
}
