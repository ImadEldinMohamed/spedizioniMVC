using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace spedizioniMVC.Models
{
    public class Utente
    {
        public string username { get; set; }

        public string password { get; set; }

        public string role { get; set; }



        public Utente() { } 

        public Utente(string username, string password) { }
        public Utente(string username, string password, string role)
        {
            this.username = username;
            this.password = password;
            this.role = role;
        }
    }

}