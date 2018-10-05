using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using DORv3.Models.ViewModels;

namespace DORv3.Controllers
{
    public class HomeController : Controller
    {
        //DORViewModel viewModel = new DORViewModel();
        int userID;
        public ActionResult Index()
        {
            userID = (User.Identity.IsAuthenticated ? User.Identity.GetUserId<int>() : -1);
            return View(new DORViewModel(userID));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            userID = (User.Identity.IsAuthenticated ? User.Identity.GetUserId<int>() : -1);
            return View(new DORViewModel(userID));
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            userID = (User.Identity.IsAuthenticated ? User.Identity.GetUserId<int>() : -1);
            return View(new DORViewModel(userID));
        }

        public ActionResult Input()
        {
            ViewBag.Message = "Your Input page.";
            userID = (User.Identity.IsAuthenticated ? User.Identity.GetUserId<int>() : -1);
            return View(new DORViewModel(userID));
        }
    }
}