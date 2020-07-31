using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using WebRole.Controllers;

namespace WebRole
{
    public class WebRole : RoleEntryPoint
    {
        public override bool OnStart()
        {
            // For information on handling configuration changes
            // see the MSDN topic at https://go.microsoft.com/fwlink/?LinkId=166357.

            Thread nit = new Thread(() => 

            {
                Serverr serverr = new Serverr();

                serverr.JobServer();

                serverr.Open();

            });
            nit.IsBackground = true;
            nit.Start();

            return base.OnStart();
        }
    }
}
