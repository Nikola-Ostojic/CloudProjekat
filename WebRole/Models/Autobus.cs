using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebRole.Models
{
    public class Autobus
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string oznaka;

        public string Oznaka
        {
            get { return oznaka; }
            set { oznaka = value; }
        }

        public Autobus(int id, string oznaka)
        {
            this.id = id;
            this.oznaka = oznaka;
        }
    }
}