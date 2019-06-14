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
        private static Venda venda;

        #region Tela Vendas =====================================================
        public ActionResult Pdv()
        {
            if (Session["User.id"] == null)
                return RedirectToAction("Logar", "Log");

            venda = new Venda();
            return View(db.Produto.Where(a=> a.ativoProduto!=false));
        }
        public ActionResult addProduto(int id, int quant)
        {
            Produto prod = db.Produto.Find(id);
            prod.valor = Convert.ToDecimal(prod.valor*quant);
            prod.quantidade = quant;
            venda.add(prod);

            return Json(new
            {
                id = prod.idProduto,
                nome = prod.nomeProduto,
                valor = prod.valor,
                quant = prod.quantidade
            }
            , JsonRequestBehavior.AllowGet);
        }
         public ActionResult PegaValorPro(int id)
        {
            return Json(new { resultado = db.Produto.Find(id).valor },JsonRequestBehavior.AllowGet);
        }

        public ActionResult PegaValorVenda()
        {
            return Json(new { resultado = venda.ValorTotal() },JsonRequestBehavior.AllowGet);
        }

        public ActionResult FinalizarVenda()
        {
            venda.RegistraVenda(false, 1);
            return RedirectToAction("Pdv", "Vendas");
        }

        public ActionResult CancelarVenda()
        {
            venda = new Venda();
            return RedirectToAction("Pdv","Vendas");
        }

        #endregion

        #region CRUD =====================================================================

        // GET: Vendas
        public ActionResult Index()
        {
            return View(db.Transacao.Where(a=> a.pago==false));
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
    #endregion
}
