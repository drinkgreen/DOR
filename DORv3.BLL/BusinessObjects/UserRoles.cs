using DORv3.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DORv3.BLL.BusinessObjects
{
    public class UserRoles
    {
        public int DealerId { get; set; }
        public Role Role { get; set; }
    }
}