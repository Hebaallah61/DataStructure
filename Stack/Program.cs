namespace Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Stack Based On Linked List
            Stack.StackBasedOnLinkedList.Stack.Stack stack = new();
            Console.WriteLine("Is Stack Empty: " + stack.IsEmpty());
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Print();  
            Console.WriteLine("Item: " + stack.Pop()); 
            Console.WriteLine("Stack Size: " + stack.Size());
            stack.Print();
            Console.WriteLine("Item: " + stack.Peek());
            Console.WriteLine("Stack Size: " + stack.Size());
            stack.Print();

            #endregion
        }
    }
}