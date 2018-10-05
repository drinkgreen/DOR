using DORv3.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DORv3.BLL.BusinessObjects
{
    public class DORUser
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public List<UserRoles> AccessLevels { get; set; }

        public DORUser()
        {
            AccessLevels = new List<UserRoles>();
        }
    }
}