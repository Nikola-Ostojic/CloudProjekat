using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceData
{
    public class TableRepositoryAutobus
    {
        private CloudStorageAccount storageAccount;
        private CloudTable table;

        public TableRepositoryAutobus()
        {
            storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("DataConnectionString_Autobus"));

            CloudTableClient tableClient = new CloudTableClient(new Uri(storageAccount.TableEndpoint.AbsoluteUri), storageAccount.Credentials);

            table = tableClient.GetTableReference("ProjekatTableAutobus");

            table.CreateIfNotExists();
        }

        public void AddOrReplaceAutobus(Autobus autobus)
        {
            TableOperation insertOperation = TableOperation.InsertOrReplace(autobus);

            table.Execute(insertOperation);
        }
    }
}
