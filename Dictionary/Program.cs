namespace Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary.Dictionary <string, string> dic = new ();
            dic.Print();

            dic.Set("Heba", "Heba@gmail.com");
            dic.Set("Ali", "Ali@gmail.com");
            dic.Print();

            dic.Set("Mohammed", "Mohammed@gmail.com");
            dic.Set("Ahmed", "Ahmed@gmail.com");
            dic.Set("Mona", "Mona@gmail.com");

            dic.Print();

            Console.WriteLine(dic.Get("Heba"));
            Console.WriteLine(dic.Get("Ali"));
            Console.WriteLine(dic.Get("Mohammed"));

            dic.Remove("Heba");
            dic.Remove("Ali");
            dic.Remove("Mohammed");
            dic.Remove("Ahmed");
            dic.Remove("Mona");
            
            dic.Print();
            
            dic.Set("Heba", "Heba@gmail.com");
            
            dic.Print();
        }
    }
}