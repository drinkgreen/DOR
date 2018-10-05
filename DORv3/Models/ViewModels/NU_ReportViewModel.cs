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
    public class NU_ReportViewModel : DORViewModel
    {
        public IList<NU_ReportObject> NU_ReportObjects { get; set; }

        public IList<NU_RecapReportObject> NU_RecapReportObjects { get; set; }

        public IList<dynamic> NU_Records { get; set; }

        [Display(Name = "Start Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public NU_ReportViewModel(int userID, DateTime startDate, DateTime endDate) : base(userID)
        {
            StartDate = startDate;
            EndDate = endDate;

            NU_Recap nu = new NU_Recap(StartDate, EndDate);
            NU_RecapReportObjects = nu.GetNU_RecapReport(DealerIDs);
        }
    }
}