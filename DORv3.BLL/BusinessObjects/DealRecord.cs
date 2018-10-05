using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
//using DORv3.DAL.Models;

namespace DORv3.BLL.BusinessObjects
{
    public partial class DealRecord
    {
        public int MasterFiId { get; set; }
        public int DORid { get; set; }
        [Required(ErrorMessage = "A Dealership is required")]
        public int Dealerid { get; set; }

        [Required(ErrorMessage = "Buyer's LAST Name is required")]
        public string buyerlname { get; set; }
        [Required(ErrorMessage = "Buyer's FIRST Name is required")]
        public string buyerfname { get; set; }
        public string cobuyerlname { get; set; }
        public string cobuyerfname { get; set; }
        public string vehicle { get; set; }
        [Required(ErrorMessage = "Vehicle is required")]
        public Nullable<int> vehicleid { get; set; }
        public string vehicletype { get; set; }
        [Required(ErrorMessage = "Vehicle Type is required")]
        public Nullable<int> vehicletypeid { get; set; }
        [Required(ErrorMessage = "A Business Source is required")]
        public Nullable<int> businesssource { get; set; }
        public string otherbusinesssource { get; set; }
        [Required(ErrorMessage = "Sales Category is required")]
        public Nullable<int> salescategory { get; set; }
        [Required(ErrorMessage = "Deal Status is required")]
        public int status { get; set; }
        [Required(ErrorMessage = "Intent is required")]
        public string intent { get; set; }
        public string turnoption { get; set; }
        [Required(ErrorMessage = "Days in Stock must be specified")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Days In Stock: Only Numeric values")]
        public Nullable<int> daysinstock { get; set; }
        [RegularExpression("([0-9]*)", ErrorMessage = "Deal Number: Only numeric values")]
        public string dealnum { get; set; }
        [Required(ErrorMessage = "Stock Number is required")]
        public string stocknum { get; set; }
        [Required(ErrorMessage = "Make of Vehicle is required")]
        public string make { get; set; }
        [Required(ErrorMessage = "Model of Vehicle is required")]
        public string model { get; set; }
        public string makeother { get; set; }
        public string modelother { get; set; }
        [Required(ErrorMessage = "Year of Vehicle is required")]
        public int year { get; set; }
        [Required(ErrorMessage = "Vehicle Mileage is required")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Mileage: Only numeric values")]
        public int mileage { get; set; }
        [Required(ErrorMessage = "Sales Date is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime salesdate { get; set; }
        public Nullable<decimal> gross { get; set; }
        [Required(ErrorMessage = "Holdback is required")]
        [RegularExpression("(^[0-9]\\d*(\\.\\d+)?$)", ErrorMessage = "Holdback: Only valid decimal values")]
        public decimal holdback { get; set; }
        [Required(ErrorMessage = "Gross is required")]
        [RegularExpression("(^[0-9]\\d*(\\.\\d+)?$)", ErrorMessage = "Gross: Only valid decimal values")]
        public decimal payablegross { get; set; }
        public Nullable<decimal> frontendgross { get; set; }
        public bool trade1status { get; set; }
        public string trade1make { get; set; }
        public string trade1model { get; set; }
        public string trade1makeother { get; set; }
        public string trade1modelother { get; set; }
        public Nullable<int> trade1year { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Trade 1 Mileage: Only numeric values")]
        public Nullable<int> trade1mileage { get; set; }
        public string trade1intent { get; set; }
        public string trade1title { get; set; }
        public string trade1lien { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Trade 1 ACV: Only numeric values")]
        public Nullable<decimal> trade1acv { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Trade 1 Payoff: Only numeric values")]
        public Nullable<decimal> trade1payoff { get; set; }
        public Nullable<decimal> trade1equity { get; set; }
        public bool trade2status { get; set; }
        public string trade2make { get; set; }
        public string trade2model { get; set; }
        public string trade2makeother { get; set; }
        public string trade2modelother { get; set; }
        public Nullable<int> trade2year { get; set; }

        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Trade 2 Mileage: Only numeric values")]
        public Nullable<int> trade2mileage { get; set; }
        public string trade2intent { get; set; }
        public string trade2title { get; set; }
        public string trade2lien { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Trade 2 ACV: Only numeric values")]
        public Nullable<decimal> trade2acv { get; set; }

        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Trade 2 Payoff: Only numeric values")]
        public Nullable<decimal> trade2payoff { get; set; }
        public Nullable<decimal> trade2equity { get; set; }
        [Required(ErrorMessage = "Sales Manager is required")]
        public Nullable<int> salesmanager { get; set; }
        [Required(ErrorMessage = "Primary Sales person is required")]
        public Nullable<int> salesperson1 { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Salesperson 1 %: Only numeric values")]
        public string salesperson1per { get; set; }
        public Nullable<int> salesperson2 { get; set; }

        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Salesperson 2 %: Only numeric values")]
        public string salesperson2per { get; set; }
        public Nullable<int> salesperson3 { get; set; }

        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Salesperson 3 %: Only numeric values")]
        public string salesperson3per { get; set; }
        [Required(ErrorMessage = "Finance Manager is required")]
        public int fimanager { get; set; }
        public string fitype { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Finance-Payment In: Only numeric values")]
        public string fipaymentin { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Finance-Payment Out: Only numeric values")]
        public string fipaymentout { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Finance-Term In: Only numeric values")]
        public string fitermin { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Finance-Term Out: Only numeric values")]
        public string fitermout { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Finance-Cash Down: Only numeric values")]
        public Nullable<decimal> ficashdown { get; set; }
        public string lienholder { get; set; }
        public Nullable<decimal> price { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> delvdate { get; set; }
        public Nullable<int> gradecreditid { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Grade Credit: Only numeric values")]
        public Nullable<int> gradecredit { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Gap: Only numeric values")]
        public Nullable<decimal> gap { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Enviro: Only numeric values")]
        public Nullable<decimal> enviro { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Etch: Only numeric values")]
        public Nullable<decimal> etch { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Dent: Only numeric values")]
        public Nullable<decimal> dent { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Tire & Wheel: Only numeric values")]
        public Nullable<decimal> tirewheel { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Credit Life: Only numeric values")]
        public Nullable<decimal> cl { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "A&H: Only numeric values")]
        public Nullable<decimal> ah { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "VSC: Only numeric values")]
        public Nullable<decimal> vsc { get; set; }
        public string vscoption { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "TBD: Only numeric values")]
        public Nullable<decimal> TBD { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Maint: Only numeric values")]
        public Nullable<decimal> Maint { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Finance Reserve: Only numeric values")]
        public Nullable<decimal> finresv { get; set; }
        public Nullable<decimal> frontend { get; set; }
        public Nullable<decimal> backend { get; set; }
        public Nullable<decimal> totalgross { get; set; }
        public Nullable<int> creditscore { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string datetoacct { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string bookeddate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> unwinddate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string datetotag { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string datetobank { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string datepaid { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string sectrade { get; set; }
        public Nullable<decimal> amt_fin { get; set; }
        public Nullable<int> fintype { get; set; }
        public System.DateTime EnteredDt { get; set; }
        public System.DateTime UpdatedDt { get; set; }
    }
}