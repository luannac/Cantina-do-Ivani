using Cantina_agil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CantinaAgil.Controllers
{
    public class LogController : Controller
    {
        private Cantina_agilEntities db = new Cantina_agilEntities();
        public static Atendente globalAtendente;

        public ActionResult Logar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logar([Bind(Include = "loginAtendente,senhaAtendente")] Atendente atendente/*string login, string password*/)
        {
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
            return View();
        }
        public ActionResult Logout()
        {
            Session["User"] = null;
            return RedirectToAction("Initial", "log");
        }
    }

}