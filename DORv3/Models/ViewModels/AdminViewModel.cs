using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DORv3.Models.ViewModels
{
    public class AdminViewModel : DORViewModel
    {
        public AdminViewModel(int userID) : base(userID)
        {
        }

        public AdminViewModel()
        {
        }
    }
}