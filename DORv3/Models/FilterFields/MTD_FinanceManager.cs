﻿using DORv3.Models.FilterFields.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DORv3.BLL.FilterObjects;

namespace DORv3.Models.FilterFields
{
    public class MTD_FinanceManager : MTDFilterField
    {
        public MTD_FinanceManager(string fieldName, WhereFilterType whereFilter) : base(fieldName, whereFilter) { }

        public override MTDFilterObj GetFilterObject(object value)
        {
            return new Filter_MTD_FinanceManager(value);
        }
    }
}