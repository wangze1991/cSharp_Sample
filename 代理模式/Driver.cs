using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 代理模式
{
    public  class Driver:IDrive
    {
        public string Name { get; set; }

        public Driver(string name)
        {
            this.Name = name;
        }

        public void Drive()
        {
            Console.WriteLine("{0}:司机会开车",this.Name);
        }
    }
}
