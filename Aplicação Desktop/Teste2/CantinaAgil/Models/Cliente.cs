/*
Programa: Cantina Agil
Autor: Luann
Data: 06/04/2019
*/

namespace CantinaAgil.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cliente()
        {
            this.Transacao = new HashSet<Transacao>();
        }
    
        public int idCliente { get; set; }
        public string nomeCliente { get; set; }
        public string relacaoSenai { get; set; }
        public string emailCliente { get; set; }
        public string foneCliente { get; set; }
        public string celularCliente { get; set; }
        public string rgCliente { get; set; }
        public string cpfCliente { get; set; }
        public string obsCliente { get; set; }
        public Nullable<bool> ativoCliente { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transacao> Transacao { get; set; }
    }
}
