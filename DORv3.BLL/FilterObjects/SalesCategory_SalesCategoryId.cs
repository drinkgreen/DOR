using DORv3.BLL.FilterObjects.Base;
using QueryDesigner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DORv3.BLL.FilterObjects
{
    public class SalesCategory_SalesCategoryId : FilterObject
    {
        public SalesCategory_SalesCategoryId(WhereFilterType whereType, object value)
        {
            this.Field = "SalesCategoryId";
            this.FilterType = whereType;
            this.Value = value;
        }
    }
}