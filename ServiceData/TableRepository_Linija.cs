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
    public class TableRepositoryLinija
    {
        private CloudStorageAccount storageAccount;
        private CloudTable table;

        public TableRepositoryLinija()
        {
            storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("DataConnectionString_Linija"));

            CloudTableClient tableClient = new CloudTableClient(new Uri(storageAccount.TableEndpoint.AbsoluteUri), storageAccount.Credentials);

            table = tableClient.GetTableReference("ProjekatTableLinija");

            table.CreateIfNotExists();
        }

        public void AddOrReplaceLinija(Linija linija)
        {
            TableOperation insertOperation = TableOperation.InsertOrReplace(linija);

            table.Execute(insertOperation);
        }
    }
}
