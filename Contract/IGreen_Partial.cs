using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    [ServiceContract]
    public interface IGreen_Partial
    {
        [OperationContract]
        void DodajLiniju(int id, char[] oznaka);
    }
}
