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
    public class SangriasController : Controller
    {
        private Cantina_agilEntities db = new Cantina_agilEntities();

        // GET: Sangrias
        public ActionResult Index()
        {
            if (Session["User.id"] == null)
                return RedirectToAction("Logar", "Log");

            var sangria = db.Sangria.Include(s => s.Atendente);
            return View(sangria.ToList());
        }

        // GET: Sangrias/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["User.id"] == null)
                return RedirectToAction("Logar", "Log");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sangria sangria = db.Sangria.Find(id);
            if (sangria == null)
            {
                return HttpNotFound();
            }
            return View(sangria);
        }

        // GET: Sangrias/Create
        public ActionResult Create()
        {
            if (Session["User.id"] == null)
                return RedirectToAction("Logar", "Log");

            ViewBag.idAtendente_Sangria = new SelectList(db.Atendente, "idAtendente", "nomeAtendente");
            return View();
        }

        // POST: Sangrias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idSangria,abertura,fechamento,valorSangria,idAtendente_Sangria,ativoSangria")] Sangria sangria)
        {
            if (Session["User.id"] == null)
                return RedirectToAction("Logar", "Log");

            if (ModelState.IsValid)
            {
                db.Sangria.Add(sangria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idAtendente_Sangria = new SelectList(db.Atendente, "idAtendente", "nomeAtendente", sangria.idAtendente_Sangria);
            return View(sangria);
        }

        // GET: Sangrias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["User.id"] == null)
                return RedirectToAction("Logar", "Log");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sangria sangria = db.Sangria.Find(id);
            if (sangria == null)
            {
                return HttpNotFound();
            }
            ViewBag.idAtendente_Sangria = new SelectList(db.Atendente, "idAtendente", "nomeAtendente", sangria.idAtendente_Sangria);
            return View(sangria);
        }

        // POST: Sangrias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idSangria,abertura,fechamento,valorSangria,idAtendente_Sangria,ativoSangria")] Sangria sangria)
        {
            if (Session["User.id"] == null)
                return RedirectToAction("Logar", "Log");

            if (ModelState.IsValid)
            {
                db.Entry(sangria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idAtendente_Sangria = new SelectList(db.Atendente, "idAtendente", "nomeAtendente", sangria.idAtendente_Sangria);
            return View(sangria);
        }

        // GET: Sangrias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["User.id"] == null)
                return RedirectToAction("Logar", "Log");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sangria sangria = db.Sangria.Find(id);
            if (sangria == null)
            {
                return HttpNotFound();
            }
            return View(sangria);
        }

        // POST: Sangrias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["User.id"] == null)
                return RedirectToAction("Logar", "Log");

            Sangria sangria = db.Sangria.Find(id);
            db.Sangria.Remove(sangria);
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
