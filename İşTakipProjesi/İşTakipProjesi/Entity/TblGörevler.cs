//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace İşTakipProjesi.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblGörevler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblGörevler()
        {
            this.TblGörevDetaylar = new HashSet<TblGörevDetaylar>();
        }
    
        public int ID { get; set; }
        public Nullable<int> GörevVeren { get; set; }
        public Nullable<int> GörevAlan { get; set; }
        public string Açıklama { get; set; }
        public string Durum { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblGörevDetaylar> TblGörevDetaylar { get; set; }
        public virtual TblPersonel TblPersonel { get; set; }
        public virtual TblPersonel TblPersonel1 { get; set; }
    }
}
