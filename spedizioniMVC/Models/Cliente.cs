using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace spedizioniMVC.Models
{
    public class Cliente
    {
        public int IDcliente { get; set; }

        public string nome { get; set; }    

        public string cognome { get; set; }

        public string residenza { get; set; }

        public string CF { get; set; }  

        public DateTime DataDiNascita { get; set; }

        public Cliente() { }

        public Cliente( string nome, string cognome, string residenza, string CF, DateTime DataDiNascita)
        {
         
            this.nome = nome;
            this.cognome = cognome;
            this.residenza = residenza;
            this.CF = CF;
            this.DataDiNascita = DataDiNascita;
        }
    }
}