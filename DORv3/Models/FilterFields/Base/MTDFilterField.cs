using DORv3.BLL.FilterObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DORv3.Models.FilterFields.Base
{
    public abstract class MTDFilterField : FilterField
    {
        public MTDFilterField(string fieldName, WhereFilterType whereFilter) : base(fieldName, whereFilter) { }

        public abstract MTDFilterObj GetFilterObject(object value);
    }
}