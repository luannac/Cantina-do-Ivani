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
    
    public partial class Sangria
    {
        public int idSangria { get; set; }
        public System.DateTime abertura { get; set; }
        public System.DateTime fechamento { get; set; }
        public decimal valorSangria { get; set; }
        public int idAtendente_Sangria { get; set; }
        public Nullable<bool> ativoSangria { get; set; }
    
        public virtual Atendente Atendente { get; set; }
    }
}
