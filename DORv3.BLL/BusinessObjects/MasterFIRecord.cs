using DORv3.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DORv3.BLL.BusinessObjects
{
    public class MasterFIRecord
    {
        public string RecordType { get; set; }
        public MasterFI Record { get; set; }
    }
}