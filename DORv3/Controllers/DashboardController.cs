using DORv3.BLL.BusinessObjects;
using DORv3.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using DORv3.DAL.Models;
using System.Data.Entity;

namespace DORv3.Controllers
{
    public class DashboardController : Controller
    {
        private FowlerDORContext context = new FowlerDORContext();
        // GET: Dashboard
        public ActionResult Index()
        {
            ListOfDealsViewModel viewModel = new ListOfDealsViewModel(User.Identity.GetUserId<int>());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(ListOfDealsViewModel vModel)
        {
            int searchID = vModel.SearchFilter.ID;
            string filterval = vModel.FilterValue;
            int dealerID = vModel.Dealership.DealerID;

            ListOfDealsViewModel viewModel = new ListOfDealsViewModel(User.Identity.GetUserId<int>());
            viewModel.GetListOfDeals(searchID,filterval, dealerID);
            return View(viewModel);
        }

        
        public ActionResult Get(int ID, string Num)
        {
            return View();
        }

        public ActionResult Add(int dealerId = 0)
        {
            AddDealViewModel viewModel = new AddDealViewModel(User.Identity.GetUserId<int>(), dealerId);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(AddDealViewModel vModel)
        {
            List<ModelError> errors = new List<ModelError>();
            if (ModelState.IsValid)
            {
                vModel.Deal.EnteredDt = DateTime.Now;
                vModel.Deal.UpdatedDt = DateTime.Now;
                vModel.Deal.DORid = context.MasterFIs.OrderByDescending(m=>m.DORid).Select(m => m.DORid).FirstOrDefault()+1;
                //context.MasterFIs.Add(vModel.Deal);
                //context.SaveChanges();
                vModel.AddDealRecord();

                return View("Index");
            }
            else
            {
                
                foreach (ModelState modelState in ViewData.ModelState.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {
                        errors.Add(error);
                    }
                }
            }

            return View(vModel);
            
        }

        public ActionResult Update(int ID)
        {
            UpdateDealViewModel viewModel = new UpdateDealViewModel(User.Identity.GetUserId<int>(),ID);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Update(UpdateDealViewModel vModel)
        {
            DealRecord deal = vModel.Deal;
           if (ModelState.IsValid)
            {
                deal.UpdatedDt = DateTime.Now;
                vModel.UpdateDealRecord();

                return View("Index");
            }
            TempData["Postback"] = "true";
            return View(vModel); 
        }

        //[HttpPost]
        //public ActionResult Update(FormCollection col)
        //{
        //    if (1==1)
        //    {
        //        int id = Convert.ToInt32(col["deal.dorid"]);
        //        FowlerDORContext context = new FowlerDORContext();
        //        MasterFI deal = (from d in context.MasterFIs
        //                   where d.DORid == id
        //                   select d).FirstOrDefault();

        //        deal.gap = 53;

        //        context.SaveChanges();            
        //    }
        //    return View();
        //}

        public ActionResult Details(int ID)
        {
            UpdateDealViewModel viewModel = new UpdateDealViewModel(User.Identity.GetUserId<int>(),ID);
            return View(viewModel);
        }
    }
}