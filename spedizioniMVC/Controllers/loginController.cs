
using spedizioniMVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace spedizioniMVC.Controllers
{
    public class loginController : Controller
    {
        // GET: login

        public ActionResult index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(Utente u)
        {
            string conn = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(conn);
            try
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("Select * FROM utente WHERE username=@username And password=@password", sqlConnection);
                sqlCommand.Parameters.AddWithValue("Username", u.username);
                sqlCommand.Parameters.AddWithValue("Password", u.password);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    FormsAuthentication.SetAuthCookie(u.username, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.AuthError = "Autenticazione non riuscita";
                    return View();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                sqlConnection.Close();
            }

            return RedirectToAction("Index", "Home");
        }


        public ActionResult Register()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Register([Bind(Exclude = "role")] Utente u)
        {
           DB.registrati(u.username,u.password);
            return RedirectToAction("Login", "login");
          
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("login", "index");
        }
        
    }
}