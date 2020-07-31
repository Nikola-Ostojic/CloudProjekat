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
    public class TableRepositoryVozac
    {
        private CloudStorageAccount storageAccount;
        private CloudTable table;

        public TableRepositoryVozac()
        {
            storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("DataConnectionString_Vozac"));

            CloudTableClient tableClient = new CloudTableClient(new Uri(storageAccount.TableEndpoint.AbsoluteUri), storageAccount.Credentials);

            table = tableClient.GetTableReference("ProjekatTableVozac");

            table.CreateIfNotExists();
        }

        public void AddOrReplaceVozac(Vozac vozac)
        {
            TableOperation insertOperation = TableOperation.InsertOrReplace(vozac);

            table.Execute(insertOperation);
        }
    }
}
