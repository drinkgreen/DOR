using DORv3.BLL.BusinessObjects;
using DORv3.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DORv3.BLL
{
    public class DORUserBiz
    {
        FowlerDORContext context;
        public User UserInfo { get; set; }
        public DORUserBiz(int UserID)
        {
            context = new FowlerDORContext();
            this.UserInfo = context.Users.Where(u => u.ID == UserID).FirstOrDefault();
        }

        public DORUser GetUser()
        {
            DORUser user = new DORUser();
            user.UserID = UserInfo.ID;
            user.Username = UserInfo.Username;
            user.Email = UserInfo.Email;
            foreach(var record in context.XRef_UserDealershipRoles.Where(x => x.UserID == UserInfo.ID))
            {
                user.AccessLevels.Add(new UserRoles
                {
                    DealerId = record.DealershipID,
                    Role = context.Roles.Where(r => r.Id == record.RoleID.ToString()).FirstOrDefault() //Fix the RoleID string to int later
                });
            }

            return user;
        }

        public List<int> GetListOfAllDealerIDs()
        {
            return context.DealerShips.Select(x => x.DealerID).ToList();
        }

        public List<int> GetListOfUsersDealerIDs()
        {
            return context.XRef_UserDealershipRoles.Where(x => x.UserID == UserInfo.ID).Select(x => x.DealershipID).ToList();
        }
    }
}