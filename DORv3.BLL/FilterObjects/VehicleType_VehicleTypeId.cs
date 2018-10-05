using DORv3.BLL.FilterObjects.Base;
using QueryDesigner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DORv3.BLL.FilterObjects
{
    public class VehicleType_VehicleTypeId : FilterObject
    {
        public VehicleType_VehicleTypeId(WhereFilterType whereType, object value)
        {
            this.Field = "VehicleTypeId";
            this.FilterType = whereType;
            this.Value = value;
        }
    }
}