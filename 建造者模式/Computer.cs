using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 建造者模式
{
    /// <summary>
    /// 计算机产品类
    /// </summary>
    public class Computer
    {
        public string Name { get; set; }
        public string MemorySize { get; set; }
        public string MotherBand { get; set; }

        public void ShowComputerInfo() {
            Console.WriteLine("电脑名称:{0}",this.Name);
            Console.WriteLine("电脑内存:{0}",this.MemorySize);
            Console.WriteLine("主板名称:{1}", this.MotherBand);
        }
    }
}
