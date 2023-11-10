using System.Diagnostics;
namespace Practic8
{
    internal class Program
    {
        static void Main()
        {
            Console.Clear();
            Console.ResetColor();
            Console.Write("Введите имя: ");
            string name_user = Console.ReadLine();
            int[] inform = Body.Main();
            Score.Record(name_user, inform[0], inform[1]);
            Score.Leaderbord();
            Console.WriteLine("Если вы хотите продолжить работу с программой , то нажмите Enter , а чтобы завершить процесс - Escape");
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
            }while (stop == false);
        }
    }
}