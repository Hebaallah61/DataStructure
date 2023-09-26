using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List.DoubleLinkedList.SpecificType
{
    public class LinkedListIterator
    {
        private LinkedListNode currentNode;

        public LinkedListIterator()
        {
            currentNode = null;
        }

        public LinkedListIterator(LinkedListNode node)
        {
            currentNode = node;
        }

        public int Data()
        {
            return currentNode.data;
        }

        public LinkedListIterator Next()
        {
            this.currentNode = this.currentNode.next;
            return this;
        }

        public LinkedListNode Current()
        {
            return currentNode;
        }
    }
}
