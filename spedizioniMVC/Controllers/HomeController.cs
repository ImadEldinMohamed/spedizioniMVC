using spedizioniMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace spedizioniMVC.Controllers
{
    [Authorize()]
    public class HomeController : Controller
    {
       
        public ActionResult Index()
        {
            return View(DB.getclienti());
        }

        public ActionResult index2()
        {
            return View(DB.getazienda());
        }

        public ActionResult Index3()
        {
            return View(DB.getSpedizioniPRIVATI());
        }

        public ActionResult Index4()
        {
            return View(DB.getSpedizioniAzienda());
        }

        public ActionResult Index5()
        {
            return View(DB.getAGGIORNAMENTOPRIVATI());
        }

        public ActionResult Index6()
        {
            return View(DB.getAGGIORNAMENTOAZIENDA());
        }

        public ActionResult index7()
        {
            return View(DB.cercaclientesped());
        }

        public ActionResult index8()
        {
            return View(DB.cercaaziendasped());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Cliente c)
        {
            if (ModelState.IsValid)
            {
                DB.creaprivato(c.nome, c.cognome, c.residenza, c.CF, c.DataDiNascita);
                return RedirectToAction("Index", "Home");
            }else { return View(); }
        }


        [HttpGet]
        public ActionResult CreateAzienda()
        {
         return View(); 
        
        }

        [HttpPost]
        public ActionResult CreateAzienda(Azienda a)
        {
            if (ModelState.IsValid) {
                DB.creaAzienda(a.nome, a.P_iva);
                return RedirectToAction("Index2", "Home");
            }
            else { return View(); } 
                

        }

        [HttpGet]
        public ActionResult editcliente(int IDcliente) {
            Cliente cliente = DB.getclienteId(IDcliente);
           return View(cliente);   
        }

        [HttpPost]
         public ActionResult editcliente(Cliente c)
        {

            if (ModelState.IsValid)
            {
                DB.modificaCliente(c.IDcliente,c.nome,c.cognome,c.residenza,c.CF,c.DataDiNascita);
                return RedirectToAction("Index", "Home");
            }
            else return View(c);
        }


        [HttpGet]
        public ActionResult deletecliente(int IDcliente) 
        { 
           DB.Remuovicliente(IDcliente);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult CreaSpedizione1()
        {
            return View();  
        }

        [HttpPost]
        public ActionResult CreaSpedizione1(Spedizione s)
        {
           if(ModelState.IsValid) {
                DB.creaSpedizione(s.peso, s.dataspedizione, s.destinazione, s.prezzo, s.dataconsegna,s.IDcliente);
                return RedirectToAction("Index3", "Home");

            }
            else {  return View(); }    
        }

        [HttpGet]
        public ActionResult CreaSpedizioneAzienda()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreaSpedizioneAzienda(SpedizioneAzienda s)
        {
            if (ModelState.IsValid)
            {
                DB.creaSpedizione(s.peso, s.dataspedizione, s.destinazione, s.prezzo, s.dataconsegna, s.IDazienda);
                return RedirectToAction("Index4", "Home");

            }
            else { return View(); }
        }

        [HttpGet]
        public ActionResult CreaAggiornamentoPrivato()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreaAggiornamentoPrivato(Aggiornamento a)
        {
            if (ModelState.IsValid)
            {
                DB.AggiornamentoPrivati(a.IDspedizione,a.stato,a.luogo,a.descrizione);
                return RedirectToAction("Index5", "Home");

            }
            else { return View(); }
        }


        [HttpGet]
        public ActionResult CreaAggiornamentoAzienda()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreaAggiornamentoAzienda(AggiornamentoSpedizioneAzienda a)
        {
            if (ModelState.IsValid)
            {
                DB.AggiornamentoAzienda(a.IDspedizioneA, a.stato, a.luogo, a.descrizione);
                return RedirectToAction("Index6", "Home");

            }
            else { return View(); }
        }

    }
}