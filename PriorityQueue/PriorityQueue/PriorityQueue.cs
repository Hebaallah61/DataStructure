using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue.PriorityQueue
{
    public class PriorityQueue<T>
    {
        private List<(int priority, T data)> dataList;
        private int size;

        public PriorityQueue()
        {
            dataList = new List<(int priority, T data)>();
            size = 0;
        }

        public void Enqueue(int priority,T data)
        {
            int i = size;
            dataList.Add((priority, data));
            size++;
            int parentIndex =(i - 1) / 2;
            while(i != 0 && dataList[i].priority< dataList[parentIndex].priority)
            {
                i=Swap(i, parentIndex);
                parentIndex = (i - 1) / 2;
            }
        }

        private int Swap(int i, int Index)
        {
            var temp = dataList[i];
            dataList[i] = dataList[Index];
            dataList[Index] = temp;
            return Index;
        }

        public (T data, int priority) Dequeue()
        {
            if (size == 0) return (default,-1);
            int i = 0;
            var data= dataList[i].data;
            var priority = dataList[i].priority;
            dataList[i] = dataList[size - 1];
            size--;
            int leftIndex=(2*i) + 1;
            while(leftIndex <size)
            {
                int rightIndex= (2*i) + 2;
                int smallerIndex = leftIndex;
                if (dataList[rightIndex].priority < dataList[leftIndex].priority)
                {
                    smallerIndex = rightIndex;
                }
                if (dataList[smallerIndex].priority >= dataList[i].priority) break;
                var temp = dataList[i];
                dataList[i] = dataList[smallerIndex];
                dataList[smallerIndex] = temp;
                i = smallerIndex;
                leftIndex = (2 * i) + 1;
            }
            return (data, priority);
        }

        public bool HasData()
        {
            return size > 0;
        }

        public void Print()
        {
            StringBuilder printData = new StringBuilder();
            for (int i = 0; i < size; i++)
            {
                printData.Append(dataList[i].data + " - ");
            }
            Console.WriteLine(printData);
        }

        public int Size()
        {
            return size;
        }

        public void Draw()
        {
            int levelsCount = (int)Math.Log2(size) + 1;
            int lineWidth = (int)Math.Pow(2, levelsCount - 1);

            int j = 0;
            for (int i = 0; i < levelsCount; i++)
            {
                int nodesCount = (int)Math.Pow(2, i);
                int space = (int)Math.Ceiling(lineWidth - (double)nodesCount / 2);
                int spaceBetween = (int)Math.Ceiling((double)levelsCount / (double)nodesCount);
                spaceBetween = spaceBetween < 1 ? 1 : spaceBetween;
                int k = j;
                string str = new string(' ', space + spaceBetween);
                for (; j < k + nodesCount; j++)
                {
                    if (j == size)
                    {
                        break;
                    }
                    if (dataList[j].data != null)
                    {
                        str += $"{dataList[j].data}[{dataList[j].priority}]".PadRight(spaceBetween);
                    }
                }
                str += new string(' ', space) + "\n";
                Console.WriteLine(str);
            }
        }
    }   
}
