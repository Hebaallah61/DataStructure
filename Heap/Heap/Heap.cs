using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap.Heap
{
    public class Heap
    {
        private List<int> dataList;
        private int size;

        public Heap()
        {
            dataList = new List<int>();
            size = 0;
        }
        public void Insert(int data)
        {
            int i = size;
            dataList.Add(data);
            size++;
            int parentIndex =(i - 1) / 2;
            while(i != 0 && dataList[i]< dataList[parentIndex])
            {
                Swap(data,i, parentIndex);
                parentIndex = (i - 1) / 2;
            }
        }

        private void Swap(int data, int i, int Index)
        {
            dataList[i] = dataList[Index];
            dataList[Index] = data;
            i = Index;
        }

        public int Pop()
        {
            if (size == 0) return -1;
            int i = 0;
            int data= dataList[i];
            dataList[i] = dataList[size - 1];
            dataList[size - 1] =-1;
            size--;
            int leftIndex=(2*i) + 1;
            while(leftIndex <size)
            {
                int rightIndex= (2*i) + 2;
                int smallerIndex = leftIndex;
                if (dataList[rightIndex] < dataList[leftIndex])
                {
                    smallerIndex = rightIndex;
                }
                if (dataList[smallerIndex] >= dataList[i]) break;
                int temp = dataList[i];
                dataList[i] = dataList[smallerIndex];
                dataList[smallerIndex] = temp;
                i = smallerIndex;
                leftIndex = (2 * i) + 1;
            }
            return data;
        }

        public void Print()
        {
            string printData = "";
            for (int i = 0; i < size; i++)
            {
                printData += dataList[i] + " - ";
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
                int space = (int)Math.Ceiling((double)lineWidth - (double)nodesCount / 2);
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
                    if (dataList[j] != 0)
                    {
                        str += dataList[j] + new string(' ', spaceBetween);
                    }
                }
                str += new string(' ', space);
                Console.WriteLine(str);
            }
        }
    }
}
