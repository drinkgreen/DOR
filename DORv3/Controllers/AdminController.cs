using DORv3.DAL.Models;
using DORv3.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace DORv3.Controllers
{
    public class AdminController : Controller
    {
        private FowlerDORContext context = new FowlerDORContext();
        // GET: Admin
        public ActionResult Index()
        {
            AdminViewModel vModel = new AdminViewModel(User.Identity.GetUserId<int>());
            return View(vModel);
        }

        public ActionResult AddUser()
        {
            AdminAddUserViewModel vModel = new AdminAddUserViewModel(User.Identity.GetUserId<int>());
            return View(vModel);
        }

        [HttpPost]
        public ActionResult AddUser(FormCollection col, AdminAddUserViewModel vModel)
        {
            if (ModelState.IsValid)
            {

            }

            return RedirectToAction("Index");
        }

        public ActionResult EditUser()
        {
            AdminViewModel vModel = new AdminViewModel(User.Identity.GetUserId<int>());
            return View(vModel);
        }
    }
}