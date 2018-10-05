using DORv3.Helpers;
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
    public class RecapReportsController : Controller
    {
        DORService _dorService;
        string defaultStartDate = DateHelper.FirstDayOfTheMonth(DateTime.Now).ToShortDateString();
        string defaultEndDate = DateTime.Now.ToShortDateString();

        public RecapReportsController()
        {
            _dorService = new DORService();
        }

        // GET: RecapReports
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewSearch(string action, string sDate, string eDate)
        {
            var redirectURL = new UrlHelper(Request.RequestContext).Action(action, new { startDate = sDate, endDate = eDate });
            return Json(new { Url = redirectURL });
        }

        public ActionResult NUReport(string startDate = null, string endDate = null)
        {
            startDate = (startDate == null) ? defaultStartDate : startDate;
            endDate = (endDate == null) ? defaultEndDate : endDate;

            NU_ReportViewModel viewModel = new NU_ReportViewModel(User.Identity.GetUserId<int>(),Convert.ToDateTime(startDate), Convert.ToDateTime(endDate));
            var nuData = DORHelper.ToDataTable(viewModel.NU_RecapReportObjects.ToList());

            nuData = DORHelper.TransposeTable(nuData);
            var nuRecords = new List<dynamic>(nuData.Rows.Count);

            //TODO: Push this to a Function (Common class?) later
            foreach (DataRow row in nuData.Rows)
            {
                var obj = (IDictionary<string, object>)new ExpandoObject();

                foreach (DataColumn col in nuData.Columns)
                {
                    obj.Add(col.ColumnName, row[col]);
                }
                nuRecords.Add(obj);
            }

            viewModel.NU_Records = nuRecords;
            //viewModel.NU_ReportObjects = _dorService.GetFinanceRecapReport(startDate, endDate);

            return View(viewModel);
        }

        public ActionResult FinanceRecap(string startDate = null, string endDate = null)
        {
            startDate = (startDate == null) ? defaultStartDate : startDate;
            endDate = (endDate == null) ? defaultEndDate : endDate;

            FinanceRecapViewModel viewModel = new FinanceRecapViewModel(User.Identity.GetUserId<int>(),Convert.ToDateTime(startDate),Convert.ToDateTime(endDate) );

            var recapData = DORHelper.ToDataTable(viewModel.FinanceRecapReportObjects.ToList());

            recapData = DORHelper.TransposeTable(recapData);
            var recapRecords = new List<dynamic>(recapData.Rows.Count);

            //TODO: Push this to a Function (Common class?) later
            foreach (DataRow row in recapData.Rows)
            {
                var obj = (IDictionary<string, object>)new ExpandoObject();

                foreach (DataColumn col in recapData.Columns)
                {
                    obj.Add(col.ColumnName, row[col]);
                }
                recapRecords.Add(obj);
            }

            viewModel.RecapRecords = recapRecords;
            //viewModel.FinanceRecapObjects = _dorService.GetFinanceRecapReport(startDate, endDate);

            return View(viewModel);
        }

        public ActionResult SalesRecap(string startDate = null, string endDate = null)
        {
            startDate = (startDate == null) ? defaultStartDate : startDate;
            endDate = (endDate == null) ? defaultEndDate : endDate;

            SalesRecapViewModel viewModel = new SalesRecapViewModel(User.Identity.GetUserId<int>(),Convert.ToDateTime(startDate), Convert.ToDateTime(endDate));

            var recapData = DORHelper.ToDataTable(viewModel.SalesRecapReport.ToList());
            //var recapData = DORHelper.ToDataTable(_dorService.GetDOR1234RecapReport(startDate, endDate).ToList());

            recapData = DORHelper.TransposeTable(recapData);
            var recapRecords = new List<dynamic>(recapData.Rows.Count);

            //TODO: Push this to a Function (Common class?) later
            foreach (DataRow row in recapData.Rows)
            {
                var obj = (IDictionary<string, object>)new ExpandoObject();

                foreach (DataColumn col in recapData.Columns)
                {
                    obj.Add(col.ColumnName, row[col]);
                }
                recapRecords.Add(obj);
            }

            viewModel.RecapRecords = recapRecords;
            //viewModel.FinanceRecapObjects = _dorService.GetFinanceRecapReport(startDate, endDate);

            return View(viewModel);
        }


        public ActionResult DOR1234Recap(string startDate = null, string endDate = null)
        {
            startDate = (startDate == null) ? defaultStartDate : startDate;
            endDate = (endDate == null) ? defaultEndDate : endDate;

            DOR1234RecapViewModel viewModel = new DOR1234RecapViewModel(User.Identity.GetUserId<int>(),Convert.ToDateTime(startDate), Convert.ToDateTime(endDate));

            var recapData = DORHelper.ToDataTable(viewModel.DOR1234RecapReportObjects.ToList());
            //var recapData = DORHelper.ToDataTable(_dorService.GetDOR1234RecapReport(startDate, endDate).ToList());

            recapData = DORHelper.TransposeTable(recapData);
            var recapRecords = new List<dynamic>(recapData.Rows.Count);

            //TODO: Push this to a Function (Common class?) later
            foreach (DataRow row in recapData.Rows)
            {
                var obj = (IDictionary<string, object>)new ExpandoObject();

                foreach (DataColumn col in recapData.Columns)
                {
                    obj.Add(col.ColumnName, row[col]);
                }
                recapRecords.Add(obj);
            }

            viewModel.RecapRecords = recapRecords;
            //viewModel.FinanceRecapObjects = _dorService.GetFinanceRecapReport(startDate, endDate);

            return View(viewModel);
        }
    }
}