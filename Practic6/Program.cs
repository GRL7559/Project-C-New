using Newtonsoft.Json;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Practic6
{
    internal class Program
    {
        static void Main()
        {
            List<Data> data = Read_file();
            bool stop = true;
            while (stop == true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.Enter:
                        Convert_file(data);
                        stop = false;
                        break;
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("нажмите Enter для продолжения работы с выбранным файлом или Esc для выхода из программы");
                        break;

                }
            }
        }
        private static List<Data> Read_file()
        {
            while (true)
            {
                Console.WriteLine("Какой файл нужно прочитать? (Укажите полный путь до файла и его расширение)");
                string path_file = Console.ReadLine();
                if (path_file.EndsWith(".txt"))
                {
                    List<Data> txt_data = new();
                    string[] txt_lines = File.ReadAllLines(path_file);
                    for (int i = 0; i < txt_lines.Length; i += 3)
                    {
                        int Age = Convert.ToInt32(txt_lines[i]);
                        string Name = txt_lines[i + 1];
                        string Clothes = txt_lines[i + 2];
                        Console.WriteLine($"{Age}\n{Name}\n{Clothes}");
                        Data txt_file = new(Age, Name, Clothes);
                        txt_data.Add(txt_file);
                    }
                    return txt_data;
                }
                else if (path_file.EndsWith(".xml"))
                {
                    XmlSerializer xml_file = new(typeof(List<Data>));
                    using FileStream fs = new(path_file, FileMode.Open);
                    List<Data> Xml_data = (List<Data>)xml_file.Deserialize(fs);
                    for (int i = 0; i < Xml_data.Count; i++)
                    {
                        Console.WriteLine(Xml_data[i].Age);
                        Console.WriteLine(Xml_data[i].Name);
                        Console.WriteLine(Xml_data[i].Clothes);
                    }
                    return Xml_data;
                }
                else if (path_file.EndsWith(".json"))
                {
                    string J_file = File.ReadAllText(path_file);
                    List<Data> json_data = JsonConvert.DeserializeObject<List<Data>>(J_file);
                    for (int i = 0; i < json_data.Count; i++)
                    {
                        Console.WriteLine(json_data[i].Age);
                        Console.WriteLine(json_data[i].Name);
                        Console.WriteLine(json_data[i].Clothes);
                    }
                    return json_data;
                }
                else
                {
                    Console.WriteLine("Вы ввели некорректный путь или расширение");
                }
            }       
        }
        public static void Convert_file(List<Data> data)
        {
            while (true)
            {
                Console.WriteLine("Куда и в каком формате нужно сохранить данные ? (Укажите полный путь до файла и его расширение)");
                string path_file = Console.ReadLine();

                if (path_file.EndsWith(".txt"))
                {
                    string[] txt_lines = new string[data.Count * 3];
                    for (int i = 0; i < data.Count; i++)
                    {
                        txt_lines[i + i * 2] = Convert.ToString(data[i].Age);
                        txt_lines[i + 1 + i * 2] = data[i].Name;
                        txt_lines[i + 2 + i * 2] = data[i].Clothes;

                    }
                    File.WriteAllLines(path_file, txt_lines);
                    return;
                }
                else if (path_file.EndsWith(".xml"))
                {
                    XmlSerializer xml = new(typeof(List<Data>));
                    using FileStream fs = new(path_file, FileMode.OpenOrCreate);
                    xml.Serialize(fs, data);
                    return;
                }
                else if (path_file.EndsWith(".json"))
                {
                    string json_data = JsonConvert.SerializeObject(data, Formatting.Indented);
                    File.WriteAllText(path_file, json_data);
                    return;
                }
                else
                {
                    Console.WriteLine("Вы ввели некорректный путь или расширение");
                }
            }
        }
    }
}