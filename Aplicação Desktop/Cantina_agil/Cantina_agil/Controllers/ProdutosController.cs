using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cantina_agil.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace Cantina_agil.Controllers
{
    public class ProdutosController : Controller
    {
        private Cantina_agilEntities db = new Cantina_agilEntities();

        // GET: Produtos
        public ActionResult Index()
        {
            return View(db.Produto.Where(a =>  a.ativoProduto == null));
        }

        [HttpPost]
        public ActionResult Index(int? codigo,string nome,double? valorMax,double? valorMin,bool? deletado)
        {
            if (codigo != null)
            {
                return View(db.Produto.Where(a => a.idProduto.Equals((int)codigo)));
            }
            //if(nome==null && val)
            if (deletado == null)
            {
                deletado = false;
            }

            

            //Tratamento do Campos Valores

                if (valorMax == null)
                {
                    valorMax = (double)db.Produto.Max(a => a.valor);
                }
                if(valorMin == null)
                {
                    valorMin = (double)db.Produto.Min(a => a.valor);

                }          

            IQueryable<Produto> v=null ;
            //Tratamento do campo Deletado
            if ((bool)deletado)
            {
                v = db.Produto.Where(a => a.nomeProduto.Contains(nome) && (double)a.valor > valorMin && (double)a.valor < valorMax);
            }
            else
            {
                v = db.Produto.Where(a => a.nomeProduto.Contains(nome)&& (double)a.valor > valorMin && (double)a.valor < valorMax && a.ativoProduto==false );
            }


                if (v != null)
                {
                    return View(v.ToList());
                }


                /*
                if (codigo != null)
                {
                    return View(db.Produto.Where(a => a.idProduto.Equals((int)codigo)));
                }
                if (deletado == null)
                {
                    deletado = false;
                }

                SqlConnection con =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["BCD"].ConnectionString);

                string comando = "select * from Produto where LOWER(nomeProduto ) like @nome or UPPER(nomeProduto ) like @nome1"
                                    +" UNION "
                                    +"select* from Produto where valor > @vMin and valor < @vMax";

                //Tratamento do Campos Valores
                if (valorMin == null || valorMax == null)
                {
                    if (valorMax == null )
                    {
                        valorMax = (double)db.Produto.Max(a => a.valor);
                    }
                    else
                    {
                        valorMin = (double) db.Produto.Min(a => a.valor);

                    }
                }


                //Tratamento do campo Deletado

                if ((bool)deletado)
                {
                    comando.Union(" UNION select * from Produto where ativoProduto = 0");
                }
                else
                {
                    comando.Union(" UNION select * from Produto where ativoProduto = 1 or ativoProduto = null");
                }
                try
                {
                    con.Open();
                    SqlCommand query =
                        new SqlCommand(comando, con);
                    query.Parameters.AddWithValue("@nome", nome);
                    query.Parameters.AddWithValue("@nome1", nome);
                    query.Parameters.AddWithValue("@vMin", valorMin);
                    query.Parameters.AddWithValue("@vMax", valorMax+1);
                    var leitor = query.ExecuteReader();

                    if (leitor != null)
                    {
                        return View(leitor);
                    }

                }
                catch (Exception e)
                {

                }
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();*/
                return View(db.Produto.Where(a => a.ativoProduto.Equals(1) || a.ativoProduto != null));

            /*
            var produtos = db.Produto.Where(s => s.nomeProduto.Contains(stringDePesquisa));
            //var estoque = db.Estoque.Where(d => d.idProduto_Estoque.Equals(produtos.Single().idProduto));
            if(String.IsNullOrEmpty(stringDePesquisa))
            {
                return View(db.Produto.Where(a => a.ativoProduto == true || a.ativoProduto == null));
            }
            return View(produtos.Where(a => a.ativoProduto == true || a.ativoProduto == null));*/
        }

        // GET: Produtos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produto.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProduto,nomeProduto,valor,ativoProduto")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Produto.Add(produto);
                db.SaveChanges();

                /*Estoque estoque = new Estoque();
               

                db.Estoque.Add(estoque);
                db.SaveChanges();*/
                

                return RedirectToAction("Index");
            }

            return View(produto);
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produto.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProduto,nomeProduto,valor,ativoProduto")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produto.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produto produto = db.Produto.Find(id);
            produto.ativoProduto = false;
            db.Entry(produto).State = EntityState.Modified;
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
