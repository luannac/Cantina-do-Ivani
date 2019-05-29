using Cantina_agil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cantina_agil.Controllers
{
    
    public class MenuController : Controller
    {
        // GET: Menu   
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cadastrar()
        {
            return View();
        }
    }
}