using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace LinqToJson
{
    class Program
    {
        static void Main(string[] args)
        {
            string json = @"{
                        'page':'1',
                        'pageSize':'10',
                        'name':'wangnze'                    
                     }";
            JObject jObject = JObject.Parse(json);
            foreach (var item in jObject)
            {
                System.Console.WriteLine(item.Key);
                System.Console.WriteLine(item.Value.Value<string>());
            }
            Console.ReadKey();
        }
    }
}
