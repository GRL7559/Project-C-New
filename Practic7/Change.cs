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
        public static void Delete(string dir)
        {
            string type = Files.Check_Type(dir);
            switch (type)
            {
                case "file":
                    Delete_File(dir);
                    break;
                case "Dir":
                    Delete_Dir(dir);
                    break;
            }
        }
        public static void Create(string dir)
        {
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
            }
        }
        private static void Create_File(string dir)
        {
            Console.Write("Введите имя файла: ");
            string file_Name = Console.ReadLine();
            Console.Write("Введите расширения файла: ");
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
        private static void Delete_File(string file_path)
        {
            if (File.Exists(file_path))
            {
                File.Delete(file_path);
                Console.WriteLine("Файл успешно удален.");
            }
            else
            {
                Console.WriteLine("Файл не найден.");
            }
        }
        private static void Delete_Dir(string dir_path)
        {
            {
                if (Directory.Exists(dir_path))
                {
                    Directory.Delete(dir_path, true);
                    Console.WriteLine("Директория успешно удалена.");
                }
                else
                {
                    Console.WriteLine("Директория не найдена.");
                }
            }
        }
    }
}
