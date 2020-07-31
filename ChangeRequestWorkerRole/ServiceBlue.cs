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

namespace ChangeRequestWorkerRole
{
    public class ServiceBlue : IChangeRequest
    {

        CloudQueue queue = QueueHelper.GetQueueReference("projekatqueue");

        public void ChangeWorkerRole(string worker_role)
        {
            queue.AddMessage(new CloudQueueMessage(worker_role));

            Trace.WriteLine("Selected Entity Handler: " + worker_role);



            NetTcpBinding binding2 = new NetTcpBinding();

            EndpointAddress address = new EndpointAddress("net.tcp://localhost:8901/InputRequest_QueueRequest");

            ChannelFactory<IQueueRequest> channelFactory = new ChannelFactory<IQueueRequest>(binding2, address);

            IQueueRequest proxy = channelFactory.CreateChannel();

            proxy.QueueMessage();
        }

        public void ChangeWorkerRole2(string worker_role)
        {
            queue.AddMessage(new CloudQueueMessage(worker_role));

            Trace.WriteLine("Selected Entity Handler: " + worker_role);

            NetTcpBinding binding2 = new NetTcpBinding();

            EndpointAddress address = new EndpointAddress("net.tcp://localhost:8901/InputRequest_QueueRequest");

            ChannelFactory<IQueueRequest> channelFactory = new ChannelFactory<IQueueRequest>(binding2, address);

            IQueueRequest proxy = channelFactory.CreateChannel();

            proxy.QueueMessage();
        }
    }
}
