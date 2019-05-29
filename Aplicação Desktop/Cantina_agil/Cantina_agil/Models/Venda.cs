using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Cantina_agil.Models
{
    /*Classe para guardar informações da venda e realizar a venda*/

    public class Venda
    {
        private Cantina_agilEntities db = new Cantina_agilEntities();
        private List<ProdutoInterno> entradaSaidas;

        public Venda()
        {
            entradaSaidas = new List<ProdutoInterno>();
        }

        public string add(Produto produto,int quant)
        {
            ProdutoInterno prodI = new ProdutoInterno(produto,quant);
            entradaSaidas.Add(prodI);
            return null;
        }
   
        public string RegistraVenda(bool pago,bool aPrazo,int? idCliente)
        {
            Transacao tra = new Transacao();
            decimal transacaoValor =0;

            tra.pago = pago;
            tra.dataTransacao = DateTime.Now;

            if (!aPrazo)
            {
                tra.dataPagamento = DateTime.Now;
            }
            if (idCliente != null)
            {
                tra.idCliente_Transacao = idCliente;
            }

            foreach(ProdutoInterno proI in entradaSaidas)
            {
                transacaoValor += proI.produto.valor;

                EntradaSaida entr = new EntradaSaida(
                    DateTime.Now,
                    proI.quant,
                    db.Estoque.Where(a => a.idProduto_Estoque == proI.produto.idProduto).SingleOrDefault().idEstoque,
                    tra.idTransacao);

                db.EntradaSaida.Add(entr);
            }
            tra.valorTransacao = transacaoValor;
            tra.ativoTransacao = true;

            db.Transacao.Add(tra);
            db.SaveChanges();
            return null;
        }
    }

    internal class ProdutoInterno
    {
        public Produto produto { get; set; }
        public int quant { get; set; }

        public ProdutoInterno(Produto produto, int quant)
        {
            this.produto = produto;
            this.quant = quant;
        }
    }
}