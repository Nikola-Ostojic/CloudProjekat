using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceData
{
    public class Vozac : TableEntity
    {

        private string ime;

        public string Ime
        {
            get { return ime; }
            set { ime = value; }
        }

        private char[] oznaka;

        public char[] Oznaka
        {
            get { return oznaka; }
            set { oznaka = value; }
        }

        private string prezime;

        public string Prezime
        {
            get { return prezime; }
            set { prezime = value; }
        }

        public Vozac(String id, string ime, char[] oznaka, string prezime)
        {
            PartitionKey = "Vozac";
            RowKey = id;
            
            this.ime = ime;
            this.oznaka = oznaka;
            this.prezime = prezime;
        }
    }
}
