using Cantina_agil.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CantinaAgil.Controllers
{
    public class LogController : Controller
    {
        private Cantina_agilEntities db = new Cantina_agilEntities();

        public ActionResult Logar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "loginAtendente,senhaAtendente")] Atendente atendente/*string login, string password*/)
        {
            //--------------------------------------------------------------------------------
            if (ModelState.IsValid) //verifica se é válido
            {
                
                var v = db.Atendente.Where(a => a.loginAtendente.Equals(atendente.loginAtendente) && a.senhaAtendente.Equals(atendente.senhaAtendente));

                foreach (var item in v)
                {
                       Session["User.Name"] = item.nomeAtendente;
                       Session["User.id"] = item.idAtendente;
                    return RedirectToAction("Index", "Menu");
                }
            }
            return RedirectToAction("Logar", "Log");
            #region Login por SQL-----------------------------------------------------------------------------
            /*
            SqlDataReader leitor=null;
            SqlConnection con =
                new SqlConnection(ConfigurationManager.ConnectionStrings["BCD"].ConnectionString);
            try
            {
                con.Open();
                SqlCommand query =
                    new SqlCommand("SELECT * FROM Atendente WHERE loginAtendente = @login AND senhaAtendente = @password", con);
                query.Parameters.AddWithValue("@login", atendente.loginAtendente);
                query.Parameters.AddWithValue("@password", atendente.senhaAtendente);
                leitor = query.ExecuteReader();

            }
            catch (Exception e)
            {
            }
            if(leitor != null) {
                if (leitor.Read())
                {
                    Session["User"] = new Atendente(leitor);
                    return RedirectToAction("Index", "Menu");
                }
            }

            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
            return RedirectToAction("Logar", "Log");*/
            #endregion
        }

        public ActionResult RecuperarSenha()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RecuperarSenha([Bind(Include = "cpf")] Atendente atendente)
        {
            
            var resposta = db.Atendente.Where(a => a.cpf.Equals(atendente.cpf));

            if (resposta != null)
            {
                try
                {
                    Atendente ate = resposta.Single();
                    ate = db.Atendente.Find(ate.idAtendente);
                    return RedirectToAction("AlterarSenha","Log",ate);
                }
                catch (Exception e)
                {

                }
            }
            return View();
        }

        public ActionResult AlterarSenha()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AlterarSenha([Bind(Include = "idAtendente,nomeAtendente,loginAtendente,senhaAtendente,emailAtendente,ativoAtendente,cpf")] Atendente atendente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(atendente).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    // Retrieve the error messages as a list of strings.
                    var errorMessages = ex.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

                    //throw the error messages.
                }
                return RedirectToAction("Logar");
            }

            return RedirectToAction("Logar");
        }
    
        public ActionResult Logout()
        {
            Session["User.Name"] = null;
            Session["User.id"] = null;
            return RedirectToAction("Logar", "log");
        }
    }

}