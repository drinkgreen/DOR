using DORv3.BLL.ReportObjects;
using DORv3.Domain;
using DORv3.Models.ReportObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DORv3.Models.ViewModels
{
    public class SalesRecapViewModel : DORViewModel
    {
        public IList<SalesRecapObject> SalesRecapObjects { get; set; }
        public IList<SalesRecapReportObject> SalesRecapReport { get; set; }
        public IList<dynamic> RecapRecords { get; set; }

        [Display(Name = "Start Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public SalesRecapViewModel(int userID, DateTime startDate, DateTime endDate) : base(userID)
        {
            StartDate = startDate;
            EndDate = endDate;

            SalesRecap sr = new SalesRecap(StartDate, EndDate);
            SalesRecapReport = sr.GetSalesRecapReport(DealerIDs);
        }
    }
}