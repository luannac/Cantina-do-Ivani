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
    
    public partial class Atendente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Atendente()
        {
            this.Sangria = new HashSet<Sangria>();
        }
    
        public int idAtendente { get; set; }
        public string nomeAtendente { get; set; }
        public string loginAtendente { get; set; }
        public string senhaAtendente { get; set; }
        public string emailAtendente { get; set; }
        public Nullable<bool> ativoAtendente { get; set; }
        public string cpf { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sangria> Sangria { get; set; }
    }
}
