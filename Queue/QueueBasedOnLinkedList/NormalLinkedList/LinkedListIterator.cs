using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.QueueBasedOnLinkedList.NormalLinkedList
{
    public class LinkedListIterator
    {
        public LinkedListNode CurrentNode { get; set; }
        public LinkedListIterator()
        {
            CurrentNode = null;
        }
        public LinkedListIterator(LinkedListNode Node)
        {
            CurrentNode = Node;
        }
        public int Data()
        {
            return CurrentNode.Data;
        }
        public LinkedListIterator Next()
        {
            CurrentNode = CurrentNode.Next;
            return this;
        }
        public LinkedListNode Current()
        {
            return CurrentNode;
        }
    }
}
