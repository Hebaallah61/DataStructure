using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List.DoubleLinkedList.GenericType
{
    public class LinkedListNode<T>
    {
        public LinkedListNode<T> Next {get; set;}
        public LinkedListNode<T> Back {get; set;}
        public T Data { get; set; }

        public LinkedListNode(T _data)
        {
            Data = _data;
            Next = null;
            Back = null;
        }
    }
}
