using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceData
{
    public class Linija : TableEntity
    {

        private char[] oznaka;

        public char[] Oznaka
        {
            get { return oznaka; }
            set { oznaka = value; }
        }

        public Linija(String id, char[] oznaka)
        {
            PartitionKey = "Linija";
            RowKey = id;

            this.oznaka = oznaka;
        }
    }
}
