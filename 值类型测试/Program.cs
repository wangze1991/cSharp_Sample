using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 值类型测试
{
    class Program
    {
        static void Main(string[] args)
        {
           Dictionary<string,bool> dict=new Dictionary<string, bool>();
            dict.Add("1",false);
            dict.Add("2",false);
            string key = string.Empty;
            foreach (var keyValuePair in dict)
            {
                if (keyValuePair.Key == "1")
                {
                    key = keyValuePair.Key;
                }
            }

            dict[key] = true;
            //dict.FirstOrDefault(x => x.Key == "1").Value = true;
            //KeyValuePair<string,bool>

        }
    }
}
