namespace Practic2
{
    internal class Program
    {
        static void PlayNum()
        {
            Console.WriteLine("Компьютер загадал число от 1 до 100 , попробуйте угадать его");
            Random rand = new Random();
            int Ran = rand.Next(100);
            int num;
            bool test=true;
            while (test==true)
            {
                num = Convert.ToInt32(Console.ReadLine());
                if (num != Ran)
                {
                    if (num > Ran)
                    {
                        Console.WriteLine("Загаданное число меньше");
                    }
                    else
                    {
                        Console.WriteLine("Загаданное число больше");
                    }
                }
                else
                {
                    Console.WriteLine("Поздравляю , вы победили!");
                    test = false;
                }
            }
        }

        static void TabMulti()
        {
            Console.WriteLine("Таблица умножения от 1 до 9");
            int[,] M =new int [10,10];
            for (int i = 1; i < 10; i++)
            {
                Console.WriteLine("");
                for (int j = 1; j < 10; j++)
                {
                    M[i,j] = i*j;
                    Console.Write(M[i,j]+"\t");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }

        static void Divs()
        {
            Console.WriteLine("Введите число , делители которого требуется найти");
            int num;
            num = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; num >= i; i++)
            {
                if (num % i == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }


        static void Main()
        {
            bool stop = false;
            while (stop == false)
            {
                Console.WriteLine("Введите порядковый номер программы из приведенного ниже списка  , которую вы хотити выполнить \n1.Игра Угадай чило \n2.Таблица умножения\n3.Делители числа \n4.Завершить программу");
                int a;
                a = Convert.ToInt32(Console.ReadLine());
                switch (a)
                {
                    case 1:
                        PlayNum();
                        break;
                    case 2:
                        TabMulti();
                        break;
                    case 3:
                        Divs();
                        break;
                    case 4:
                        stop = true;
                        Console.WriteLine("Программа завершена");
                        break;
                    default:
                        Console.WriteLine("Некорректный ввод");
                        break;
                }
            }
        }
    }
}