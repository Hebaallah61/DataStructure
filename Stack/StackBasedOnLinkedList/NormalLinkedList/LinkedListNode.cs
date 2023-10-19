using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack.StackBasedOnLinkedList.NormalLinkedList
{
    public class LinkedListNode
    {
        public int Data { get; set; }
        public LinkedListNode Next { get; set; }

        public LinkedListNode(int data)
        {
            Data = data;
            Next = null;
        }
    }
}
