using DORv3.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DORv3.Models.ViewModels
{
    public class AdminAddUserViewModel : AdminViewModel
    {
        FowlerDORContext context;

        public List<DealerShip> Dealerships { get; set; }
        public List<Role> Roles { get; set; }
        public List<UserRoleObj> UserRoleObjects { get; set; }
        public AdminAddUserViewModel(int userID) : base(userID)
        {
            context = new FowlerDORContext();
            Dealerships = context.DealerShips.Where(d => (d.DisableDate == null || d.DisableDate > DateTime.Now) && DealerIDs.Contains(d.DealerID)).ToList();
            Roles = context.Roles.Where(r => r.Id != "1").Select(r => r).ToList();

            Roles.Add(new Role { Id = "0", Name = "No Access" });

            UserRoleObjects = new List<UserRoleObj>();

            foreach(var dealer in Dealerships)
            {
                UserRoleObjects.Add(new UserRoleObj
                {
                    IsActive = false,
                    DealerID = dealer.DealerID,
                    DealerName = dealer.DealerName,
                    RoleID = "0"
                });
            }
        }

        public class UserRoleObj
        {
            public bool IsActive { get; set; }
            public int DealerID { get; set; }
            public string DealerName { get; set; }
            public string RoleID { get; set; }
        }

        public AdminAddUserViewModel()
        {

        }
    }
}