using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cantina_agil.Models
{
    public class CommonProdutoViewModel : IEnumerator<Produto>
    {
        public IQueryable<Produto> Produtos { get; set; }
        public IQueryable<Estoque> Estoque { get; set; }
        

        List<Produto> lista = new List<Produto>();
        private int Position = -1;

        public Produto Current
        {
            get
            {
                return lista[Position];
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return lista[Position];
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            if (Position < lista.Count - 1)
            {
                ++Position;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            Position = -1;
        }
    }
}