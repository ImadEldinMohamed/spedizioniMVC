﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace spedizioniMVC.Models
{
    public class Spedizione
    {
        public int IDspedizione { get; set; } 

        public double peso { get; set; }    

        public DateTime dataspedizione { get; set; }

        public string destinazione { get; set; }

        public double prezzo { get; set; }  

        public DateTime dataconsegna { get; set; }  
        public int IDcliente { get; set;}

      

        public Spedizione() { }

        public Spedizione(double peso, DateTime dataspedizione, string destinazione, double prezzo, DateTime dataconsegna,int IDcliente)
        {
          
            this.peso = peso;
            this.dataspedizione = dataspedizione;
            this.destinazione = destinazione;
            this.prezzo = prezzo;
            this.dataconsegna = dataconsegna;
            this.IDcliente = IDcliente;
        }
    }
}