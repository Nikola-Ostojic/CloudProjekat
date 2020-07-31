using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    [ServiceContract]
    public interface IQueueRequest_WebRole
    {
        [OperationContract]
        void QueueMessage(string message);
    }
}
