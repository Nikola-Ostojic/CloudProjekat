using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceData
{
    public class Autobus : TableEntity
    {

        private string oznaka;

        public string Oznaka
        {
            get { return oznaka; }
            set { oznaka = value; }
        }

        public Autobus(String id, string oznaka)
        {
            PartitionKey = "Autobus";
            RowKey = id;

            this.oznaka = oznaka;
        }
    }
}
