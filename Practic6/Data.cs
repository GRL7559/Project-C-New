using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic6
{
    public class Data
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public string Clothes { get; set; }
        public Data(int age, string name, string clothes)
        {
            Age = age;
            Name = name;
            Clothes = clothes;
        }
        public Data()
        {
            Age = 0;
            Name = string.Empty;
            Clothes = string.Empty;
        }
    }
}
