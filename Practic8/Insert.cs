using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic8
{
    public class Insert
    {
        public static int Correct(string txt ,int k)
        {
            int str = Stroka(k);
            int ots = Otstup(k);
            Console.SetCursorPosition(k-ots, str);
            if (txt[k] == Console.ReadKey(true).KeyChar)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(k - ots, str);
                Console.WriteLine(txt[k]);
                Console.ResetColor();
                k++;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(k - ots, str);
                Console.WriteLine(txt[k]);
                Console.ResetColor();
            }
            return k;
        }
        private static int Stroka(int k)
        {
            switch (k)
            {
                case var _ when k < 109:return 0;
                case var _ when k < 200:return 1;
                case var _ when k < 290:return 2;
                case var _ when k < 401:return 3;
                case var _ when k < 475:return 4;
                default: return 0;
            }
        }
        private static int Otstup(int k)
        {
            switch (k)
            {
                case var _ when k < 109: return 0;
                case var _ when k < 200: return 109;
                case var _ when k < 290: return 200;
                case var _ when k < 401: return 290;
                case var _ when k < 475: return 401;
                default: return 0;
            }
        }

    }
}
