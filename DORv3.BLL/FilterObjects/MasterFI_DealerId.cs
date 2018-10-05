using DORv3.BLL.FilterObjects.Base;
using QueryDesigner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DORv3.BLL.FilterObjects
{
    public class MasterFI_DealerId : FilterObject
    {
        public MasterFI_DealerId(WhereFilterType whereType, object value)
        {
            this.Field = "Dealerid";
            this.FilterType = whereType;
            this.Value = value;
        }
    }
}