//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dal
{
    using System;
    using System.Collections.Generic;
    
    public partial class AnnualSummary
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AnnualSummary()
        {
            this.TransactionsOnCoffer = new HashSet<TransactionsOnCoffer>();
        }
    
        public int Year { get; set; }
        public Nullable<decimal> OpeningBalance { get; set; }
        public Nullable<decimal> CurrentWhiteBalance { get; set; }
        public Nullable<decimal> CurrentBlackBalance { get; set; }
        public Nullable<decimal> TerminationBalance { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransactionsOnCoffer> TransactionsOnCoffer { get; set; }
    }
}
