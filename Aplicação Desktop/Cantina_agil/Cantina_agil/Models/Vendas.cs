using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Cantina_agil.Models
{
    public class Vendas
    {
        private Cantina_agilEntities db = new Cantina_agilEntities();
        public bool RegistraVenda(Transacao transacao,Produto produto,int quantidade)
        {
            Estoque estoque =
                db.Estoque
                .Where(a => a.idProduto_Estoque.Equals(produto.idProduto))
                .Single();
            EntradaSaida entrada = new EntradaSaida();

            try
            {
                try
                {
                    //criar entrada e saida
                    entrada.dataEntradaSaida = (System.DateTime)transacao.dataTransacao;
                    entrada.quantEntradaSaida = quantidade;
                    entrada.idEstoque_EntradaSaida = estoque.idProduto_Estoque;

                    db.EntradaSaida.Add(entrada);

                    //Dar baixa no estoque
                    estoque.quantidade += quantidade;
                    db.Entry(transacao).State = EntityState.Modified;
                    db.SaveChanges();

                }
                catch (Exception e)
                {
                    return false;
                }

                //cria transação
                entrada = db.EntradaSaida.Find(entrada);
                db.Transacao.Add(transacao);
                db.SaveChanges();

            }catch(Exception e)
            {
                return false;
            }
            return true;
        }
    }
}