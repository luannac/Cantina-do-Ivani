using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cantina_agil.Models
{
    /*Classe para guardar informações da venda e realizar a venda*/

    public class Venda
    {
        private Cantina_agilEntities db = new Cantina_agilEntities();
        public List<Produto> entradaSaidas;

        public Venda()
        {
            entradaSaidas = new List<Produto>();
        }

        public string add(Produto produto)
        {
            Produto prodI = produto;
            entradaSaidas.Add(prodI);
            return null;
        }

        public decimal ValorTotal()
        {
            decimal valor = 0;
            foreach(Produto item in entradaSaidas)
            {
                valor += item.valor;
            }
            return valor;
        }

   
        public string RegistraVenda(bool aPrazo,int? idCliente)
        {
            Transacao tra = new Transacao();
            decimal transacaoValor =0;

            tra.pago = false;
            tra.dataTransacao = DateTime.Now;

            if (!aPrazo)
            {
                tra.pago = true;
                tra.dataPagamento = DateTime.Now;
            }
            if (idCliente != null)
            {
                tra.idCliente_Transacao = idCliente;
            }

            foreach(Produto proI in entradaSaidas)
            {
                transacaoValor += proI.valor;

                EntradaSaida entr = new EntradaSaida(
                    DateTime.Now,
                    proI.quantidade,
                    tra.idTransacao,
                    proI);

                db.EntradaSaida.Add(entr);
            }
            tra.valorTransacao = transacaoValor;
            tra.ativoTransacao = true;

            db.Transacao.Add(tra);
            db.SaveChanges();
            return null;
        }
    }
}