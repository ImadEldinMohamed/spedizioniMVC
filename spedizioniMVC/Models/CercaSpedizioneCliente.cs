using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace spedizioniMVC.Models
{
    public class CercaSpedizioneCliente
    {

        public string CF { get; set; }

        public int IDspedizione { get; set; }  

        public CercaSpedizioneCliente() { }

        public CercaSpedizioneCliente(string CF, int IDspedizione)
        {
            this.CF = CF;
            this.IDspedizione = IDspedizione;
        }
    }
}