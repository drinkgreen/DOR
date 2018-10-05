using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using DORv3.BLL.BusinessObjects;
using DORv3.BLL.FilterObjects.Base;
//using DORv3.BLL.FilterObjects;

namespace DORv3.Models.FilterFields.Base
{
    //
    // Summary:
    //     Type of elements comparison.
    public enum WhereFilterType
    {
        //
        // Summary:
        //     The field is not a filtered.
        None = 0,
        //
        // Summary:
        //     The field is equal to the value.
        Equal = 1,
        //
        // Summary:
        //     The field is not equal to the value.
        NotEqual = 2,
        //
        // Summary:
        //     The field is less than the value.
        LessThan = 3,
        //
        // Summary:
        //     The field is greater than the value.
        GreaterThan = 4,
        //
        // Summary:
        //     Field is less than or equal to value.
        LessThanOrEqual = 5,
        //
        // Summary:
        //     The field is greater than or equal to the value.
        GreaterThanOrEqual = 6,
        //
        // Summary:
        //     The field is contains the value.
        Contains = 7,
        //
        // Summary:
        //     The field is not contains the value.
        NotContains = 8,
        //
        // Summary:
        //     The field is start with value.
        StartsWith = 9,
        //
        // Summary:
        //     The field is not start with value.
        NotStartsWith = 10,
        //
        // Summary:
        //     Collection contains data.
        Any = 11,
        //
        // Summary:
        //     Collection not contains data.
        NotAny = 12
    }

    public abstract class FilterField
    {
        public string FieldName { get; set; }

        public WhereFilterType WhereFilterType { get; set; }

        public FilterField( string fieldName, WhereFilterType whereFilter)
        {
            this.FieldName = fieldName;
            this.WhereFilterType = whereFilter;
        }

        //public abstract FilterObj GetFilterObject(object value);

        //public abstract FilterObj GetFilterObject

    }
}