using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DORv3.BLL.FilterObjects
{
    public class Filter_MTD_SalesManager : MTDFilterObj
    {
        public Filter_MTD_SalesManager(object value) : base(value)
        {
            this.Property = "SalesManager";
        }
    }
}