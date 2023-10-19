using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Practic5
{
    internal class Arrows
    {
        private int maxpos;
        private int minpos;
        private int indexpart;
        public static int parametrs;
        public static int parametrscost;
        public Arrows(int max , int min , int ind) 
        {
            maxpos = max;
            minpos = min;
            indexpart = ind;
        }
        public void Arrow()
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
                            Tortiki.Particulars(parametrs);
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
                            Tortiki.Menu();
                            stop = true;
                            break;
                        case ConsoleKey.Enter:
                            parametrscost = pos - 2;
                            Tortiki.Change_zakaz(parametrs, parametrscost);
                            Tortiki.Menu();
                            stop = true;
                            break;
                    }
                }
            } while (stop==false);
        }
    }
}
