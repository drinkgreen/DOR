using DORv3.BLL.BusinessObjects;
using DORv3.BLL;
using DORv3.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DORv3.Models.ViewModels
{
    public abstract class ViewModelBase
    {
        public DORUser CurrentUser { get; set; }

        public List<int> DealerIDs { get; set; }

        public bool IsSiteAdmin { get; set; }

        public List<int> Years { get; set; }
    }


    public class DORViewModel : ViewModelBase
    {

        public DORViewModel(int userID)
        {
            if (userID > 0)
            {
                DORUserBiz biz = new DORUserBiz(userID);
                this.CurrentUser = biz.GetUser();
                this.IsSiteAdmin = CurrentUser.AccessLevels.Exists(a => a.Role.Name == "SiteAdmin");
                this.DealerIDs = (IsSiteAdmin ? biz.GetListOfAllDealerIDs() : biz.GetListOfUsersDealerIDs());
            }

            this.Years = new List<int>();
            for (int i = DateTime.Now.Year; i > 1920; i--)
            {
                Years.Add(i);
            };
        }

        public DORViewModel()
        {

        }

    }
}