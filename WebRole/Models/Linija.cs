using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebRole.Models
{
    public class Linija
    {
        private int id;

        
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string oznaka;

        [StringLength(5, MinimumLength = 1, ErrorMessage = "Length of field oznaka must be between 1 and 5!")]
        public string Oznaka
        {
            get { return oznaka; }
            set { oznaka = value; }
        }

        public Linija(int id, string oznaka)
        {
            this.id = id;
            this.oznaka = oznaka;
        }
    }
}