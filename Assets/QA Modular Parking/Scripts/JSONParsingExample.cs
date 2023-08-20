using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace JSONParsingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonData = "[ { \"name\": \"entry\", \"x\": 2, \"y\": -10 }, { \"name\": \"mark_2\", \"x\": 2, \"y\": 0 } ]";
            List<Dictionary<string, object>> jsonObj = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(jsonData);

            foreach (Dictionary<string, object> item in jsonObj)
            {
                string name = item["name"].ToString();
                int x = Convert.ToInt32(item["x"]);
                int y = Convert.ToInt32(item["y"]);

                Console.WriteLine($"Name: {name}, x: {x}, y: {y}");
            }

            Console.ReadLine();
        }
    }
}
