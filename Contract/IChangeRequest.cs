using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    [ServiceContract]
    public interface IChangeRequest
    {
        [OperationContract]
         void ChangeWorkerRole(string worker_role);

        [OperationContract]
        void ChangeWorkerRole2(string worker_role);
    }
}
