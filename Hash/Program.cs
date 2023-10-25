using Hash.HashFunction;

namespace Hash
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FNV_la hash = new ();
            hash.Hash32("This is Original Text");
            hash.Hash64("This is Original Text");
        }
    }
}