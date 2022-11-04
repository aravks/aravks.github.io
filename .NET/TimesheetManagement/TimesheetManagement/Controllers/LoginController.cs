using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Helpers;
using System.Web.Mvc;
using TimesheetManagement.Models;
using System.Net;
using System.Net.Mail;

namespace TimesheetManagement.Controllers
{
    public class LoginController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult ForgetPassword()
        {
            return View();
        }
        public ActionResult Success(LoginModel obj)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand com = new SqlCommand();
            SqlDataReader dr;
            con.ConnectionString = @"Data Source=DESKTOP-9J9EK05\ARAVIND;Initial Catalog=TimesheetManagement;Integrated Security=True";
            con.Open();
            com.Connection = con;
            com.CommandText = "select role_id from tblEmployee1 where emp_email='" + obj.UserName + "' and emp_password='" + obj.Password + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                int role = dr.GetInt32(0);
                SqlConnection con1 = new SqlConnection();
                SqlCommand com1 = new SqlCommand();
                SqlDataReader cr;
                DataSet ds = new DataSet();
                con1.ConnectionString = @"Data Source=DESKTOP-9J9EK05\ARAVIND;Initial Catalog=TimesheetManagement;Integrated Security=True";
                con1.Open();
                com1.Connection = con1;
                com1.CommandText = "select Form_id from RoleFormAccess where Role_id='" + role + "'";
                cr = com1.ExecuteReader();
                cr.Read();
                string roles = cr.GetString(0);
                List<string> result = roles.Split(',').ToList<string>();
                Session["roleid"] = result;
                return RedirectToAction("Index", "Dashboard/Index");

            }
            else
            {
                ViewBag.message = "Invalid Email or Password!";
                return View("Login");
            }
        }
        public ActionResult PasswordVerification(LoginModel obj)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand com = new SqlCommand();
            SqlDataReader dr;
            con.ConnectionString = @"Data Source=DESKTOP-9J9EK05\ARAVIND;Initial Catalog=TimesheetManagement;Integrated Security=True";
            con.Open();
            com.Connection = con;
            com.CommandText = "select emp_password from tblEmployee1 where emp_email='" + obj.To + "'";
            dr = com.ExecuteReader();
            var x = dr;
            if (dr.Read())
            {
                string numbers = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
                Random objrandom = new Random();
                string passwordString = "";
                string strrandom = string.Empty;
                for (int i = 0; i < 8; i++)
                {
                    int temp = objrandom.Next(0, numbers.Length);
                    passwordString = numbers.ToCharArray()[temp].ToString();
                    strrandom += passwordString;
                }
                string recipient = obj.To;
                string subject = obj.Subject;
                string body = "Your Password is "+strrandom;

                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.SmtpPort = 587;
                WebMail.SmtpUseDefaultCredentials = true;
                WebMail.EnableSsl = true;
                WebMail.UserName = "timesheetmanagement12@gmail.com";
                WebMail.Password = "timesheet123";

                LoginModel model = new LoginModel();
                string Password = strrandom;
                string Email = recipient;
                int status = model.UpdatePassword(Password,Email);

                WebMail.Send(to: recipient, subject: subject, body: body, isBodyHtml: true);

                ViewBag.message = "Email Sent!";
                return View("ForgetPassword");
            }
            else
            {
                ViewBag.message = "Invalid Email!";
                return View("ForgetPassword");
            }
        }
        public ActionResult Index()
        {
            return View("Index");
        }
        
        public ActionResult Logout()
        {
            return View("Login");
        }
    }
}