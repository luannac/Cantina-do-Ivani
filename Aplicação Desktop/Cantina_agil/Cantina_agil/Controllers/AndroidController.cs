using Cantina_agil.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cantina_agil.Controllers
{
    public class AndroidController : Controller
    {
        // GET: Android
        public IQueryable<Produto> SelectProdutos()
        {
            return Android.SelectProdutos();
        }
    }
}