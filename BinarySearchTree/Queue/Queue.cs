using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.Queue
{
    public class Queue<Tdata>
    {
        LinkedList<Tdata> data;
        public Queue()
        {
             data = new ();
        }
        public void enqueue(Tdata _data)
        {
            data.AddLast(_data);
        }

        public Tdata dequeue()
        {
            Tdata nodeData = data.First.Value;
            data.RemoveFirst();
            return nodeData;
        }
        public Tdata peek()
        {
            if (data.First == null)
                return default(Tdata);
            return data.First.Value;
        }
        public bool hasData()
        {
            if (data.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int size() { return data.Count; }
    }
}
