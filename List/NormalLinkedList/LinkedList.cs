using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace List.NormalLinkedList
{
    internal class LinkedList
    {
        public LinkedListNode head = null;
        public LinkedListNode tail = null;
        private int length;
        public void InsertLast(int data)
        {
            LinkedListNode NewNode = new LinkedListNode(data);
            if (head == null && tail == null)
            {
                head = tail = NewNode;

            }
            else
            {

                tail.Next = NewNode;
                tail = NewNode;


            }
            length++;
        }
        public LinkedListIterator Begin()
        {
            LinkedListIterator itr = new LinkedListIterator(head);
            return itr;
        }
        public void InsertAfter(LinkedListNode node, int data)
        {
            LinkedListNode newnode = new LinkedListNode(data);
            newnode.Next = node.Next;
            node.Next = newnode;
            if (newnode.Next == null)
            {
                tail = newnode;
            }
            length++;
        }

        public void PrintList()
        {
            for (LinkedListIterator itr = Begin(); itr.Current() != null; itr.Next())
            {
                Console.Write(itr.Data() + " -> ");
            }
            Console.Write("\n");
        }
        public int Sum()
        {
            int sum = 0;
            for (LinkedListIterator itr = Begin(); itr.Current() != null; itr.Next())
            {
                sum += itr.Data();
            }
            return sum;
        }
        public int Length()
        {
            return length;
        }

        public LinkedListNode Find(int data)
        {
            for (LinkedListIterator itr = Begin(); itr.Current() != null; itr.Next())
            {
                if (itr.Data() == data)
                    return itr.Current();

            }
            return null;
        }

        public LinkedListNode FindParent(LinkedListNode node)
        {
            for (LinkedListIterator itr = Begin(); itr.Current() != null; itr.Next())
            {
                if (itr.Current().Next == node)
                    return itr.Current();

            }
            return null;
        }

        public int GetLengthItr()
        {
            int count = 0;
            for (LinkedListIterator itr = Begin(); itr.Current() != null; itr.Next())
            {
                count++;
            }
            return count;
        }
        public void InsertBefore(LinkedListNode node, int data)
        {
            LinkedListNode newnode = new LinkedListNode(data);
            newnode.Next = node;

            LinkedListNode parentNode = FindParent(node);

            if (parentNode == null)
            {
                head = newnode;
            }
            else
            {
                parentNode.Next = newnode;
            }
            length++;
        }

        public void DeleteNode(int data)
        {
            LinkedListNode node = Find(data);
            if (node == null)
            {
                return;
            }
            DeleteNode(node);
        }

        public void DeleteHead()
        {
            if (head == null)
            {
                return;
            }
            DeleteNode(head);
        }

        public void DeleteNode(LinkedListNode node)
        {
            if (head == tail)
            {
                head = null;
                tail = null;
            }
            else if (head == node)
            {
                head = node.Next;
            }
            else
            {
                LinkedListNode parentNode = FindParent(node);

                if (tail == node)
                {
                    tail = parentNode;
                }
                else
                {
                    parentNode.Next = node.Next;
                }
            }
            length--;
        }
    }
}
