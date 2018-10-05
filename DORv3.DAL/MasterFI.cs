namespace DORv3.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MasterFI
    {
        public int MasterFiId { get; set; }

        public int DORid { get; set; }

        public int Dealerid { get; set; }

        [StringLength(50)]
        public string buyerlname { get; set; }

        [StringLength(50)]
        public string buyerfname { get; set; }

        [StringLength(50)]
        public string cobuyerlname { get; set; }

        [StringLength(50)]
        public string cobuyerfname { get; set; }

        [StringLength(50)]
        public string vehicle { get; set; }

        public int vehicleid { get; set; }

        [StringLength(50)]
        public string vehicletype { get; set; }

        public int vehicletypeid { get; set; }

        [StringLength(50)]
        public string businesssource { get; set; }

        [StringLength(50)]
        public string otherbusinesssource { get; set; }

        [StringLength(50)]
        public string salescategory { get; set; }

        [StringLength(50)]
        public string status { get; set; }

        [StringLength(50)]
        public string intent { get; set; }

        [StringLength(50)]
        public string turnoption { get; set; }

        public int? daysinstock { get; set; }

        [StringLength(50)]
        public string dealnum { get; set; }

        [StringLength(50)]
        public string stocknum { get; set; }

        [StringLength(50)]
        public string make { get; set; }

        [StringLength(50)]
        public string model { get; set; }

        [StringLength(50)]
        public string makeother { get; set; }

        [StringLength(50)]
        public string modelother { get; set; }

        public int year { get; set; }

        public int mileage { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime salesdate { get; set; }

        public decimal? gross { get; set; }

        public decimal holdback { get; set; }

        [Column(TypeName = "money")]
        public decimal payablegross { get; set; }

        public decimal? frontendgross { get; set; }

        public bool trade1status { get; set; }

        [StringLength(50)]
        public string trade1make { get; set; }

        [StringLength(50)]
        public string trade1model { get; set; }

        [StringLength(50)]
        public string trade1makeother { get; set; }

        [StringLength(50)]
        public string trade1modelother { get; set; }

        public int? trade1year { get; set; }

        public int? trade1mileage { get; set; }

        [StringLength(50)]
        public string trade1intent { get; set; }

        [StringLength(50)]
        public string trade1title { get; set; }

        [StringLength(50)]
        public string trade1lien { get; set; }

        public decimal? trade1acv { get; set; }

        public decimal? trade1payoff { get; set; }

        public decimal? trade1equity { get; set; }

        public bool trade2status { get; set; }

        [StringLength(50)]
        public string trade2make { get; set; }

        [StringLength(50)]
        public string trade2model { get; set; }

        [StringLength(50)]
        public string trade2makeother { get; set; }

        [StringLength(50)]
        public string trade2modelother { get; set; }

        public int? trade2year { get; set; }

        public int? trade2mileage { get; set; }

        [StringLength(50)]
        public string trade2intent { get; set; }

        [StringLength(50)]
        public string trade2title { get; set; }

        [StringLength(50)]
        public string trade2lien { get; set; }

        public decimal? trade2acv { get; set; }

        public decimal? trade2payoff { get; set; }

        public decimal? trade2equity { get; set; }

        [StringLength(50)]
        public string salesmanager { get; set; }

        [StringLength(50)]
        public string salesperson1 { get; set; }

        [StringLength(50)]
        public string salesperson1per { get; set; }

        [StringLength(50)]
        public string salesperson2 { get; set; }

        [StringLength(50)]
        public string salesperson2per { get; set; }

        [StringLength(50)]
        public string salesperson3 { get; set; }

        [StringLength(50)]
        public string salesperson3per { get; set; }

        [Required]
        [StringLength(50)]
        public string fimanager { get; set; }

        [StringLength(50)]
        public string fitype { get; set; }

        [StringLength(50)]
        public string fipaymentin { get; set; }

        [StringLength(50)]
        public string fipaymentout { get; set; }

        [StringLength(50)]
        public string fitermin { get; set; }

        [StringLength(50)]
        public string fitermout { get; set; }

        public decimal? ficashdown { get; set; }

        [Required]
        public string lienholder { get; set; }

        public decimal? price { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? delvdate { get; set; }

        public int? gradecreditid { get; set; }

        public decimal? gap { get; set; }

        public decimal? enviro { get; set; }

        public decimal? etch { get; set; }

        public decimal? dent { get; set; }

        public decimal? tirewheel { get; set; }

        public decimal? cl { get; set; }

        public decimal? ah { get; set; }

        public decimal? vsc { get; set; }

        [StringLength(50)]
        public string vscoption { get; set; }

        public decimal? TBD { get; set; }

        public decimal? Maint { get; set; }

        public decimal? finresv { get; set; }

        public decimal? frontend { get; set; }

        public decimal? backend { get; set; }

        public decimal? totalgross { get; set; }

        public int? creditscore { get; set; }

        [StringLength(50)]
        public string datetoacct { get; set; }

        [StringLength(50)]
        public string bookeddate { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? unwinddate { get; set; }

        [StringLength(50)]
        public string datetotag { get; set; }

        [StringLength(50)]
        public string datetobank { get; set; }

        [StringLength(50)]
        public string datepaid { get; set; }

        [StringLength(50)]
        public string sectrade { get; set; }

        public decimal? amt_fin { get; set; }

        public int? fintype { get; set; }

        public DateTime EnteredDt { get; set; }

        public DateTime UpdatedDt { get; set; }
    }
}
