using Contract;
using Microsoft.WindowsAzure.ServiceRuntime;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EntityHandlerGreenWorkerRole
{
    public class PartialServer
    {
        private ServiceHost serviceHost;

        private string externalEndpoint = "InternalRequest";

        public void JobServer()
        {
            NetTcpBinding binding = new NetTcpBinding();

            RoleInstanceEndpoint roleInstance = RoleEnvironment.CurrentRoleInstance.InstanceEndpoints[externalEndpoint];


            serviceHost = new ServiceHost(typeof(PartialServerProvider));

            serviceHost.AddServiceEndpoint(typeof(IGreen_Partial), binding, String.Format("net.tcp://{0}/{1}", roleInstance.IPEndpoint, externalEndpoint));


        }

        public void Open()
        {
            try
            {
                serviceHost.Open();

                Trace.TraceInformation(String.Format("Host for {0} endpoint type opened successfully at {1}", externalEndpoint, DateTime.Now));
            }
            catch (Exception e)
            {
                Trace.TraceInformation("Host open error for {0} endpoint type. Error message is: {1}. ", externalEndpoint, e.Message);
            }
        }

        public void Close()
        {
            try
            {
                serviceHost.Close();

                Trace.TraceInformation(String.Format("Host for {0} endpoint type closed successfully at {1}", externalEndpoint, DateTime.Now));
            }
            catch (Exception e)
            {
                Trace.TraceInformation("Host close error for {0} endpoint type. Error message is: {1}. ", externalEndpoint, e.Message);
            }
        }
    }
}
