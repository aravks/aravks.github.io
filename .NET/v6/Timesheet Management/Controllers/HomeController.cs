using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Timesheet_Management.Models;

namespace Timesheet_Management.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new UserModel
            {
                SelectedTeaIds = new[] { 2 },
                TeaList = GetAllTeaTypes()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(UserModel model)
        {
            model.TeaList = GetAllTeaTypes();
            if (model.SelectedTeaIds != null)
            {
                List<SelectListItem> selectedItems = model.TeaList.Where(p => model.SelectedTeaIds.Contains(int.Parse(p.Value))).ToList();
                foreach (var Tea in selectedItems)
                {
                    Tea.Selected = true;
                    ViewBag.Message += Tea.Text + " | ";
                }
            }
            return View(model);
        }

        public List<SelectListItem> GetAllTeaTypes()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "General Tea", Value = "1" });
            items.Add(new SelectListItem { Text = "Coffee", Value = "2" });
            items.Add(new SelectListItem { Text = "Green Tea", Value = "3" });
            items.Add(new SelectListItem { Text = "Black Tea", Value = "4" });
            return items;
        }


        //public ActionResult Index1()
        //{
        //    City dbContext = new City();
        //    return View(dbContext.Cities.ToList());
        //}
        //[HttpPost]
        //public string Index1(IEnumerable<City> cities)
        //{
        //    if (cities.Count(x => x.IsSelected) == 0)
        //    {
        //        return "You have not selected any City";
        //    }
        //    else
        //    {
        //        StringBuilder sb = new StringBuilder();
        //        sb.Append("You selected - ");
        //        foreach (City city in cities)
        //        {
        //            if (city.IsSelected)
        //            {
        //                sb.Append(city.City_Name + ", ");
        //            }
        //        }
        //        sb.Remove(sb.ToString().LastIndexOf(","), 1);
        //        return sb.ToString();
        //    }
        //}
    }
}