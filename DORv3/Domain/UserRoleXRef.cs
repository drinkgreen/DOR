//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DORv3.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserRoleXRef
    {
        public int RefId { get; set; }
        public Nullable<int> SecurityId { get; set; }
        public Nullable<int> RoleId { get; set; }
        public Nullable<System.DateTime> AddDate { get; set; }
        public Nullable<System.DateTime> UpdDate { get; set; }
        public string AddUser { get; set; }
        public string UpdUser { get; set; }
    }
}
