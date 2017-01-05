using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 建造者模式
{

    /// <summary>
    /// 建造者
    /// </summary>
    public abstract class Builder
    {
        public Computer Product { get; set; }
        public Builder() {
            this.Product = new Computer();
        }

        abstract public void CreateCompeterName();
        abstract public void CreateMemory();

        abstract public void CreateMotherBand();
    }
}
