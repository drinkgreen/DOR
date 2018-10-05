using DORv3.DAL;
using DORv3.HelperLib;
using DORv3.Models;
using DORv3.Models.ViewModels;
using DORv3.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace DORv3.Controllers
{
    public class SalesboardController : Controller
    {
        DORService _dorService;
        SalesboardViewModel viewModel;
        public SalesboardController()
        {
            _dorService = new DORService();
        }
        // GET: Salesboard
        public ActionResult Index(string sbDate = null) //PRoof of COncept
        {
            string date = (sbDate == null) ? DateTime.Now.ToShortDateString() : sbDate;
            SalesboardViewModel viewModel = new SalesboardViewModel(User.Identity.GetUserId<int>(),Convert.ToDateTime(date));
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult NewSearch(string sbDate)
        {
            var redirectURL = new UrlHelper(Request.RequestContext).Action("Index", new { sbDate = sbDate });
            return Json(new { Url = redirectURL });
        }

        public ActionResult GoToMTD(DateTime dateOfSale, int dealerID, int vehicleType)
        {
            DateTime startDate = DateTime.Now, endDate = DateTime.Now;
            //string saleType;
            var sundays = DateHelper.GetAllDatesOfSpecifiedDayOfWeekInMonth(dateOfSale, DayOfWeek.Sunday);
            if (dateOfSale.DayOfWeek == DayOfWeek.Sunday)
            {
                var weeknum = sundays.IndexOf(dateOfSale) + 1;
                startDate = (weeknum == 1) ? DateHelper.FirstDayOfTheMonth(dateOfSale) : dateOfSale.AddDays(-6);
                endDate = dateOfSale.AddDays(-1);
            }
            else
            {
                startDate = endDate = dateOfSale;
            }

            TempData["StartDate"] = startDate.ToShortDateString();
            TempData["EndDate"] = endDate.ToShortDateString();
            TempData["DealerID"] = dealerID;
            TempData["VehicleType"] = vehicleType;
            //var result = new MTDController().GetMTD(startDate, endDate, dealerID, saleType);
            return RedirectToAction("Index", "MTD");
           // return View("~/Views/MTD/Index.aspx", result);
            
        }

    }
}