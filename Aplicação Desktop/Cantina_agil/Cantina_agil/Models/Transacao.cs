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
    
    public partial class Transacao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Transacao()
        {
            this.EntradaSaida = new HashSet<EntradaSaida>();
        }
    
        public int idTransacao { get; set; }
        public decimal valorTransacao { get; set; }
        public Nullable<System.DateTime> dataTransacao { get; set; }
        public bool pago { get; set; }
        public Nullable<System.DateTime> dataPagamento { get; set; }
        public Nullable<int> idCliente_Transacao { get; set; }
        public Nullable<bool> ativoTransacao { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EntradaSaida> EntradaSaida { get; set; }
    }
}
