using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic7
{
    static class Change
    {
        public static void Delete(string dir, int pos)
        {
            Console.SetCursorPosition(0, pos);
            Console.WriteLine("Вы точно хотите удалить этот объект?");
            string confirm = Console.ReadLine();
            string type = Files.Check_Type(dir);
            switch (confirm)
            {
                case "да":
                    switch (type)
                    {
                        case "file":
                            File.Delete(dir);
                            break;
                        case "Dir":
                            Directory.Delete(dir, true);
                            break;
                    }
                    break;
                case "нет":
                    break;
                default:
                    Console.WriteLine("Введено некоректное значение");
                    break;
            }
        }
        public static void Create(string dir, int pos)
        {
            Console.SetCursorPosition(0, pos);
            Console.WriteLine("Что вы хотите создать ? 1.Файл 2.Директория");
            int type = Convert.ToInt32(Console.ReadLine());
            switch (type)
            {
                case 1:
                    Create_File(dir);
                    break;
                case 2:
                    Create_Dir(dir);
                    break;
                default:
                    Console.WriteLine("Введено некорректное значение");
                    break;
            }
        }
        private static void Create_File(string dir)
        {
            Console.Write("Введите имя файла: ");
            string file_Name = Console.ReadLine();
            Console.Write("Введите расширения файла(без точки): ");
            string extend = Console.ReadLine();
            string filePath = Path.Combine(dir, file_Name + "." + extend);
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
        }
        private static void Create_Dir(string parent_dir)
        {
            Console.Write("Введите имя директории: ");
            string dir_Name = Console.ReadLine();
            string dir_path = Path.Combine(parent_dir, dir_Name);
            if (!Directory.Exists(dir_path))
            {
                Directory.CreateDirectory(dir_path);
            }
        }
    }
}