using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List.DoubleLinkedList.GenericType
{
    public class LinkedList<T>
    {
        public LinkedListNode<T> head = null;
        public LinkedListNode<T> tail = null;

        public LinkedListIterator<T> Begin()
        {
            LinkedListIterator<T> itr = new LinkedListIterator<T>(head);
            return itr;
        }
        public void PrintList()
        {
            for (LinkedListIterator<T> itr = Begin(); itr.Current != null; itr.Next())
            {
                Console.WriteLine(itr.Data() + " -> ");
            }
            Console.WriteLine("\n");
        }
        public LinkedListNode<T> Find(T _data)
        {
            for (LinkedListIterator<T> itr = Begin(); itr.Current != null; itr.Next())
            {
                if (_data.Equals(itr.Data()))
                {
                    return itr.Current;
                }
            }
            return null;
        }

        public void InsertAfter(LinkedListNode<T> node, T _data)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(_data);
            newNode.Next = node.Next;
            newNode.Back = node;
            node.Next = newNode;
            if (newNode.Next == null)
            {
                tail = newNode;
            }
            else
            {
                newNode.Next.Back = newNode;
            }
        }

        public void InsertLast(T _data)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(_data);
            if (tail == null)
            {
                tail = newNode;
                head = newNode;
            }
            else
            {
                newNode.Back = tail;
                tail.Next = newNode;
                tail = newNode;
            }
        }

        public void InsertBefore(LinkedListNode<T> node, T _data)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(_data);
            newNode.Next = node;
            if (node == head)
            {
                head = newNode;
            }
            else
            {
                node.Back.Next = newNode;
            }
            node.Back= newNode;
        }

        public void DeleteNode(LinkedListNode<T> node)
        {
            if (head == tail)
            {
                head = null;
                tail = null;
            }
            else if(node.Back==null)
            {
                head = node.Next;
                node.Next.Back = null;
            }
            else if (node.Next == null)
            {
                tail = node.Back;
                node.Back.Next = null;
            }
            else
            {
                node.Back.Next = node.Next;
                node.Next.Back = node.Back;
            }
        }

    }
}
