using DORv3.BLL.FilterObjects;
using DORv3.BLL.FilterObjects.Base;
using DORv3.Models.FilterFields.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DORv3.Models.FilterFields
{
    public class MTD_Dealerid : MTDFilterField
    {
        public MTD_Dealerid(string fieldName, WhereFilterType whereFilter) : base(fieldName, whereFilter) { }

        public override MTDFilterObj GetFilterObject(object value)
        {
            return new Filter_MTD_Dealerid(value);
        }
    }
}