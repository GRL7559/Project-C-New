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
        public static int[] Arrow(int maxpos, int minpos)
        {
            int pos = minpos;

            ConsoleKeyInfo keyInfo;
            do
            {
                Console.SetCursorPosition(0, pos);
                Console.WriteLine($"->");
                keyInfo = Console.ReadKey(true);
                Console.SetCursorPosition(0, pos);
                Console.WriteLine($"  ");
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
                        int[] exit = new[] { -7559, pos };
                        return exit;
                    case ConsoleKey.D:
                        int code_d = -200;
                        int[] del = new[] { code_d, pos };
                        return del;
                    case ConsoleKey.C:
                        int[] cre = new[] { -8, pos };
                        return cre;
                    case ConsoleKey.Enter:
                        int[] rep = new[] { -1, pos };
                        return rep;
                }
            } while (true);
        }
    }
}