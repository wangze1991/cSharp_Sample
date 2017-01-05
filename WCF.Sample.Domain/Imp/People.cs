using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.Sample.Domain
{
    public class People:IFly
    {
        public string Fly(string name)
        {
            return name + ", you can fly!";
        }
    }
}
