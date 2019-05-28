using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cantina_agil.Models
{
    public class CommonProdutoViewModel
    {
        public IQueryable<Produto> Produtos;
        public IQueryable<Estoque> Estoque;
    }
}