using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace spedizioniMVC.Models
{
    public class AggiornamentoSpedizioneAzienda
    {
        public int IDaggiornamentoSAzienda{ get; set; }
        public int IDspedizioneA { get; set; }

        public string stato { get; set; }
        public string luogo { get; set; }

        public string descrizione { get; set; }

        public AggiornamentoSpedizioneAzienda() { }

        public AggiornamentoSpedizioneAzienda(int IDspedizioneA, string stato, string luogo, string descrizione)
        {

            this.IDspedizioneA = IDspedizioneA;
            this.stato = stato;
            this.luogo = luogo;
            this.descrizione = descrizione;
        }
    }
}