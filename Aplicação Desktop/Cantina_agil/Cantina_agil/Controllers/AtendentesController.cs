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
    public class AtendentesController : Controller
    {
        private Cantina_agilEntities db = new Cantina_agilEntities();

        // GET: Atendentes
        public ActionResult Index()
        {
            if (Session["User.id"] == null)
                return RedirectToAction("Logar", "Log");

            return View(db.Atendente.Where(a => a.ativoAtendente == true || a.ativoAtendente == null));
        }

        // GET: Atendentes/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["User.id"] == null)
                return RedirectToAction("Logar", "Log");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atendente atendente = db.Atendente.Find(id);
            if (atendente == null)
            {
                return HttpNotFound();
            }
            return View(atendente);
        }

        // GET: Atendentes/Create
        public ActionResult Create()
        { 
            if (Session["User.id"] == null)
                return RedirectToAction("Logar", "Log");

            return View();
        }

        // POST: Atendentes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idAtendente,nomeAtendente,loginAtendente,senhaAtendente,emailAtendente,ativoAtendente,cpf")] Atendente atendente)
        {
        if (Session["User.id"] == null)
            return RedirectToAction("Logar", "Log");

        if (ModelState.IsValid)
            {
                db.Atendente.Add(atendente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(atendente);
        }

        // GET: Atendentes/Edit/5
        public ActionResult Edit(int? id)
        {
        if (Session["User.id"] == null)
            return RedirectToAction("Logar", "Log");

        if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atendente atendente = db.Atendente.Find(id);
            if (atendente == null)
            {
                return HttpNotFound();
            }
            return View(atendente);
        }

        // POST: Atendentes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idAtendente,nomeAtendente,loginAtendente,senhaAtendente,emailAtendente,ativoAtendente,cpf")] Atendente atendente)
        {
            if (Session["User.id"] == null)
                return RedirectToAction("Logar", "Log");

            if (ModelState.IsValid)
            {
                db.Entry(atendente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(atendente);
        }

        // GET: Atendentes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["User.id"] == null)
                return RedirectToAction("Logar", "Log");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atendente atendente = db.Atendente.Find(id);
            if (atendente == null)
            {
                return HttpNotFound();
            }
            return View(atendente);
        }

        // POST: Atendentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["User.id"] == null)
                return RedirectToAction("Logar", "Log");


            Atendente atendente = db.Atendente.Find(id);
            atendente.ativoAtendente = false;
            db.Entry(atendente).State = EntityState.Modified;
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
