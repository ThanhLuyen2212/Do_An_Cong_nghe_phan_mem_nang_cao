//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLThuVien.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PhieuMuon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuMuon()
        {
            this.CT_PM = new HashSet<CT_PM>();
        }
    
        public int IDPM { get; set; }
        public string IDDG { get; set; }
        public string TenDG { get; set; }
        public Nullable<System.DateTime> NgayMuon { get; set; }
        public Nullable<System.DateTime> NgayTra { get; set; }
        public Nullable<int> TienPhat { get; set; }
        public string GhiChu { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_PM> CT_PM { get; set; }
        public virtual DocGia DocGia { get; set; }
    }
}
