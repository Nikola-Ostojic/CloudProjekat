using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Contract;
using System.Threading;

namespace EntityHandlerSelector
{
    class Program
    {
        static void Main(string[] args)
        {
            //NetTcpBinding binding = new NetTcpBinding();

            //EndpointAddress address2 = new EndpointAddress("net.tcp://localhost:8889/InputRequest1_ChangeRequest");

            //ChannelFactory<IChangeRequest> channelFactory = new ChannelFactory<IChangeRequest>(binding, address2);

            //IChangeRequest proxy = channelFactory.CreateChannel();

            while (true)
            {

                Console.WriteLine("If you want to change entity handlers type 'Blue' or 'Green' else type anything else. Initially Blue Entity is handler for requests.");

                string command = Console.ReadLine();

                

                if (command.Equals("Blue"))
                {

                    Task.Factory.StartNew(() =>
                    {
                        NetTcpBinding binding = new NetTcpBinding();

                        EndpointAddress address2 = new EndpointAddress("net.tcp://localhost:8889/InputRequest1_ChangeRequest");

                        ChannelFactory<IChangeRequest> channelFactory = new ChannelFactory<IChangeRequest>(binding, address2);

                        IChangeRequest proxy = channelFactory.CreateChannel();

                        proxy.ChangeWorkerRole("Blue");

                    });
                    
                }
                else if (command.Equals("Green"))
                {
                    Task.Factory.StartNew(() =>
                    {
                        NetTcpBinding binding = new NetTcpBinding();

                        EndpointAddress address2 = new EndpointAddress("net.tcp://localhost:8889/InputRequest1_ChangeRequest");

                        ChannelFactory<IChangeRequest> channelFactory = new ChannelFactory<IChangeRequest>(binding, address2);

                        IChangeRequest proxy = channelFactory.CreateChannel();

                        proxy.ChangeWorkerRole("Green");

                    });
                }
                else
                {
                    Task.Factory.StartNew(() =>
                    {
                        NetTcpBinding binding = new NetTcpBinding();

                        EndpointAddress address2 = new EndpointAddress("net.tcp://localhost:8889/InputRequest1_ChangeRequest");

                        ChannelFactory<IChangeRequest> channelFactory = new ChannelFactory<IChangeRequest>(binding, address2);

                        IChangeRequest proxy = channelFactory.CreateChannel();

                        proxy.ChangeWorkerRole("Blue");

                    });
                }

                
            }
        }
    }
}
