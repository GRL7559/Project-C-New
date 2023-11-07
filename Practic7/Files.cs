using Practic5;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic7
{
    static class Files
    {
        public static string Check_Type(string obj)
        {
            if (File.Exists(obj))
            {
                return "file";
            }
            else if (Directory.Exists(obj))
            {
                return "Dir";
            }
            else
            {
                return "NONE";
            }
        }
        private static void Show_Dir(string dir = "C:\\Program Files")
        {
            while (true)
            {

                int k = 9;
                Console.Clear();
                Console.WriteLine("Enter - Перейти в директорию / открыть файл\nEscape - Выйти из директории / Закрыть программу\nD - удалить файл\tC - создать файл\nUpArrow - вверх \tDownArrow - вниз");
                Console.WriteLine(new string('-', 100));
                Console.WriteLine($"Текущий путь : {dir} ");
                Console.WriteLine(new string('-', 100));
                Console.WriteLine($"  {"Имя", -40} {"Размер в Кб", -25} Дата последнего изменения");
                Console.WriteLine(new string('-', 100));
                string[] paths = Directory.GetDirectories(dir);
                string[] files = Directory.GetFiles(dir);
                string[] Direct = paths.Concat(files).ToArray();
                foreach (string path in paths)
                {

                    Console.WriteLine($"  {Path.GetFileName(path),-70}{File.GetLastWriteTime(path)}");
                    k += 1;
                }
                foreach (string file in files)
                {
                    FileInfo lenfile = new(file);
                    Console.WriteLine($"  {Path.GetFileName(file),-42}{(lenfile.Length) / 1024 , - 28}{File.GetLastWriteTime(file)}");
                    k += 1;
                }
                int[] pos = Arrows.Arrow(k - 1, 9);
                switch (pos[0])
                {
                    case -1: break;
                    case -7559: return;
                    case -200:
                        Change.Delete(Direct[pos[1] - 9], k + 1);
                        continue;
                    case -8:
                        Change.Create(dir, k + 1);
                        continue;
                }
                string type = Check_Type(Direct[pos[1] - 9]);
                switch (type)
                {
                    case "file":
                        if (Direct[pos[1] - 9].EndsWith(".exe"))
                        {
                            Process.Start(Direct[pos[1] - 9]);
                        }
                        else
                        {
                            Process.Start(new ProcessStartInfo { FileName = Direct[pos[1] - 9], UseShellExecute = true });
                        }
                        break;
                    case "Dir":
                        Show_Dir(Direct[pos[1] - 9]);
                        break;
                    case "NONE":
                        Console.WriteLine("Указанный путь не является допустимым файлом или директорией.");
                        break;
                }
            }
        }
        public static void ChoiseDrive()
        {
            Console.WriteLine("Выбирите диск , с которым хотите начать работу.");
            DriveInfo[] Drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in Drives)
            {
                Console.WriteLine($"  Диск:{drive.Name}  Свободно {Math.Round(drive.TotalFreeSpace / Math.Pow(1024, 3))} ГБ из {Math.Round(drive.TotalSize / Math.Pow(1024, 3))} ГБ");
            }
            int[] pos = Arrows.Arrow(Drives.Length, 1);
            Console.WriteLine(Drives[pos[1] - 1].Name);
            Show_Dir(Drives[pos[1] - 1].Name);
            Console.Clear();
            Environment.Exit(0);
        }
    }
}
