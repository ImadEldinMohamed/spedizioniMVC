using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace spedizioniMVC.Models
{
    public class Azienda
    {
        public int IDazienda { get; set; }

        public string nome { get; set; }

        public string P_iva { get; set; }

        public Azienda() { }

        public Azienda(string nome,string P_iva) { 
           this.nome = nome;    
            this.P_iva = P_iva;
        
        }
    }
}