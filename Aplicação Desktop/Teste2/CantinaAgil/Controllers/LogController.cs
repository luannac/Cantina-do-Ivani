using CantinaAgil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CantinaAgil.Controllers
{
    public class LogController : Controller
    {
        public static Atendente globalAtendente;

        // GET: Log
        public ActionResult Initial()
        {
            return View();
        }
        public ActionResult Logar(string login, string password)
        {
            Atendente atend = new Atendente();
            atend.loginAtendente = login;
            atend.senhaAtendente = password;

            if (atend.Login())
            {
                Session["User"] = atend;
                TempData["Msg"] = "Logado com Sucesso";
                return RedirectToAction("Index", "menu");
            }
            else
            {
                TempData["Msg"] = "Erro ao Logar";
                return View();
            }
        }
        public ActionResult Logout()
        {
            Session["User"] = null;
            return RedirectToAction("Initial", "log");
        }
    }

}