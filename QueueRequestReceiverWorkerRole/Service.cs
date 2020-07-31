using Contract;
using Microsoft.WindowsAzure.Storage.Queue;
using ServiceData;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace QueueRequestReceiverWorkerRole
{
    public class Service : IQueueRequest
    {

        CloudQueue queue = QueueHelper.GetQueueReference("projekatqueue");

       public void QueueMessage()
        {
            string message = queue.GetMessage().AsString;


            NetTcpBinding binding2 = new NetTcpBinding();

            EndpointAddress address = new EndpointAddress("net.tcp://localhost:8903/InputRequest_WebRole");

            ChannelFactory<IQueueRequest_WebRole> channelFactory = new ChannelFactory<IQueueRequest_WebRole>(binding2, address);

            IQueueRequest_WebRole proxy = channelFactory.CreateChannel();

            proxy.QueueMessage(message);
        }
    }
}
