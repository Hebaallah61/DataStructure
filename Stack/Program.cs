namespace Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Stack Based On Linked List
            Stack.StackBasedOnLinkedList.Stack.Stack stack = new();
            //Console.WriteLine("Is Stack Empty: " + stack.IsEmpty());
            //stack.Push(1);
            //stack.Push(2);
            //stack.Push(3);
            //stack.Print();  
            //Console.WriteLine("Item: " + stack.Pop()); 
            //Console.WriteLine("Stack Size: " + stack.Size());
            //stack.Print();
            //Console.WriteLine("Item: " + stack.Peek());
            //Console.WriteLine("Stack Size: " + stack.Size());
            //stack.Print();
            #endregion

            #region Stack Based On Array
            Stack.StackBasedOnArray.Stack.Stack s = new();
            Console.WriteLine("Is Stack Empty: " + s.IsEmpty());
            s.Push(1);
            s.Push(2);
            s.Push(3);
            s.Push(4);
            s.Push(5);
            s.Print();

            Console.WriteLine("Stack Size: " + s.Size());
            Console.WriteLine("Item: " + s.Pop());
            Console.WriteLine("Stack Size: " + s.Size());
            s.Print();
            Console.WriteLine("Item: " + s.Peek());
            Console.WriteLine("Stack Size: " + s.Size());
            s.Print();
            s.Push(6);
            s.Push(6);
            s.Print();
            Console.WriteLine("Stack Size: " + s.Size());

            while (s.IsEmpty() != true)
            {
                Console.WriteLine("Item: " + s.Pop());
                Console.WriteLine("Stack Size: " + s.Size());
                s.Print();
            }
            #endregion
        }
    }
}