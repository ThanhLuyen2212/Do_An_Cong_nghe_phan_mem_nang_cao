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
    using System.ComponentModel.DataAnnotations;

    public partial class Admin
    {
        public int IDAdmin { get; set; }

        public string TenAdmin { get; set; }

        public string DienThoai { get; set; }
        public string DiaChi { get; set; }

        public string UserName { get; set; }
 
        public string Password { get; set; }
    }
}
