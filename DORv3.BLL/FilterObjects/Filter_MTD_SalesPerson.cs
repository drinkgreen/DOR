using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DORv3.BLL.FilterObjects
{
    public class Filter_MTD_SalesPerson : MTDFilterObj
    {
        public Filter_MTD_SalesPerson(object value) : base(value)
        {
            this.Property = "SalesPerson";
        }
    }
}