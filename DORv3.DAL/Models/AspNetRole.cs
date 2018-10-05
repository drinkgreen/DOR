using System;
using System.Collections.Generic;

namespace DORv3.DAL.Models
{
    public partial class AspNetRole
    {
        public AspNetRole()
        {
            this.Users = new List<User>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Display { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsDataManager { get; set; }
        public bool CanAdd { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanDelete { get; set; }
        public bool Adjustments { get; set; }
        public bool OtherIncome { get; set; }
        public bool Unwind { get; set; }
        public bool ReportsOnly { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
