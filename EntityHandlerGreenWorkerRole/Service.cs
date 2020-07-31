using Contract;
using Microsoft.WindowsAzure.ServiceRuntime;
using ServiceData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EntityHandlerGreenWorkerRole
{
    public class Service : IGreen
    {
        public NetTcpBinding binding = new NetTcpBinding();

        private string internalEndpoints = "InternalRequest";

        public void DodajLiniju(int id, char[] oznaka)
        {
            foreach (RoleInstance instance in RoleEnvironment.Roles[RoleEnvironment.CurrentRoleInstance.Role.Name].Instances)
            {
                if (instance.Id == RoleEnvironment.CurrentRoleInstance.Id && 0 <= RoleEnvironment.Roles[RoleEnvironment.CurrentRoleInstance.Role.Name].Instances.IndexOf(instance) && RoleEnvironment.Roles[RoleEnvironment.CurrentRoleInstance.Role.Name].Instances.IndexOf(instance) <= 1)
                {
                    IGreen_Partial proxy = new ChannelFactory<IGreen_Partial>(binding, new EndpointAddress(String.Format("net.tcp://{0}/{1}", instance.InstanceEndpoints[internalEndpoints].IPEndpoint.ToString(), internalEndpoints))).CreateChannel();

                    proxy.DodajLiniju(id, oznaka);

                    return;
                }
            }

            TableRepositoryLinija table = new TableRepositoryLinija();

            table.AddOrReplaceLinija(new Linija(id.ToString(), oznaka));
        }
    }
}
