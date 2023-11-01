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
        private static string Check_Type(string obj)
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
                Console.WriteLine("  Имя"+new string(' ', 20)+"\t\tразмер(в байтах)\t\tДата последнего изменения");
                Console.WriteLine(new string('-', 100));
                string[] paths = Directory.GetDirectories(dir);
                string[] files = Directory.GetFiles(dir);
                string[] Direct = paths.Concat(files).ToArray();
                foreach (string path in paths)
                {
                    //string indent = new(' ', 25 - Path.GetFileName(path).Length);{indent}
                    Console.WriteLine($"  {Path.GetFileName(path)}\t\t\t{path.Length}\t\t\t{File.GetLastWriteTime(path)}");
                    k += 1;
                }
                foreach (string file in files)
                {
                    //string indent = new(' ', 25 - Path.GetFileName(file).Length);{indent}
                    Console.WriteLine($"  {Path.GetFileName(file)}\t\t\t{file.Length}\t\t\t{File.GetLastWriteTime(file)}");
                    k += 1;
                }
                int pos = Arrows.Arrow(k-1, 9);
                if (pos == -7559)
                {
                    return;
                }
                string type = Check_Type(Direct[pos]);
                switch (type)
                {
                    case "file":
                        if (Direct[pos].EndsWith(".exe"))
                        {
                            Process.Start(Direct[pos]);
                        }
                        else
                        {
                            Process.Start(new ProcessStartInfo { FileName = Direct[pos], UseShellExecute = true });
                        }
                        break;
                    case "Dir":
                        Show_Dir(Direct[pos]);
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
                Console.WriteLine($"  Диск:{drive.Name}  Свободно {drive.TotalFreeSpace} из {drive.TotalSize} байт");
            }
            int pos = Arrows.Arrow(Drives.Length, 1) - 1;
            Console.WriteLine(Drives[pos].Name);
            Show_Dir(Drives[pos].Name);
            int pos_d = Directory.GetDirectories(Drives[pos].Name).Length + Directory.GetFiles(Drives[pos].Name).Length;
            Console.SetCursorPosition(0, pos_d+1);
            Environment.Exit(0);
        }
    }
}
