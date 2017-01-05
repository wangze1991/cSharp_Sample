using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 建造者模式
{
   public  class LenovoBuilder:Builder
    {
       public override void CreateCompeterName()
       {
           this.Product.Name = "联想";
       }
       public override void CreateMemory()
       {
           this.Product.MemorySize = "2G";
       }
       public override void CreateMotherBand()
       {
           this.Product.MotherBand = "技嘉";
       }
    }
}
