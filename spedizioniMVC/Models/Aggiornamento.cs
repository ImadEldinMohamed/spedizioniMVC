using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace spedizioniMVC.Models
{
    public class Aggiornamento
    {
        public int IDaggiornamentoSpedizione { get; set; }  
        public int IDspedizione { get; set; }

        public string stato { get; set; }
         public string luogo { get; set; }

        public string descrizione { get; set; }

        public Aggiornamento() { }

        public Aggiornamento( int IDspedizione, string stato, string luogo, string descrizione)
        {
         
            this.IDspedizione = IDspedizione;
            this.stato = stato;
            this.luogo = luogo;
            this.descrizione = descrizione;
        }
    }
}