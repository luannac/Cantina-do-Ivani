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
    
    public partial class Produto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Produto()
        {
            this.EntradaSaida = new HashSet<EntradaSaida>();
        }
    
        public int idProduto { get; set; }
        public string nomeProduto { get; set; }
        public decimal valor { get; set; }
        public Nullable<bool> ativoProduto { get; set; }
        public string tipo { get; set; }
        public Nullable<int> quantidade { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EntradaSaida> EntradaSaida { get; set; }
    }
}
