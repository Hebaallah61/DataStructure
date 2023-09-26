using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List.DoubleLinkedList.SpecificType
{
    public class LinkedListNode
    {
        public int data;
        public LinkedListNode next;
        public LinkedListNode back;

        public LinkedListNode(int _data)
        {
            this.data = _data;
            this.next = null;
            this.back = null;
        }
    }
}
