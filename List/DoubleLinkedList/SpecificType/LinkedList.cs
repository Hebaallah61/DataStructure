using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List.DoubleLinkedList.SpecificType
{
    public class LinkedList
    {
        public LinkedListNode head = null;
        public LinkedListNode tail = null;

        public LinkedListIterator Begin()
        {
            LinkedListIterator itr = new LinkedListIterator(head);
            return itr;
        }
        public void PrintList()
        {
            for (LinkedListIterator itr = Begin(); itr.Current() != null; itr.Next())
            {
                Console.Write(itr.Data() + " -> ");
            }
            Console.Write("\n");
        }
        public LinkedListNode Find(int _data)
        {
            for (LinkedListIterator itr = this.Begin(); itr.Current() != null; itr.Next())
            {
                if (_data == itr.Data())
                {
                    return itr.Current();
                }
            }
            return null;
        }
        public void InsertAfter(LinkedListNode node, int _data)
        {
            LinkedListNode newNode = new LinkedListNode(_data);
            newNode.next = node.next;
            newNode.back = node;
            node.next = newNode;
            if (newNode.next == null)
            {
                tail = newNode;
            }
            else
            {
                newNode.next.back = newNode;
            }
        }

        public void InsertLast(int _data)
        {
            LinkedListNode newNode = new LinkedListNode(_data);
            if (tail == null)
            {
                tail = newNode;
                head= newNode;
            }
            else
            {
                newNode.back = tail;
                tail.next= newNode;
                tail= newNode;

            }
        }

        public void InsertBefore(LinkedListNode node, int _data)
        {
            LinkedListNode newNode = new LinkedListNode(_data);
            newNode.next = node;
            if (node == head)
            {
                head = newNode;
            }
            else
            {
                node.back.next = newNode;
            }
            node.back = newNode;
        }

        public void DeleteNode(LinkedListNode node)
        {
            if (head == tail)
            {
                head = null;
                tail = null;
            }
            else if (node.back == null)
            {
                head = node.next;
                node.next.back = null;
            }
            else if (node.next == null)
            {
                tail = node.back;
                node.back.next = null;
            }
            else
            {
                node.back.next = node.next;
                node.next.back = node.back;
            }
            node = null;
        }
    }
}