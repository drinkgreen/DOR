﻿using DORv3.BLL.FilterObjects;
using DORv3.BLL.FilterObjects.Base;
using DORv3.Models.FilterFields.Base;

namespace DORv3.Models.FilterFields
{
    public class MTD_DealStatus : MTDFilterField
    {
        public MTD_DealStatus(string fieldName, WhereFilterType whereFilter) : base(fieldName, whereFilter) { }

        public override MTDFilterObj GetFilterObject(object value)
        {
            return new Filter_MTD_DealStatus(value);
        }
    }
}