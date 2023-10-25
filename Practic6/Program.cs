using Newtonsoft.Json;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Practic6
{
    internal class Program
    {
        static void Main()
        {
            List<Data> data = new();
            Read_file();
            
        }
        static void Read_file()
        {

            Console.WriteLine("Какой файл нужно прочитать? (Укажите полный путь до файла и его расширение)");
            string path_file = Console.ReadLine();
            if (path_file.EndsWith(".txt"))
            {
                string txt_file = File.ReadAllText(path_file);
                List<Data> txt_data = JsonConvert.DeserializeObject<List<Data>>(txt_file);
                Convert_file(txt_data);
            }
            else if(path_file.EndsWith(".xml"))
            {
                XmlSerializer xml_file = new(typeof(List<Data>));
                using (FileStream fs = new(path_file, FileMode.Open))
                {
                    List<Data> Xml_data = (List<Data>)xml_file.Deserialize(fs);
                    Convert_file(Xml_data);
                }
            }
            else if (path_file.EndsWith(".json"))
            {
                string J_file = File.ReadAllText(path_file);
                List<Data> json_data = JsonConvert.DeserializeObject<List<Data>>(J_file);
                Console.WriteLine(json_data);
                Convert_file(json_data);
            }
        }
        public static void Convert_file(List<Data> data)
        {
            Console.WriteLine("Куда и в каком формате нужно сохранить данные ? (Укажите полный путь до файла и его расширение)");
            string path_file = Console.ReadLine();
            if (path_file.EndsWith(".txt"))
            {
                string txt_data = JsonConvert.SerializeObject(data);
                File.WriteAllText(path_file,txt_data);
            }
            else if (path_file.EndsWith(".xml"))
            {
                XmlSerializer xml = new(typeof(List<Data>));
                using (FileStream fs = new(path_file , FileMode.OpenOrCreate))
                {
                    xml.Serialize(fs,data);
                }
            }
            else if (path_file.EndsWith(".json"))
            {
                string json_data = JsonConvert.SerializeObject(data,Formatting.Indented);
                File.WriteAllText(path_file, json_data);
            }
        }
    }
}