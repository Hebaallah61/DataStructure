using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace List.DoubleLinkedList.GenericType
{
    public class LinkedList<T>
    {
        public LinkedListNode<T> head = null;
        public LinkedListNode<T> tail = null;
        public int length { get; private set; } = 0;
        public bool unique { get; set; }
        public LinkedList()
        {
            
        }
        public LinkedList(bool _unique=false)
        {
            unique = _unique;
        }

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
            if (!CanInsert(_data)) return;
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
            length++;
        }

        public bool CanInsert(T _data)
        {
            if (unique && IsExist(_data))
            {
                Console.WriteLine($"Node ={_data} Is Already Exist");
                return false;
            }
            return true;
        }

        public void InsertLast(T _data)
        {
            if (!CanInsert(_data)) return;
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
            length++;
        }

        public void InsertBefore(LinkedListNode<T> node, T _data)
        {
            if (!CanInsert(_data)) return;
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
            length++;
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
            length--;
        }

        public static LinkedList<T> CopyList(LinkedList<T> list)
        {
            LinkedList<T> copy = new LinkedList<T>();
            LinkedListIterator<T> iterator = new LinkedListIterator<T>(list.head); 

            while (iterator.Current != null)
            {
                copy.InsertLast(iterator.Data());
                iterator.Next();
            }
            return copy;
        }

        public bool IsExist(T data)
        {
            LinkedListNode<T> node = this.Find(data);
            if(node!=null)
            {
                return true;
            }
            return false;
        }

    }
    public static class LinkedListExtensions
    {
        public static LinkedList<T> CopyList<T>(this LinkedList<T> list)
        {
            return LinkedList<T>.CopyList(list);
        }
    }
}
