using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CantinaAgil.Controllers
{
    public class menuController : Controller
    {
        // GET: menu
        public ActionResult Index()
        {
            return View();
        }
    }
}