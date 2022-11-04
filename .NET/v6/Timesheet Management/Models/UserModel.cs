using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Timesheet_Management.Models
{
    public class UserModel
    {
        public int[] SelectedTeaIds { get; set; }
        public IEnumerable<SelectListItem> TeaList { get; set; }


        public bool IsSelected { get; set; }
        public int City_ID { get; set; }
        public string City_Name { get; set; }
        public IEnumerable<string> Cities { get; set; }
    }
}