using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Practic5
{
    public static class Arrows
    {
        public static int parametrs;
        public static int parametrscost;

        public static void Arrow(int maxpos, int minpos, int indexpart)
        {
            bool stop = false;
            int pos = minpos;

            ConsoleKeyInfo keyInfo;
            do
            {
                Console.SetCursorPosition(0, pos);
                Console.WriteLine($"->");
                keyInfo = Console.ReadKey(true);
                Console.SetCursorPosition(0, pos);
                Console.WriteLine($"  ");
                if (indexpart == 1)
                {
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.UpArrow:
                            if (pos != minpos)
                            {
                                pos--;
                            }
                            else
                            {
                                pos = maxpos;
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            if (pos != maxpos)
                            {
                                pos++;
                            }
                            else
                            {
                                pos = minpos;
                            }
                            break;
                        case ConsoleKey.Enter:
                            if (pos == 8)
                            {
                                Tortiki.Total();
                            }
                            parametrs = pos-2;
                            Order.Particulars(parametrs);
                            break;
                        case ConsoleKey.Escape:
                            Environment.Exit(0);
                            break;
                    }
                }
                else
                {
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.UpArrow:
                            if (pos != minpos)
                            {
                                pos--;
                            }
                            else
                            {
                                pos = maxpos;
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            if (pos != maxpos)
                            {
                                pos++;
                            }
                            else
                            {
                                pos = minpos;
                            }
                            break;
                        case ConsoleKey.Escape:
                            Order.Menu();
                            stop = true;
                            break;
                        case ConsoleKey.Enter:
                            parametrscost = pos - 2;
                            Tortiki.Change_zakaz(parametrs, parametrscost);
                            Order.Menu();
                            stop = true;
                            break;
                    }
                }
            } while (stop==false);
        }
    }
}
