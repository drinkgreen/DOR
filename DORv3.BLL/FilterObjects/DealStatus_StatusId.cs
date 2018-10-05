using DORv3.BLL.FilterObjects.Base;
using QueryDesigner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DORv3.BLL.FilterObjects
{
    public class DealStatus_StatusId : FilterObject
    {
        public DealStatus_StatusId(WhereFilterType whereType, object value)
        {
            this.Field = "StatusId";
            this.FilterType = whereType;
            this.Value = value;
        }
    }
}