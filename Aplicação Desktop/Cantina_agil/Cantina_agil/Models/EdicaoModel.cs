using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cantina_agil.Models
{
    public class EdicaoModel
    {
    }

    public partial class EntradaSaida
    {
        public EntradaSaida(DateTime now, int? quantidade, int idTransacao)
        {
            this.dataEntradaSaida = now;
            if (quantidade == null)
            {
                this.quantEntradaSaida = (int)quantidade;
            }
            this.id_Transacao = idTransacao;
        }
    }

}