using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebRole.Models
{
    public class Vozac
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string ime;

        public string Ime
        {
            get { return ime; }
            set { ime = value; }
        }

        private string oznaka;

        [StringLength(8, MinimumLength = 1, ErrorMessage = "Length of oznaka must be between 1 and 8!")]
        public string Oznaka
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

        public Vozac(int id, string ime, string oznaka, string prezime)
        {
            this.id = id;
            this.ime = ime;
            this.oznaka = oznaka;
            this.prezime = prezime;
        }
    }
}