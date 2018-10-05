using System;
using System.Collections.Generic;

namespace DORv3.DAL.Models
{
    public partial class AspNetUserLogin
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
