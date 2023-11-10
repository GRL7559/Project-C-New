using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic8
{
    internal class Body
    {
        static TimeSpan remainingTime;
        public static int[] Main()
        {
            Console.Clear();
            string txt = "Да, такова была моя участь с самого детства. Все читали на моем лице признаки дурных чувств, которых не было;но их предполагали - и они родились. Я был скромен - меня обвиняли в лукавстве: я стал скрытен.Я глубоко чувствовал добро и зло; никто меня не ласкал, все оскорбляли: я стал злопамятен;я был угрюм, - другие дети веселы и болтливы; я чувствовал себя выше их, - меня ставили ниже. Я сделался завистлив.Я был готов любить весь мир, - меня никто не понял: и я выучился ненавидеть.";
            int k = 0;
            Console.WriteLine("Да, такова была моя участь с самого детства. Все читали на моем лице признаки дурных чувств, которых не было;\nно их предполагали - и они родились. Я был скромен - меня обвиняли в лукавстве: я стал скрытен.\r\nЯ глубоко чувствовал добро и зло; никто меня не ласкал, все оскорбляли: я стал злопамятен;\nя был угрюм, - другие дети веселы и болтливы; я чувствовал себя выше их, - меня ставили ниже. Я сделался завистлив.\nЯ был готов любить весь мир, - меня никто не понял: и я выучился ненавидеть.");
            bool timer_finish = false;
            Thread timer = new(() =>
            {
                Console.SetCursorPosition(1, 6);
                Stopwatch stopwatch = new();
                stopwatch.Start();
                TimeSpan duration = TimeSpan.FromMinutes(1);
                while (stopwatch.Elapsed < duration && k  < txt.Length)
                {
                    Console.SetCursorPosition(1, 6);
                    remainingTime = duration - stopwatch.Elapsed;
                    Console.WriteLine("Оставшееся время: " + remainingTime.ToString(@"mm\:ss"));
                    Thread.Sleep(1000);
                }
                timer_finish = true;
            });
            timer.Start();
            while (k < txt.Length && !timer_finish)
            {
                k=Insert.Correct(txt,k);
            }
            int[] result = new int[] { k, (int)remainingTime.TotalSeconds };
            return result;
        }
    }
}
