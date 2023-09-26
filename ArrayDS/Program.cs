namespace ArrayDS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr =new int[]{ 1, 2, 3, 4, 5};
            string newsize;
            int newSize;
            ArrayOperations arrayOperations = new ArrayOperations();
            Console.Write("Enter an integer Size: ");
            newsize = Console.ReadLine();
            if (int.TryParse(newsize, out newSize))
            {
                arrayOperations.Resize<int>(ref arr, newSize);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }

            Console.WriteLine(string.Join(", ", arr));

            int item = arrayOperations.GetAt<int>(arr, 1, sizeof(int));
            Console.WriteLine(item);
            Console.WriteLine(arr[1]);

        }
    }
}