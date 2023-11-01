namespace Practic7
{
    internal class Program
    {
        static void Main()
        {
            Console.Clear();
            try
            {
                Files.ChoiseDrive();
            }
            catch(Exception ex)
            {
                Console.Clear();
                Console.WriteLine($"Возникла ошибка:{ex}.\n Если вы хотите продолжить работу с программой , то нажмите Enter , а чтобы завершить процесс - Escape");
                ConsoleKeyInfo keyInfo;
                bool stop = false;
                do
                {
                    keyInfo = Console.ReadKey(true);
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.Enter:

                            stop = true;
                            Main();
                            break;
                        case ConsoleKey.Escape:
                            Console.Clear();
                            Environment.Exit(0);
                            break;
                    }
                } while (stop == false);
            }
        }
    }
}