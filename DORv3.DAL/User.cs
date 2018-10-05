using System;
using System.Collections.Generic;

namespace DORv3.DAL
{
    public partial class User
    {
        public string ID { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public Nullable<System.DateTime> LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public bool IPRestricted { get; set; }
    }
}
