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
        private List<Produto> entradaSaidas;

        public Venda()
        {
            entradaSaidas = new List<Produto>();
        }

        public string add(Produto produto)
        {
            Produto prodI = new Produto();
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

            foreach(Produto proI in entradaSaidas)
            {
                transacaoValor += proI.valor;

                EntradaSaida entr = new EntradaSaida(
                    DateTime.Now,
                    proI.quantidade,
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
}