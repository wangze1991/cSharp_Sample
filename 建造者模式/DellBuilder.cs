using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 建造者模式
{
    /// <summary>
    /// 建造者实现类
    /// </summary>
    public class DellBuilder:Builder
    {
        public override void CreateCompeterName()
        {
            throw new NotImplementedException();
        }
        public override void CreateMemory()
        {
            throw new NotImplementedException();
        }
        public override void CreateMotherBand()
        {
            throw new NotImplementedException();
        }
    }
}
