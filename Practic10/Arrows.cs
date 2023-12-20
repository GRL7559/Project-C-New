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
        public enum Keys
        {
            Escape = -7559,
            Enter = -1,
            S = -2,
            Delete = -3,
            C = -4, 
            Right = -5,
            Left = -6
        }
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
                        int[] exit = new[] { (int)Keys.Escape, pos };
                        return exit;
                    case ConsoleKey.Enter:
                        int[] open = new[] { (int)Keys.Enter, pos };
                        return open;
                    case ConsoleKey.S:
                        int[] save = new[] { (int)Keys.S, pos };
                        return save;
                    case ConsoleKey.Delete:
                        int[] del = new[] { (int)Keys.Delete, pos };
                        return del;
                    case ConsoleKey.C:
                        int[] create = new[] { (int)Keys.C, pos };
                        return create;
                    case ConsoleKey.RightArrow:
                        int[] plus = new[] { (int)Keys.Right, pos };
                        return plus;
                    case ConsoleKey.LeftArrow:
                        int[] minus = new[] { (int)Keys.Left, pos };
                        return minus;
                }
            } while (true);
        }
    }
}