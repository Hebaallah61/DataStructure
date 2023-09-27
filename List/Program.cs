
using List.DoubleLinkedList.GenericType;

namespace List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Normal Linked List Manual Test
            NormalLinkedList.LinkedList L1 = new ();
            //L1.InsertLast(1);
            //L1.InsertLast(2);
            //L1.InsertLast(3);
            //L1.InsertLast(4);
            //L1.InsertLast(5);
            //L1.InsertLast(6);
            //L1.PrintList();
            //Console.WriteLine(L1.Sum());
            //L1.DeleteNode(1);
            //L1.PrintList();
            //L1.InsertBefore(L1.Find(3), 75);
            //L1.PrintList();
            //L1.InsertAfter(L1.Find(5), 200);
            //L1.PrintList();
            //Console.WriteLine(L1.GetLengthItr());
            //L1.PrintList();
            #endregion

            #region Double Linked List Specific Type Manual Test
            //DoubleLinkedList.SpecificType.LinkedList list = new();
            //list.InsertLast(1);
            //list.InsertLast(2);
            //list.InsertLast(3);
            //list.InsertLast(4);
            //list.InsertLast(5);
            //list.PrintList();

            //list.InsertAfter(list.Find(3), 75);
            //list.PrintList();

            //list.DeleteNode(list.Find(1));
            //list.PrintList();

            //list.InsertBefore(list.Find(5), 200);
            //list.PrintList();
            #endregion

            #region Generic Double Linked List Manual Test
            DoubleLinkedList.GenericType.LinkedList<string> list = new();
            list.InsertLast("heba");
            list.InsertLast("ali");
            list.InsertLast("nour");
            list.InsertLast("khaled");
            list.InsertLast("Ahmed");
            list.PrintList();
            Console.WriteLine(list.length);

            list.InsertAfter(list.Find("heba"), "Asmaa");
            list.PrintList();
            Console.WriteLine(list.length);

            list.DeleteNode(list.Find("Ahmed"));
            list.PrintList();
            Console.WriteLine(list.length);

            list.InsertBefore(list.Find("nour"), "Sahar");
            list.PrintList();
            Console.WriteLine(list.length);
            Console.WriteLine(list.GetHashCode());

            DoubleLinkedList.GenericType.LinkedList<string> copiedList = DoubleLinkedList.GenericType.LinkedList<string>.CopyList(list);
            copiedList.PrintList();
            Console.WriteLine(copiedList.GetHashCode());

            #endregion

        }
    }
}