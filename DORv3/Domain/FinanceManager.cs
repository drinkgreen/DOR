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
    
    public partial class FinanceManager
    {
        public int FMId { get; set; }
        public string FMName { get; set; }
        public Nullable<int> Dealer { get; set; }
        public Nullable<System.DateTime> DisableDate { get; set; }
        public string AddUser { get; set; }
        public string UpdUser { get; set; }
        public Nullable<System.DateTime> AddDate { get; set; }
    }
}
