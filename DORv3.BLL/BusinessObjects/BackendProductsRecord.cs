using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DORv3.BLL.BusinessObjects
{
    public class BackendProductsRecord
    {
        public decimal? GAP { get; set; }

        public decimal? Enviro { get; set; }

        public decimal? Etch { get; set; }

        public decimal? Dent { get; set; }

        public decimal? TireWheel { get; set; }

        public decimal? CL { get; set; }

        public decimal? AH { get; set; }

        public decimal? VSC { get; set; }

        [StringLength(50)]
        public string VSCOption { get; set; }

        public decimal? TBD { get; set; }

        public decimal? Maint { get; set; }
    }
}