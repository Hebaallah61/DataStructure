using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List.DoubleLinkedList.GenericType
{
    public class LinkedListIterator<T>
    {
        public LinkedListNode<T> Current { get;  set; }

        public LinkedListIterator()
        {
            Current = null;
        }

        public LinkedListIterator(LinkedListNode<T> node)
        {
            Current = node;
        }
         
        public T Data()
        {
            return Current.Data;
        }

        public LinkedListIterator<T> Next()
        {
            Current = Current.Next;
            return this;
        }

        public LinkedListNode<T> CurrentNode()
        {
            return Current;
        }
    }
}
