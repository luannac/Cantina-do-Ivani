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
    public class VendasController : Controller
    {
        private Cantina_agilEntities db = new Cantina_agilEntities();
        private Venda venda;

        // GET: Vendas
        public ActionResult Index()
        {
            var transacao = db.Transacao.Include(t => t.Cliente).Include(t => t.EntradaSaida);
            return View(transacao.ToList());
        }

        public ActionResult Pdv()
        {
            return View();
        }


        // GET: Vendas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transacao transacao = db.Transacao.Find(id);
            if (transacao == null)
            {
                return HttpNotFound();
            }
            return View(transacao);
        }

        // GET: Vendas/Create
        public ActionResult Create()
        {
            ViewBag.idCliente_Transacao = new SelectList(db.Cliente, "idCliente", "nomeCliente");
            ViewBag.idEntradaSaida_Transacao = new SelectList(db.EntradaSaida, "idEntradaSaida", "idEntradaSaida");
            return View();
        }

        // POST: Vendas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTransacao,valorTransacao,dataTransacao,pago,dataPagamento,idEntradaSaida_Transacao,idCliente_Transacao,ativoTransacao")] Transacao transacao)
        {
            if (ModelState.IsValid)
            {
                db.Transacao.Add(transacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCliente_Transacao = new SelectList(db.Cliente, "idCliente", "nomeCliente", transacao.idCliente_Transacao);
            ViewBag.idEntradaSaida_Transacao = new SelectList(db.EntradaSaida, "idEntradaSaida", "idEntradaSaida");
            return View(transacao);
        }

        // GET: Vendas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transacao transacao = db.Transacao.Find(id);
            if (transacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCliente_Transacao = new SelectList(db.Cliente, "idCliente", "nomeCliente", transacao.idCliente_Transacao);
            ViewBag.idEntradaSaida_Transacao = new SelectList(db.EntradaSaida, "idEntradaSaida", "idEntradaSaida");
            return View(transacao);
        }

        // POST: Vendas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTransacao,valorTransacao,dataTransacao,pago,dataPagamento,idEntradaSaida_Transacao,idCliente_Transacao,ativoTransacao")] Transacao transacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCliente_Transacao = new SelectList(db.Cliente, "idCliente", "nomeCliente", transacao.idCliente_Transacao);
            ViewBag.idEntradaSaida_Transacao = new SelectList(db.EntradaSaida, "idEntradaSaida", "idEntradaSaida");
            return View(transacao);
        }

        // GET: Vendas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transacao transacao = db.Transacao.Find(id);
            if (transacao == null)
            {
                return HttpNotFound();
            }
            return View(transacao);
        }

        // POST: Vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transacao transacao = db.Transacao.Find(id);
            db.Transacao.Remove(transacao);
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
