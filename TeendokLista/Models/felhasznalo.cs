//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TeendokLista.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class felhasznalo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public felhasznalo()
        {
            this.feladat = new HashSet<feladat>();
        }
    
        public int Id { get; set; }
        public string FelhasznaloNev { get; set; }
        public string Jelszo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<feladat> feladat { get; set; }
    }
}
