using Cantina_agil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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
            /*
            if (ModelState.IsValid) { 
            if (atendente.Login())
            {
                Session["User"] = atendente;
                TempData["Msg"] = "Logado com Sucesso";
                return RedirectToAction("Index", "menu");
            }
            else
            {
                TempData["Msg"] = "Erro ao Logar";
                return View();
            }
            }
            return View();       */

            if (ModelState.IsValid) //verifica se é válido
            {
                
                var v = db.Atendente.Where(a => a.loginAtendente.Equals(atendente.nomeAtendente) && a.senhaAtendente.Equals(atendente.senhaAtendente));
                if (v != null)
                    {
                        Session["User"] = v;
                        //Session["usuarioLogadoID"] = v.Id.ToString();
                        //Session["nomeUsuarioLogado"] = v.NomeUsuario.ToString();
                        return RedirectToAction("Index", "Menu");
                    }
            }
            return RedirectToAction("Logar", "Log");
        }
    
        public ActionResult Logout()
        {
            Session["User"] = null;
            return RedirectToAction("Initial", "log");
        }
    }

}