using DORv3.BLL.ReportObjects;
using DORv3.Domain;
using DORv3.Models.ReportObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace DORv3.Models.ViewModels
{
    public class DOR1234RecapViewModel : DORViewModel
    {
        public IList<dynamic> RecapRecords { get; set; }
        public List<DOR1234ReportObject> DOR1234RecapReportObjects { get; set; }

        [Display(Name = "Start Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        

        public DOR1234RecapViewModel(int userID, DateTime startDate, DateTime endDate) : base(userID)
        {
            StartDate = startDate;
            EndDate = endDate;
            DOR1234 dr = new DOR1234(StartDate, EndDate);
            DOR1234RecapReportObjects = dr.GetDOR1234Report(DealerIDs);
        }
    }
}