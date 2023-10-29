using Hash.HashFunction;
using Hash.HashTable;

namespace Hash
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region FNV_la Function
            //FNV_la hash = new ();
            //hash.Hash32("This is Original Text");
            //hash.Hash64("This is Original Text");
            #endregion

            #region HashTable
            Hash.HashTable.HashTable<string,string> table = new HashTable<string, string>();
            table.Print();
            table.Set("A", "A@gmail.com");
            table.Set("B", "B@gmail.com");
            table.Set("C", "C@gmail.com");
            table.Print();
            Console.WriteLine("[get] " + table.Get("A"));
            Console.WriteLine("[get] " + table.Get("B"));
            table.Set("D", "D@gmail.com");
            table.Set("E", "E@gmail.com");
            table.Print();
            Console.WriteLine("[get] " + table.Get("B"));
            table.Remove("A");
            table.Remove("E");
            table.Print();
            #endregion
        }
    }
}