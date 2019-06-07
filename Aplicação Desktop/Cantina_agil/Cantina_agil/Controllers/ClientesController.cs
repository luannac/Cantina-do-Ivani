using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cantina_agil.Models;

namespace Cantina_agil.Controllers
{
    public class ClientesController : Controller
    {
        private Cantina_agilEntities db = new Cantina_agilEntities();

        // GET: Clientes
        public ActionResult Index()
        {
            if (Session["User.id"] == null)
                return RedirectToAction("Logar", "Log");

            return View(db.Cliente.Where(a => a.ativoCliente == true || a.ativoCliente == null ));
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["User.id"] == null)
                return RedirectToAction("Logar", "Log");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            if (Session["User.id"] == null)
                return RedirectToAction("Logar", "Log");

            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCliente,nomeCliente,relacaoSenai,emailCliente,foneCliente,celularCliente,rgCliente,cpfCliente,obsCliente,ativoCliente")] Cliente cliente)
        {
            if (Session["User.id"] == null)
                return RedirectToAction("Logar", "Log");

            if (ModelState.IsValid)
            {
                db.Cliente.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["User.id"] == null)
                return RedirectToAction("Logar", "Log");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCliente,nomeCliente,relacaoSenai,emailCliente,foneCliente,celularCliente,rgCliente,cpfCliente,obsCliente,ativoCliente")] Cliente cliente)
        {
            if (Session["User.id"] == null)
                return RedirectToAction("Logar", "Log");

            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["User.id"] == null)
                return RedirectToAction("Logar", "Log");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["User.id"] == null)
                return RedirectToAction("Logar", "Log");

            Cliente cliente = db.Cliente.Find(id);
            cliente.ativoCliente = false;
            db.Entry(cliente).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
