using Cantina_agil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cantina_agil.Controllers
{
    public class ClientesController : Controller
    {
        // GET: Clientes
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult create(Bind(Include = "idCliente,nomeCliente,relacaoSenai,emailCliente,foneCliente,celularCliente,rgCliente,cpfCliente,obsCliente")] Cliente cliente)
        {
            return View();
        }
        public ActionResult Update()
        {
            return View();
        }
        public ActionResult Delete()
        {
            return View();
        }
    }
}