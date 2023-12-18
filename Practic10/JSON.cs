using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic10
{
    internal class JSON
    {
        public static void Serialization<T>(string path,T data)
        {
            string jsonData = JsonConvert.SerializeObject(data);
            File.WriteAllText(path, jsonData);
        }
        public static T Deserialization<T>(string path)
        {
            string jsonData = File.ReadAllText(path);
            T data = JsonConvert.DeserializeObject<T>(jsonData);
            return data;
        }
    }
}
