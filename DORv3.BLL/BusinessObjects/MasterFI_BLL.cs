using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DORv3.DAL.Models;

namespace DORv3.BLL.BusinessObjects
{
    public abstract class MasterFI_BLL : MasterFI
    {
        public virtual new int MasterFiId { get; set; }
        public virtual new int DORid { get; set; }
        public virtual new int Dealerid { get; set; }
        public virtual new string buyerlname { get; set; }
        public virtual new string buyerfname { get; set; }
        public virtual new string cobuyerlname { get; set; }
        public virtual new string cobuyerfname { get; set; }
        public virtual new string vehicle { get; set; }
        public virtual new Nullable<int> vehicleid { get; set; }
        public virtual new string vehicletype { get; set; }
        public virtual new Nullable<int> vehicletypeid { get; set; }
        public virtual new Nullable<int> businesssource { get; set; }
        public virtual new string otherbusinesssource { get; set; }
        public virtual new Nullable<int> salescategory { get; set; }
        public virtual new int status { get; set; }
        public virtual new string intent { get; set; }
        public virtual new string turnoption { get; set; }
        public virtual new Nullable<int> daysinstock { get; set; }
        public virtual new string dealnum { get; set; }
        public virtual new string stocknum { get; set; }
        public virtual new string make { get; set; }
        public virtual new string model { get; set; }
        public virtual new string makeother { get; set; }
        public virtual new string modelother { get; set; }
        public virtual new int year { get; set; }
        public virtual new int mileage { get; set; }
        public virtual new System.DateTime salesdate { get; set; }
        public virtual new Nullable<decimal> gross { get; set; }
        public virtual new decimal holdback { get; set; }
        public virtual new decimal payablegross { get; set; }
        public virtual new Nullable<decimal> frontendgross { get; set; }
        public virtual new bool trade1status { get; set; }
        public virtual new string trade1make { get; set; }
        public virtual new string trade1model { get; set; }
        public virtual new string trade1makeother { get; set; }
        public virtual new string trade1modelother { get; set; }
        public virtual new Nullable<int> trade1year { get; set; }
        public virtual new Nullable<int> trade1mileage { get; set; }
        public virtual new string trade1intent { get; set; }
        public virtual new string trade1title { get; set; }
        public virtual new string trade1lien { get; set; }
        public virtual new Nullable<decimal> trade1acv { get; set; }
        public virtual new Nullable<decimal> trade1payoff { get; set; }
        public virtual new Nullable<decimal> trade1equity { get; set; }
        public virtual new bool trade2status { get; set; }
        public virtual new string trade2make { get; set; }
        public virtual new string trade2model { get; set; }
        public virtual new string trade2makeother { get; set; }
        public virtual new string trade2modelother { get; set; }
        public virtual new Nullable<int> trade2year { get; set; }
        public virtual new Nullable<int> trade2mileage { get; set; }
        public virtual new string trade2intent { get; set; }
        public virtual new string trade2title { get; set; }
        public virtual new string trade2lien { get; set; }
        public virtual new Nullable<decimal> trade2acv { get; set; }
        public virtual new Nullable<decimal> trade2payoff { get; set; }
        public virtual new Nullable<decimal> trade2equity { get; set; }
        public virtual new Nullable<int> salesmanager { get; set; }
        public virtual new Nullable<int> salesperson1 { get; set; }
        public virtual new string salesperson1per { get; set; }
        public virtual new Nullable<int> salesperson2 { get; set; }
        public virtual new string salesperson2per { get; set; }
        public virtual new Nullable<int> salesperson3 { get; set; }
        public virtual new string salesperson3per { get; set; }
        public virtual new int fimanager { get; set; }
        public virtual new string fitype { get; set; }
        public virtual new string fipaymentin { get; set; }
        public virtual new string fipaymentout { get; set; }
        public virtual new string fitermin { get; set; }
        public virtual new string fitermout { get; set; }
        public virtual new Nullable<decimal> ficashdown { get; set; }
        public virtual new string lienholder { get; set; }
        public virtual new Nullable<decimal> price { get; set; }
        public virtual new Nullable<System.DateTime> delvdate { get; set; }
        public virtual new Nullable<int> gradecreditid { get; set; }
        public virtual new Nullable<int> gradecredit { get; set; }
        public virtual new Nullable<decimal> gap { get; set; }
        public virtual new Nullable<decimal> enviro { get; set; }
        public virtual new Nullable<decimal> etch { get; set; }
        public virtual new Nullable<decimal> dent { get; set; }
        public virtual new Nullable<decimal> tirewheel { get; set; }
        public virtual new Nullable<decimal> cl { get; set; }
        public virtual new Nullable<decimal> ah { get; set; }
        public virtual new Nullable<decimal> vsc { get; set; }
        public virtual new string vscoption { get; set; }
        public virtual new Nullable<decimal> TBD { get; set; }
        public virtual new Nullable<decimal> Maint { get; set; }
        public virtual new Nullable<decimal> finresv { get; set; }
        public virtual new Nullable<decimal> frontend { get; set; }
        public virtual new Nullable<decimal> backend { get; set; }
        public virtual new Nullable<decimal> totalgross { get; set; }
        public virtual new Nullable<int> creditscore { get; set; }
        public virtual new string datetoacct { get; set; }
        public virtual new string bookeddate { get; set; }
        public virtual new Nullable<System.DateTime> unwinddate { get; set; }
        public virtual new string datetotag { get; set; }
        public virtual new string datetobank { get; set; }
        public virtual new string datepaid { get; set; }
        public virtual new string sectrade { get; set; }
        public virtual new Nullable<decimal> amt_fin { get; set; }
        public virtual new Nullable<int> fintype { get; set; }
        public virtual new System.DateTime EnteredDt { get; set; }
        public virtual new System.DateTime UpdatedDt { get; set; }
    }
}