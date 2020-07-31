using Contract;
using Microsoft.WindowsAzure.ServiceRuntime;
using ServiceData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EntityHandlerBlueWorkerRole
{
    public class Service : IBlue1
    {
        public NetTcpBinding binding = new NetTcpBinding();

        private string internalEndpoints = "InternalRequest";

        public void DodajAutobus(int id, string oznaka)
        {
            foreach (RoleInstance instance in RoleEnvironment.Roles[RoleEnvironment.CurrentRoleInstance.Role.Name].Instances)
            {
                if (instance.Id == RoleEnvironment.CurrentRoleInstance.Id && 0 <= RoleEnvironment.Roles[RoleEnvironment.CurrentRoleInstance.Role.Name].Instances.IndexOf(instance) && RoleEnvironment.Roles[RoleEnvironment.CurrentRoleInstance.Role.Name].Instances.IndexOf(instance) <= 1)
                {
                    IBlue1_Partial proxy = new ChannelFactory<IBlue1_Partial>(binding, new EndpointAddress(String.Format("net.tcp://{0}/{1}", instance.InstanceEndpoints[internalEndpoints].IPEndpoint.ToString(), internalEndpoints))).CreateChannel();

                    proxy.DodajAutobus(id, oznaka);

                    return;
                }
            }

            TableRepositoryAutobus table = new TableRepositoryAutobus();

            table.AddOrReplaceAutobus(new Autobus(id.ToString(), oznaka));
        }

        public void DodajVozaca(int id, string ime, char[] oznaka, string prezime)
        {
            foreach (RoleInstance instance in RoleEnvironment.Roles[RoleEnvironment.CurrentRoleInstance.Role.Name].Instances)
            {
                if (instance.Id == RoleEnvironment.CurrentRoleInstance.Id && 0 <= RoleEnvironment.Roles[RoleEnvironment.CurrentRoleInstance.Role.Name].Instances.IndexOf(instance) && RoleEnvironment.Roles[RoleEnvironment.CurrentRoleInstance.Role.Name].Instances.IndexOf(instance) <= 1)
                {
                    IBlue1_Partial proxy = new ChannelFactory<IBlue1_Partial>(binding, new EndpointAddress(String.Format("net.tcp://{0}/{1}", instance.InstanceEndpoints[internalEndpoints].IPEndpoint.ToString(), internalEndpoints))).CreateChannel();

                    proxy.DodajVozaca(id, ime, oznaka, prezime);

                    return;
                }
            }

            TableRepositoryVozac table = new TableRepositoryVozac();

            table.AddOrReplaceVozac(new ServiceData.Vozac(id.ToString(), ime, oznaka, prezime));
        }
    }
}
