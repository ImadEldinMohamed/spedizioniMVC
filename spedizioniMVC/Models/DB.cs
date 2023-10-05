using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml.Linq;

namespace spedizioniMVC.Models
{
    public static class DB
    {
        public static void creaprivato(string nome, string cognome, string residenza, string CF, DateTime DataDiNascita)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO cliente_privato (nome, cognome, residenza, CF,dataDiNascita) VALUES(@nome, @cognome, @residenza, @CF,@dataDiNascita)";
                cmd.Parameters.AddWithValue("nome", nome);
                cmd.Parameters.AddWithValue("cognome", cognome);
                cmd.Parameters.AddWithValue("residenza", residenza);
                cmd.Parameters.AddWithValue("CF", CF);
                cmd.Parameters.AddWithValue("dataDiNascita", DataDiNascita);

                int IsOk = cmd.ExecuteNonQuery();

            }

            catch { }
            finally
            {
                conn.Close();
            }
        }

        public static List<Cliente> getclienti()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("SELECT * FROM cliente_privato ", conn);
            SqlDataReader sqlDataReader;

            conn.Open();

            List<Cliente> cliente = new List<Cliente>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Cliente c = new Cliente();
                c.IDcliente = Convert.ToInt32(sqlDataReader["IDcliente"]);
                c.nome = sqlDataReader["nome"].ToString();
                c.cognome = sqlDataReader["cognome"].ToString();
                c.residenza = sqlDataReader["residenza"].ToString();
                c.CF = sqlDataReader["CF"].ToString();
                c.DataDiNascita = Convert.ToDateTime(sqlDataReader["DataDiNascita"]);
                cliente.Add(c);
            }

            conn.Close();
            return cliente;
        }


        public static void creaAzienda(string nome, string P_iva)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO azienda (nome,P_iva) VALUES(@nome, @P_iva)";
                cmd.Parameters.AddWithValue("nome", nome);
                cmd.Parameters.AddWithValue("P_iva", P_iva);

                int IsOk = cmd.ExecuteNonQuery();

            }

            catch { }
            finally
            {
                conn.Close();
            }
        }

        public static List<Azienda> getazienda()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("SELECT * FROM azienda ", conn);
            SqlDataReader sqlDataReader;

            conn.Open();

            List<Azienda> azienda = new List<Azienda>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Azienda a = new Azienda();
                a.IDazienda = Convert.ToInt32(sqlDataReader["IDazienda"]);
                a.nome = sqlDataReader["nome"].ToString();
                a.P_iva = sqlDataReader["P_iva"].ToString();

                azienda.Add(a);
            }

            conn.Close();
            return azienda;
        }


        public static void registrati(string username, string password)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO utente (username,password) VALUES(@username, @password)";
                cmd.Parameters.AddWithValue("username", username);
                cmd.Parameters.AddWithValue("password", password);

                int IsOk = cmd.ExecuteNonQuery();

            }

            catch { }
            finally
            {
                conn.Close();
            }
        }

        public static Cliente getclienteId(int IDcliente)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("select * from cliente_privato where IDcliente = @IDcliente", conn);
            cmd.Parameters.AddWithValue("IDcliente", IDcliente);
            SqlDataReader sqlDataReader;

            conn.Open();

            Cliente c = new Cliente();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                c.IDcliente = Convert.ToInt32(sqlDataReader["IDcliente"]);
                c.nome = sqlDataReader["nome"].ToString();
                c.cognome = sqlDataReader["cognome"].ToString();
                c.residenza = sqlDataReader["residenza"].ToString();
                c.CF = sqlDataReader["CF"].ToString();
                c.DataDiNascita = Convert.ToDateTime(sqlDataReader["DataDiNascita"]);

            }

            conn.Close();
            return c;
        }



        public static void modificaCliente(int IDcliente, string nome, string cognome, string residenza, string CF, DateTime DataDiNascita)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE cliente_privato SET nome=@nome,cognome=@cognome,residenza=@residenza,CF=@CF,DataDiNascita=@DataDiNascita WHERE IDcliente = @IDcliente";
                cmd.Parameters.AddWithValue("IDcliente", IDcliente);
                cmd.Parameters.AddWithValue("nome", nome);
                cmd.Parameters.AddWithValue("cognome", cognome);
                cmd.Parameters.AddWithValue("residenza", residenza);
                cmd.Parameters.AddWithValue("CF", CF);
                cmd.Parameters.AddWithValue("DataDiNascita", DataDiNascita);

                int IsOk = cmd.ExecuteNonQuery();

            }

            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
        }

        public static void Remuovicliente(int IDcliente)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM cliente_privato where IDcliente=@IDcliente";
            cmd.Parameters.AddWithValue("IDcliente", IDcliente);

            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();
        }


        public static void creaSpedizione(double peso, DateTime dataspedizione, string destinazione, double prezzo, DateTime dataconsegna, int IDcliente)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO spedizione ( peso,  dataspedizione,  destinazione, prezzo,  dataconsegna,IDcliente) VALUES(@peso, @dataspedizione, @destinazione, @prezzo, @dataconsegna,@IDcliente)";
                cmd.Parameters.AddWithValue("peso", peso);
                cmd.Parameters.AddWithValue("dataspedizione", dataspedizione);
                cmd.Parameters.AddWithValue("destinazione", destinazione);
                cmd.Parameters.AddWithValue("prezzo", prezzo);
                cmd.Parameters.AddWithValue("dataconsegna", dataconsegna);
                cmd.Parameters.AddWithValue("IDcliente", IDcliente);

                int IsOk = cmd.ExecuteNonQuery();

            }

            catch { }
            finally
            {
                conn.Close();
            }
        }
        public static List<Spedizione> getSpedizioniPRIVATI()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("SELECT * FROM spedizione ", conn);
            SqlDataReader sqlDataReader;

            conn.Open();

            List<Spedizione> spedizione = new List<Spedizione>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Spedizione s = new Spedizione();
                s.IDspedizione = Convert.ToInt32(sqlDataReader["IDspedizione"]);
                s.peso = Convert.ToDouble(sqlDataReader["peso"]);
                s.dataspedizione = Convert.ToDateTime(sqlDataReader["dataspedizione"]);
                s.destinazione = sqlDataReader["destinazione"].ToString();
                s.prezzo = Convert.ToDouble(sqlDataReader["prezzo"]);
                s.dataconsegna = Convert.ToDateTime(sqlDataReader["dataconsegna"]);
                s.IDcliente = Convert.ToInt32(sqlDataReader["IDcliente"]);
                spedizione.Add(s);
            }

            conn.Close();
            return spedizione;
        }
        public static List<SpedizioneAzienda> getSpedizioniAzienda()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("SELECT * FROM spedizioneAzienda ", conn);
            SqlDataReader sqlDataReader;

            conn.Open();

            List<SpedizioneAzienda> spedizione = new List<SpedizioneAzienda>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                SpedizioneAzienda s = new SpedizioneAzienda();
                s.IDspedizione = Convert.ToInt32(sqlDataReader["IDspedizione"]);
                s.peso = Convert.ToDouble(sqlDataReader["peso"]);
                s.dataspedizione = Convert.ToDateTime(sqlDataReader["dataspedizione"]);
                s.destinazione = sqlDataReader["destinazione"].ToString();
                s.prezzo = Convert.ToDouble(sqlDataReader["prezzo"]);
                s.dataconsegna = Convert.ToDateTime(sqlDataReader["dataconsegna"]);
                s.IDazienda = Convert.ToInt32(sqlDataReader["IDazienda"]);
                spedizione.Add(s);
            }

            conn.Close();
            return spedizione;
        }

        public static void creaSpedizioneAzienda(double peso, DateTime dataspedizione, string destinazione, double prezzo, DateTime dataconsegna, int IDazienda)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO spedizioneAzienda ( peso,  dataspedizione,  destinazione, prezzo,  dataconsegna,IDAzienda) VALUES(@peso, @dataspedizione, @destinazione, @prezzo, @dataconsegna,@IDAzienda)";
                cmd.Parameters.AddWithValue("peso", peso);
                cmd.Parameters.AddWithValue("dataspedizione", dataspedizione);
                cmd.Parameters.AddWithValue("destinazione", destinazione);
                cmd.Parameters.AddWithValue("prezzo", prezzo);
                cmd.Parameters.AddWithValue("dataconsegna", dataconsegna);
                cmd.Parameters.AddWithValue("IDcliente", IDazienda);

                int IsOk = cmd.ExecuteNonQuery();

            }

            catch { }
            finally
            {
                conn.Close();
            }
        }

        public static void AggiornamentoPrivati(int IDspedizione, string stato, string luogo, string descrizione)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO aggiornamento ( IDspedizione,  stato,  luogo, descrizione) VALUES(@IDspedizione, @stato, @luogo, @descrizione, @dataconsegna,@IDAzienda)";
                cmd.Parameters.AddWithValue("IDspedizione", IDspedizione);
                cmd.Parameters.AddWithValue("stato", stato);
                cmd.Parameters.AddWithValue("luogo", luogo);
                cmd.Parameters.AddWithValue("descrizione", descrizione);

                int IsOk = cmd.ExecuteNonQuery();

            }

            catch { }
            finally
            {
                conn.Close();
            }
        }
        public static List<Aggiornamento> getAGGIORNAMENTOPRIVATI()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("SELECT * FROM aggiornamento ", conn);
            SqlDataReader sqlDataReader;

            conn.Open();

            List<Aggiornamento> aggiornamento = new List<Aggiornamento>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Aggiornamento s = new Aggiornamento();
                s.IDspedizione = Convert.ToInt32(sqlDataReader["IDspedizione"]);
                s.stato = sqlDataReader["stato"].ToString();
                s.luogo = sqlDataReader["luogo"].ToString();
                s.descrizione = sqlDataReader["descrizione"].ToString();
                aggiornamento.Add(s);
            }

            conn.Close();
            return aggiornamento;
        }

        public static void AggiornamentoAzienda(int IDspedizioneA, string stato, string luogo, string descrizione)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO aggiornamentospedizioneAzienda ( IDspedizioneA,  stato,  luogo, descrizione) VALUES(@IDspedizioneA, @stato, @luogo, @descrizione, @dataconsegna,@IDAzienda)";
                cmd.Parameters.AddWithValue("IDspedizione", IDspedizioneA);
                cmd.Parameters.AddWithValue("stato", stato);
                cmd.Parameters.AddWithValue("luogo", luogo);
                cmd.Parameters.AddWithValue("descrizione", descrizione);

                int IsOk = cmd.ExecuteNonQuery();

            }

            catch { }
            finally
            {
                conn.Close();
            }
        }

        public static List<AggiornamentoSpedizioneAzienda> getAGGIORNAMENTOAZIENDA()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("SELECT * FROM aggiornamentospedizioneAzienda ", conn);
            SqlDataReader sqlDataReader;

            conn.Open();

            List<AggiornamentoSpedizioneAzienda> aggiornamento = new List<AggiornamentoSpedizioneAzienda>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                AggiornamentoSpedizioneAzienda s = new AggiornamentoSpedizioneAzienda();
                s.IDspedizioneA = Convert.ToInt32(sqlDataReader["IDspedizioneA"]);
                s.stato = sqlDataReader["stato"].ToString();
                s.luogo = sqlDataReader["luogo"].ToString();
                s.descrizione = sqlDataReader["descrizione"].ToString();
                aggiornamento.Add(s);
            }

            conn.Close();
            return aggiornamento;
        }
        public static List<CercaSpedizioneCliente> cercaclientesped()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            List<CercaSpedizioneCliente> spedizione = new List<CercaSpedizioneCliente>();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * cliente_privato as C inner join spedizione as S on C.IDcliente=S.IDcliente where C.CF=@CF AND S.IDspedizione=@IDspedizione ", conn);
               
                SqlDataReader sqlDataReader;

                conn.Open();

               
                sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    CercaSpedizioneCliente s = new CercaSpedizioneCliente();
                    s.IDspedizione = Convert.ToInt32(sqlDataReader["IDspedizione"].ToString());

                    s.CF = sqlDataReader["CF"].ToString();

                    spedizione.Add(s);
                }
              
            }
            catch(Exception ex)
            
                { }finally { conn.Close(); }    
           return spedizione;
            
        }
        public static List<CercaSpedzioneAzienda> cercaaziendasped()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("SELECT P_iva, count(*) as numerospedizione from azienda as C inner join spedizioneAzienda as S on C.IDAzienda=S.IDazienda group by P_iva ", conn);
            SqlDataReader sqlDataReader;

            conn.Open();

            List<CercaSpedzioneAzienda> spedizione = new List<CercaSpedzioneAzienda>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                CercaSpedzioneAzienda s = new CercaSpedzioneAzienda();
                s.IDspedizioneA = Convert.ToInt32(sqlDataReader["IDspedizioneA"]);

                s.P_iva = sqlDataReader["P_iva"].ToString();

                spedizione.Add(s);
            }

            conn.Close();
            return spedizione;
        }
    }
}


    
    
