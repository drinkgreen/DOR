using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DORv3.Models.FilterFields.Base
{
    public class SearchObject
    {
        public int ID { get; set; }
        public string Value { get; set; }

        public SearchObject(int id, string value)
        {
            this.ID = id;
            this.Value = value;
        }
    }
}