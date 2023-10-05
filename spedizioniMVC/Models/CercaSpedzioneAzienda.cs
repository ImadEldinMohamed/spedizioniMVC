using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace spedizioniMVC.Models
{
    public class CercaSpedzioneAzienda
    {

        public string P_iva { get; set; }
        public int IDspedizioneA { get; set; }

        public CercaSpedzioneAzienda() { }

        public CercaSpedzioneAzienda(string p_iva, int iDspedizioneA)
        {
            P_iva = p_iva;
            IDspedizioneA = iDspedizioneA;
        }
    }
}