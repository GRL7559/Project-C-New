using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Practic8
{
    static class Score
    {
        public static void Record(string name_user, int symbols, int time)
        {
            double second_score;
            if (time == 0)
            {
                second_score = (double)symbols / 60.0; ;
            }
            else
            {
                second_score = (double)symbols / (double)time;
            }
            second_score = Math.Round(second_score,2);
            string user_name = name_user;
            double minute_score = second_score*60;
            User scoreData = new(user_name, second_score, minute_score);
            List<User> jsonData =new() {};

            if (File.Exists("Score.json"))
            {
                string json_file = File.ReadAllText("Score.json");
                jsonData = JsonConvert.DeserializeObject<List<User>>(json_file);
            }
            jsonData.Add(scoreData);
            jsonData = jsonData.OrderBy(user => user.second_score).ToList();
            string updatedJsonData = JsonConvert.SerializeObject(jsonData);
            File.WriteAllText("Score.json", updatedJsonData);
        }
        public static void Leaderbord()
        {
            Console.Clear();
            Console.WriteLine("Таблица лидеров");
            string json_file = File.ReadAllText("Score.json");
            List<User> json_data = JsonConvert.DeserializeObject <List<User>>(json_file);
            foreach (var item in json_data) 
            {
                Console.WriteLine(item.user_name);
                Console.WriteLine(item.second_score);
                Console.WriteLine(item.minute_score);
            }
        }
    }
}
