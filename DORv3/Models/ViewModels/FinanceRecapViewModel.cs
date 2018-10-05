using DORv3.BLL.ReportObjects;
using DORv3.Domain;
using DORv3.Helpers;
using DORv3.Models.ReportObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DORv3.Models.ViewModels
{
    public class FinanceRecapViewModel : DORViewModel
    {
        public IList<FinanceRecapObject> FinanceRecapObjects { get; set; }

        public IList<FinanceRecapReportObject> FinanceRecapReportObjects { get; set; }

        public IList<dynamic> RecapRecords { get; set; }

        [Display(Name = "Start Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }


        public FinanceRecapViewModel(int userID, DateTime startDate, DateTime endDate) : base(userID)
        {
            StartDate = startDate;
            EndDate = endDate;

            FinanceRecap fr = new FinanceRecap(StartDate, EndDate);
            FinanceRecapReportObjects = fr.GetFinanceRecapReport(DealerIDs);
        }
    }
}