namespace Practic_3
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Функциональные клавиши : Q,W,E,R,T,Y,U,I,O,P,[,],| \nДля выбора октавы нажмите 1 / 2 / 3 \nДля выхода из программы нажмите Escape");
            bool stop=true;
            ConsoleKey choiseR = ConsoleKey.D1;
            while (stop==true)
            {
                ConsoleKeyInfo Tale = Console.ReadKey(true);
                switch (Tale.Key)
                {
                    case ConsoleKey.Q:
                        Beep(0, choiseR);
                        break;
                    case ConsoleKey.W:
                        Beep(1, choiseR);
                        break;
                    case ConsoleKey.E :
                        Beep(2, choiseR);
                        break;
                    case ConsoleKey.R :
                        Beep(3, choiseR);
                        break;
                    case ConsoleKey.T :
                        Beep(4, choiseR);
                        break;
                    case ConsoleKey.Y :
                        Beep(5, choiseR);
                        break;
                    case ConsoleKey.U :
                        Beep(6, choiseR);
                        break;
                    case ConsoleKey.I :
                        Beep(7, choiseR);
                        break;
                    case ConsoleKey.O :
                        Beep(8, choiseR);
                        break;
                    case ConsoleKey.P :
                        Beep(9, choiseR);
                        break;
                    case ConsoleKey.Oem3 :
                        Beep(10, choiseR);
                        break;
                    case ConsoleKey.Oem4 :
                        Beep(11, choiseR);
                        break;
                    case ConsoleKey.Escape:
                        stop=false;
                        break;
                    default:
                        choiseR = Tale.Key;
                        break;

                }

            }

        }
        static void Beep(int a , ConsoleKey choise)
        {
            int[] Play = Octave(choise);
            Console.Beep(Play[a], 200);
        }
        static int[] Octave(ConsoleKey oct)
        {
            int[] octave = new int[12];
            switch (oct)
            {
                case ConsoleKey.D1:
                    octave = new int[] { 261 , 277 , 293 ,311 ,329 ,349 ,369 ,392 ,415 ,440 ,466 ,493 };
                    break;
                case ConsoleKey.D2:
                    octave = new int[] { 523 ,554 ,587 ,622 ,659 ,698 ,739 ,784 ,830 ,880 ,932 ,987 };
                    break;
                case ConsoleKey.D3:
                    octave = new int[] { 1046 ,1108 , 1244 ,1318 ,1396 ,1480 ,1568 ,1661 ,1720 ,1864 ,1975 };
                    break;
            }
            return octave;
        }
    }
}