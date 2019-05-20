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
    public class EstoquesController : Controller
    {
        private Cantina_agilEntities db = new Cantina_agilEntities();

        // GET: Estoques
        public ActionResult Index()
        {
            var estoque = db.Estoque.Include(e => e.Produto);
            return View(estoque.ToList());
        }

        // GET: Estoques/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estoque estoque = db.Estoque.Find(id);
            if (estoque == null)
            {
                return HttpNotFound();
            }
            return View(estoque);
        }

        // GET: Estoques/Create
        public ActionResult Create()
        {
            ViewBag.idProduto_Estoque = new SelectList(db.Produto, "idProduto", "nomeProduto");
            return View();
        }

        // POST: Estoques/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEstoque,quantidade,idProduto_Estoque")] Estoque estoque)
        {
            if (ModelState.IsValid)
            {
                db.Estoque.Add(estoque);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idProduto_Estoque = new SelectList(db.Produto, "idProduto", "nomeProduto", estoque.idProduto_Estoque);
            return View(estoque);
        }

        // GET: Estoques/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estoque estoque = db.Estoque.Find(id);
            if (estoque == null)
            {
                return HttpNotFound();
            }
            ViewBag.idProduto_Estoque = new SelectList(db.Produto, "idProduto", "nomeProduto", estoque.idProduto_Estoque);
            return View(estoque);
        }

        // POST: Estoques/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEstoque,quantidade,idProduto_Estoque")] Estoque estoque)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estoque).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idProduto_Estoque = new SelectList(db.Produto, "idProduto", "nomeProduto", estoque.idProduto_Estoque);
            return View(estoque);
        }

        // GET: Estoques/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estoque estoque = db.Estoque.Find(id);
            if (estoque == null)
            {
                return HttpNotFound();
            }
            return View(estoque);
        }

        // POST: Estoques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estoque estoque = db.Estoque.Find(id);
            db.Estoque.Remove(estoque);
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
