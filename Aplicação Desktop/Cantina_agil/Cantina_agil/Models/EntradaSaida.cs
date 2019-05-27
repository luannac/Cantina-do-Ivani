//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cantina_agil.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class EntradaSaida
    {
        public int idEntradaSaida { get; set; }
        public System.DateTime dataEntradaSaida { get; set; }
        public int quantEntradaSaida { get; set; }
        public int idEstoque_EntradaSaida { get; set; }
        public Nullable<bool> ativoEntradaSaida { get; set; }
        public Nullable<int> id_Transacao { get; set; }
    
        public virtual Estoque Estoque { get; set; }
        public virtual Transacao Transacao { get; set; }

        public EntradaSaida(DateTime now, int quant, int idEstoque, int idTransacao)
        {
            this.dataEntradaSaida = now;
            this.quantEntradaSaida = quant;
            this.idEstoque_EntradaSaida = idEstoque;
            this.id_Transacao = idTransacao;
            ativoEntradaSaida = true;
        }
    }
}
