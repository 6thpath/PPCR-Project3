//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PPCR.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PROPERTY_TYPE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PROPERTY_TYPE()
        {
            this.PROPERTies = new HashSet<PROPERTY>();
        }
    
        public int ID { get; set; }
        public string CodeType { get; set; }
        public string Description { get; set; }
        public Nullable<bool> Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROPERTY> PROPERTies { get; set; }
    }
}
