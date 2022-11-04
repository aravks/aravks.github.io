using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using TimesheetManagement.Models;

namespace TimesheetManagement.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View("Index");
        }
        public ActionResult ChangePasswordIndex()
        {
            return View("ChangePassword");
        }
        public ActionResult ChangePassword(LoginModel obj)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand com = new SqlCommand();
            SqlDataReader dr;
            con.ConnectionString = @"Data Source=DESKTOP-9J9EK05\ARAVIND;Initial Catalog=TimesheetManagement;Integrated Security=True";
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from tblEmployee1 where emp_email='" + obj.CPEmail + "' and emp_password='" + obj.CurrentPassword + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                LoginModel model = new LoginModel();
                string Password = obj.CPPassword;
                string Email = obj.CPEmail;
                int status = model.UpdatePassword(Password, Email);
                ViewBag.message = "Password Changed!";
                return View("ChangePassword");
            }
            else
            {
                ViewBag.message = "Email and Password doesn't match!";
                return View("ChangePassword");
            }
        }
        public ActionResult Logout()
        {
            return RedirectToAction("Login","Login");
        }
    }
}