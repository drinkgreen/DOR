using DORv3.BLL.FilterObjects.Base;
using QueryDesigner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DORv3.BLL.FilterObjects
{
    public class MasterFI_VehicleType_VehicleTypeId : FilterObject
    {
        public MasterFI_VehicleType_VehicleTypeId(WhereFilterType whereType, object value)
        {
            this.Field = "vehicletype.VehicleTypeId";
            this.FilterType = whereType;
            this.Value = value;
        }
    }
}