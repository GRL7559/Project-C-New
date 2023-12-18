using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic10
{
    internal class ICRUD
    {
        public static void Create<T>(string path, T data)
        {
            JSON.Serialization(path, data);
        }

        public static T Read<T>(string path)
        {
            T data = JSON.Deserialization<T>(path);
            return data;
        }

        public static void Update<T>(string path, T newData)
        {
            Delete(path);
            Create<T>(path, newData);
        }

        public static void Delete(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
        public static void ICRUD_menu()
        {
            Console.SetCursorPosition(0,1);
            Console.WriteLine(new string('-', 120));
            for (int i = 1; i < 20; i++) 
            {
                Console.SetCursorPosition(100, 1+i);
                Console.WriteLine('|');
            }
        }
    }
}
