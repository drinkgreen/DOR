using DORv3.BLL.FilterObjects.Base;
using QueryDesigner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DORv3.BLL.FilterObjects
{
    public class Vehicle_VehicleId : FilterObject
    {
        public Vehicle_VehicleId(WhereFilterType whereType, object value)
        {
            this.Field = "VehicleId";
            this.FilterType = whereType;
            this.Value = value;
        }
    }
}