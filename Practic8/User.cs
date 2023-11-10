using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic8
{
    internal class User
    {
        public string user_name;
        public double second_score;
        public double minute_score;
        public User(string user_name, double second_score, double minute_score)
        {
            this.user_name = user_name;
            this.second_score = second_score;
            this.minute_score = minute_score;
        }
    }
}
