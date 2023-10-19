using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Stack.StackBasedOnArray.Stack
{
    public class Stack
    {
        public int[] s;
        public int top;
        public int max;
        int size = 5;
        public Stack()
        {
            s= new int[size];
            for (int i = 0; i < size; i++)
            {
                s[i] = -1; 
            }
            top = -1;
            max = size;
        }

        public void Push(int data)
        {
            if (top == max - 1)
            {
                Console.WriteLine("Stack Is Full We Will Resize");
                s = Resize(s);
                max += 5;
            }
            
            s[++top] = data;
        }

        public int Pop()
        {
            if (top==-1)
            {
                Console.WriteLine("The Stack Is Empty.");
                return -1;
            }

            int r= s[top];
            s[top] = -1;
            top--;
            return r;
        }

        public int Peek()
        {
            if (top == -1)
            {
                Console.WriteLine("The Stack Is Empty.");
                return -1;
            }

            return s[top];
        }

        public int Size()
        {
            return top+1;
        }

        public bool IsEmpty() 
        {
            return top == -1;
        }

        public int[] Resize(int[] s)
        {
            int temp = max + 5;
            int[] s1 = new int[temp];
            s.CopyTo(s1, 0);
            return s1;  
        }

        public void Print()
        {
            if (top == -1)
            {
                Console.WriteLine("The Stack Is Empty.");
            }
            else
            {
                for(int i=top; i>=0;i--)
                {
                    if(i!=-1)
                    Console.Write($"{s[i]} => ");
                }
                Console.WriteLine();
            }

        }
    }
}
