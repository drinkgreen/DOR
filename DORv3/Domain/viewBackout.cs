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
    
    public partial class viewBackout
    {
        public int DORId { get; set; }
        public string DealNumber { get; set; }
        public Nullable<int> DealerId { get; set; }
        public Nullable<int> StatusId { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        public Nullable<decimal> payablegross { get; set; }
        public Nullable<decimal> BEGross { get; set; }
    }
}
