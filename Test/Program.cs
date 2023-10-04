namespace Test
{
    internal class Program
    {
        static void Main()
        { 
            while (true)
            {
                ConsoleKeyInfo Tale = Console.ReadKey();
                Console.WriteLine(" ");
                Console.WriteLine(Tale.Key);
            }
        }
    }
}