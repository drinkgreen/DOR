using DORv3.Models.ViewModels;
using DORv3.Service;
using DORv3.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Dynamic;
using DORv3.Domain;
using WebGrease.Css.Extensions;
using DORv3.BLL.BusinessObjects;
using DORv3.Models.FilterFields.Base;
using DORv3.Models.FilterFields;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using OfficeOpenXml;
using System.Reflection;
using ClosedXML.Excel;
using Microsoft.Office.Interop;
using Excel = Microsoft.Office.Interop.Excel;

using Microsoft.AspNet.Identity;
using DORv3.BLL.FilterObjects;
using DORv3.BLL.FilterObjects.Base;


namespace DORv3.Controllers
{
    public class MTDController : Controller
    {
        List<MTDFilterField> _mtdFilterFields;
        DateTime defaultStartDate = DateHelper.FirstDayOfTheMonth(DateTime.Now);
        DateTime defaultEndDate = DateTime.Now;
        public MTDController()
        {
            //_dorService = new DORService();
            //List<FilterFields> that holds (1) Name of Field on View and (2) Cooresponding FilterFieldType
            _mtdFilterFields = new List<MTDFilterField>{
                new MTD_Dealerid("Dealership.DealerID", WhereFilterType.Equal),
                new MTD_VehicleType("VehicleType.VehicleTypeID", WhereFilterType.Equal),
                new MTD_DealStatus("DealStatus.StatusId", WhereFilterType.Equal),
                new MTD_Vehicle("VehicleKind.VehicleId", WhereFilterType.Equal),
                new MTD_SalesCategory("SalesCategory.SalesCategoryId", WhereFilterType.Equal),
                new MTD_FinanceManager("FinanceManager.FMId", WhereFilterType.Equal),
                new MTD_SalesManager("SalesManager.SMId", WhereFilterType.Equal),
                new MTD_SalesPerson("SalesPerson.ID", WhereFilterType.Equal),
                new MTD_BusinessSource("BusinessSource.BusinessSourceID", WhereFilterType.Equal)
            };
        }

        public ActionResult Index()
        //public ActionResult Index(string startDate = null, string endDate = null, string dealerID = null, string vehicleType = null)
        {
            DateTime sDate = TempData["StartDate"] == null ? defaultStartDate : Convert.ToDateTime(TempData["StartDate"]);
            DateTime eDate = TempData["EndDate"] == null ? defaultEndDate : Convert.ToDateTime(TempData["EndDate"]);
            int DealerID = TempData["DealerID"] == null ? 0 : Convert.ToInt32(TempData["DealerID"]);
            int VehicleType = TempData["VehicleType"] == null ? 0 : Convert.ToInt32(TempData["VehicleType"]);

            List<MTDFilterObj> filters = new List<MTDFilterObj>();
            if (DealerID > 0 && DealerID < 99 ) //Not All but also not Fowler Holding aka "All"
            {
                filters.Add(_mtdFilterFields.Where(f => f.FieldName == "Dealership.DealerID").First().GetFilterObject(DealerID));
            }
            
            if (VehicleType > 0)
            {
                filters.Add(_mtdFilterFields.Where(f => f.FieldName == "VehicleType.VehicleTypeID").First().GetFilterObject(VehicleType));
            }

            //Default value is the Current Date from Toyota Norman, both New and Used
            return View(MTD(sDate, eDate, DealerID,filters));
        }

        [HttpPost]
        public ActionResult Index(FormCollection col)
        {
            DateTime sDate = col["StartDate"] == "" ? defaultStartDate : Convert.ToDateTime(col["StartDate"].ToString());
            DateTime eDate = col["EndDate"] == "" ? defaultEndDate : Convert.ToDateTime(col["EndDate"].ToString());

            List<MTDFilterObj> filters = new List<MTDFilterObj>();
            
            //ID Fields
            foreach(MTDFilterField filter in _mtdFilterFields)
            {
                string val = col[filter.FieldName];
                if (val != null && val != "0")  //If filter exists and if Filter is not set to "All"
                {
                    filters.Add(filter.GetFilterObject(Convert.ToInt32(val)));
                    //AddFilter to list of Filters to Use
                }
            }
            int dealerID = col["Dealership.DealerID"] == null ? 1 : Convert.ToInt32(col["Dealership.DealerID"].ToString());
            //string saleType = col["VehicleType.VehicleTypeId"] == null ? "0" : col["VehicleType.VehicleTypeId"].ToString();

            MTDViewModel viewModel = MTD(sDate, eDate, dealerID, filters);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_MTDGrid", viewModel);
            }
            else
            {
                return View(viewModel);
            }
        }
        
        // GET: MTD
        public ActionResult GetMTD(string startDate, string endDate, string dealerID, string saleType) //PRoof of concept
        {
            //var redirectURL = Get_MTD(Convert.ToDateTime(startDate), Convert.ToDateTime(endDate), Convert.ToInt32(dealerID), saleType);
            //return View(MTD(Convert.ToDateTime(startDate2), Convert.ToDateTime(endDate2), Convert.ToInt32(dealerID2), saleType2));
            //return restult;
            //var redirectURL = new UrlHelper(Request.RequestContext).Action("MTD", new { startDate = Convert.ToDateTime(startDate2), endDate = Convert.ToDateTime(endDate2), dealerID = Convert.ToInt32(dealerID2), saleType = saleType2 });
            var redirectURL = new UrlHelper(Request.RequestContext).Action("Index", new { startDate = startDate, endDate = endDate, dealerID = dealerID, saleType = saleType });
            return Json(new { Url = redirectURL });
            
        }

        //[HttpPost]
        private MTDViewModel MTD(DateTime startDate, DateTime endDate, int dealerID, List<MTDFilterObj> filters)
        {
            MTDViewModel viewModel = new MTDViewModel(User.Identity.GetUserId<int>(),startDate, endDate, dealerID, filters);

            var mtdData = DORHelper.ToDataTable(viewModel.MTDReport.ToList());
            var mtdRecords = new List<dynamic>(mtdData.Rows.Count);

            //var test = _dorService.GetMonthToDateObjects(startDate, endDate, dealerID, saleType).ToList();
            //test.Where(t => t.deal_frnt_end != null).ForEach(t => t.deal_frnt_end = (decimal)Math.Round((double)t.deal_frnt_end, 4));
            //TODO: Push this to a Function (Common class?) later
            foreach (DataRow row in mtdData.Rows)
            {
                var obj = (IDictionary<string, object>)new ExpandoObject();

                foreach (DataColumn col in mtdData.Columns)
                {
                    obj.Add(col.ColumnName, row[col]);
                }
                mtdRecords.Add(obj);
            }
            viewModel.MTDRecords = mtdRecords;

            return viewModel;
        }

        
        private ActionResult MTD(DateTime startDate, DateTime endDate, int dealerID, string saleType) //PRoof of concept
        {
            MTDViewModel viewModel = new MTDViewModel(User.Identity.GetUserId<int>(),startDate, endDate, dealerID, saleType);

            var mtdData = DORHelper.ToDataTable(viewModel.MTDReport.ToList());
            //ClosedXmlProofOfConcept(mtdData);
            var mtdRecords = new List<dynamic>(mtdData.Rows.Count);

            //var test = _dorService.GetMonthToDateObjects(startDate, endDate, dealerID, saleType).ToList();
            //test.Where(t => t.deal_frnt_end != null).ForEach(t => t.deal_frnt_end = (decimal)Math.Round((double)t.deal_frnt_end, 4));
            //TODO: Push this to a Function (Common class?) later
            foreach (DataRow row in mtdData.Rows)
            {
                var obj = (IDictionary<string, object>)new ExpandoObject();

                foreach (DataColumn col in mtdData.Columns)
                {
                    obj.Add(col.ColumnName, row[col]);
                }
                mtdRecords.Add(obj);
            }
            viewModel.MTDRecords = mtdRecords;
            
         
            return View(viewModel);
        }

      

        [HttpPost]
        public ActionResult Excel(FormCollection col)
        {
            DateTime sDate = col["StartDate"] == null ? DateTime.Now : Convert.ToDateTime(col["StartDate"].ToString());
            DateTime eDate = col["EndDate"] == null ? DateTime.Now : Convert.ToDateTime(col["EndDate"].ToString());

            List<MTDFilterObj> filters = new List<MTDFilterObj>();

            //ID Fields
            foreach (MTDFilterField filter in _mtdFilterFields)
            {
                string val = col[filter.FieldName];
                if (val != null && val != "0")  //If filter exists and if Filter is not set to "All"
                {
                    filters.Add(filter.GetFilterObject(Convert.ToInt32(val)));
                    //AddFilter to list of Filters to Use
                }
            }
            int dealerID = col["Dealership.DealerID"] == null ? 1 : Convert.ToInt32(col["Dealership.DealerID"].ToString());
            //string saleType = col["VehicleType.VehicleTypeId"] == null ? "0" : col["VehicleType.VehicleTypeId"].ToString();


            //return MTD(sDate, eDate, dealerID, saleType);
            var mtdData = DORHelper.ToDataTable(new MTDViewModel(User.Identity.GetUserId<int>(),sDate, eDate, dealerID, filters).MTDReport.ToList());
            ClosedXmlProofOfConcept(mtdData);

            TempData["StartDate"] = sDate.ToShortDateString();
            TempData["EndDate"] = eDate.ToShortDateString();
            return RedirectToAction("Index", "MTD", new { dealerID = dealerID });
        }

        //[HttpPost]
        //private ActionResult Excel(DateTime startDate, DateTime endDate, int dealerID, string saleType) //PRoof of concept
        //{
        //    var mtdData = DORHelper.ToDataTable(new MTDViewModel(startDate, endDate, dealerID, filters).MTDReport.ToList());
        //    ClosedXmlProofOfConcept(mtdData);

        //    return View("MTD");
        //}

        public void WriteHtmlTable<T>(IEnumerable<T> data, TextWriter output)
        {
            //Writes markup characters and text to an ASP.NET server control output stream. This class provides formatting capabilities that ASP.NET server controls use when rendering markup to clients.
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                {

                    //  Create a form to contain the List
                    Table table = new Table();
                    TableRow row = new TableRow();
                    PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
                    foreach (PropertyDescriptor prop in props)
                    {
                        TableHeaderCell hcell = new TableHeaderCell();
                        hcell.Text = prop.Name;
                        hcell.BackColor = System.Drawing.Color.Yellow;
                        row.Cells.Add(hcell);
                    }

                    table.Rows.Add(row);

                    //  add each of the data item to the table
                    foreach (T item in data)
                    {
                        row = new TableRow();
                        foreach (PropertyDescriptor prop in props)
                        {
                            TableCell cell = new TableCell();
                            cell.Text = prop.Converter.ConvertToString(prop.GetValue(item));
                            row.Cells.Add(cell);
                        }
                        table.Rows.Add(row);
                    }

                    //  render the table into the htmlwriter
                    table.RenderControl(htw);

                    //  render the htmlwriter into the response
                    output.Write(sw.ToString());
                }
            }

        }

        public void ExportListFromTable()
        {
            var data = new[]{
                               new{ Name="Ram", Email="ram@techbrij.com", Phone="111-222-3333" },
                               new{ Name="Shyam", Email="shyam@techbrij.com", Phone="159-222-1596" },
                               new{ Name="Mohan", Email="mohan@techbrij.com", Phone="456-222-4569" },
                               new{ Name="Sohan", Email="sohan@techbrij.com", Phone="789-456-3333" },
                               new{ Name="Karan", Email="karan@techbrij.com", Phone="111-222-1234" },
                               new{ Name="Brij", Email="brij@techbrij.com", Phone="111-222-3333" }
                      };

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=Contact.xlsx");
            Response.AddHeader("Content-Type", "application/vnd.ms-excel");
            WriteHtmlTable(data, Response.Output);
            Response.End();
        }

        public void EPPlusProofOfConcept()
        {
            using (var p = new ExcelPackage())
            {
                var ws = p.Workbook.Worksheets.Add("MTD Report");

                
            }
        }

        public void ClosedXmlProofOfConcept(DataTable dt)
        {
            string fileLocation = Path.Combine(Path.GetTempPath(), "MTDReport.xlsx");
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "MTD Report");
                wb.SaveAs(fileLocation);
                //TempData["ExcelFileSaved"] = fileLocation;
            }

            var excel = new Excel.Application();
            Excel.Workbooks books = excel.Workbooks;
            Excel.Workbook sheet = books.Open(fileLocation);
            excel.Visible = true;
            //sheet.tables
        }
    }
}