using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DORv3.BLL.FilterObjects
{
    public class Filter_MTD_FinanceManager : MTDFilterObj
    {
        public Filter_MTD_FinanceManager(object value) : base(value)
        {
            this.Property = "FinanceManager";
        }
    }
}