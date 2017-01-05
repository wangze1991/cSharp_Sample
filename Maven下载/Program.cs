using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
namespace Maven下载
{
    class Program
    {
        static void Main(string[] args)
        {
          string str=  Utils.HttpHelper.GetHtml("http://repo.maven.apache.org/maven2/archetype-catalog.xml");
          Console.WriteLine(str);
          Console.ReadKey();
        }
    }
}
