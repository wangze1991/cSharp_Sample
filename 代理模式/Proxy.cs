using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 代理模式
{
    public  class Proxy:IDrive  
    {
        private IDrive _driver;

        public Proxy(IDrive driver) {
            this._driver = driver;
        }
        public void Drive()
        {
            _driver.Drive();
        }
    }
}
