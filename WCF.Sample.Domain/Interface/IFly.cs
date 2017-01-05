using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCF.Sample.Domain
{
    [ServiceContract]
    public interface IFly
    {
        [OperationContract]
        string Fly(string name);
    }
}
