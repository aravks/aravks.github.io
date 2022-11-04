using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using Timesheet_Management.Models;
using System.Configuration;

namespace Timesheet_Management.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Index()
        {
            EMPModel model = new EMPModel();
            DataTable dt = model.GetAll();
            return View("Index", dt);
        }

        public ActionResult AddEditGet(int EmpID = 0, int RID = 0, int Egend = 0)
        {
            EMPModel model = new EMPModel();
            DataTable dt = new DataTable();
            ViewBag.roleList = GetAllRole(RID);
            ViewBag.genderList = GetAllGender(Egend);
            if (EmpID != 0)
            {
                ViewBag.edit = "Edit";
                dt = model.GetEmployeeByID(EmpID);
                model.Ename = dt.Rows[0]["emp_name"].ToString();
                model.Email = dt.Rows[0]["emp_email"].ToString();
                model.Edob = Convert.ToDateTime(dt.Rows[0]["emp_dob"]);
                model.Ephone = dt.Rows[0]["emp_phone"].ToString();
                model.Eaddr = dt.Rows[0]["emp_address"].ToString();
                model.Epass = dt.Rows[0]["emp_password"].ToString();
                model.EID = Convert.ToInt32(dt.Rows[0]["emp_id"]);
                ViewBag.roleList = GetAllRole(RID);
                ViewBag.genderList = GetAllGender(Egend);
            }
            return View("Create", model);
        }

        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        void connectionString()
        {
            con.ConnectionString = @"Data Source=DESKTOP-9J9EK05\ARAVIND;Initial Catalog=TimesheetManagement;Integrated Security=True";
        }

        /// <summary>    
        /// Action method, called when the user hit "Submit" button    
        /// </summary>    
        /// <param name="frm">Form Collection  Object</param>    
        /// <param name="action">Used to differentiate between "submit" and "cancel"</param>    
        /// <returns></returns>    
        public ActionResult AddEditPost(EMPModel ob, string action)
        {
            if (action == "Submit")
            {
                if (ob.EID == 0)
                {
                    connectionString();
                    con.Open();
                    com.Connection = con;
                    com.CommandText = "Select * from tblEmployee1 where emp_email ='" + ob.Email + "' ";
                    dr = com.ExecuteReader();
                    bool result = dr.Read();
                    bool result1 = (ob.RID == 0);
                    bool result2 = (ob.Egend == 0);
                    bool result3;
                    if (ob.Edob >= Convert.ToDateTime("1/1/1753 00:00:00") && ob.Edob <= Convert.ToDateTime("12/31/9999 23:59:59"))
                    {
                        result3 = false;
                    }
                    else
                    {
                        result3 = true;
                    }

                    if (result || result1 || result2 || result3)
                    {
                        if (result) { ViewBag.email = "Email already exist"; }
                        if (result1) { ViewBag.role = "Role is required"; }
                        if (result2) { ViewBag.gender = "Gender is required"; }
                        if (result3) { ViewBag.dob = "Enter a valid DOB"; }
                        con.Close();
                        DataTable dt = new DataTable();
                        dt = ob.GetEmployeeByID(ob.EID);
                        ViewBag.roleList = GetAllRole(ob.RID);
                        ViewBag.genderList = GetAllGender(ob.Egend);
                        return View("Create", ob);
                    }

                    EMPModel model = new EMPModel();
                    int eid = ob.EID;
                    string name = ob.Ename;
                    DateTime dob = ob.Edob;
                    int rid = ob.RID;
                    int gender = ob.Egend;
                    string email = ob.Email;
                    string phone = ob.Ephone;
                    string address = ob.Eaddr;
                    string password = ob.Epass;
                    int status = model.InsertEmployee(name, dob, rid, gender, email, phone, address, password);
                    return RedirectToAction("Index");
                }
                else
                {
                    connectionString();
                    con.Open();
                    com.Connection = con;
                    com.CommandText = "Select * from tblEmployee1 where emp_email ='" + ob.Email + "' except Select  * from tblEmployee1 where emp_id ='" + ob.EID + "' ";
                    dr = com.ExecuteReader();
                    bool result = dr.Read();
                    bool result1 = (ob.RID == 0);
                    bool result2 = (ob.Egend == 0);
                    bool result3;
                    if (ob.Edob >= Convert.ToDateTime("1/1/1753 00:00:00") && ob.Edob <= Convert.ToDateTime("12/31/9999 23:59:59"))
                    {
                        result3 = false;
                    }
                    else
                    {
                        result3 = true;
                    }

                    if (result || result1 || result2 || result3)
                    {
                        if (result) { ViewBag.email = "Email already exist"; }
                        if (result1) { ViewBag.role = "Role is required"; }
                        if (result2) { ViewBag.gender = "Gender is required"; }
                        if (result3) { ViewBag.dob = "Enter a valid DOB"; }
                        con.Close();
                        DataTable dt = new DataTable();
                        dt = ob.GetEmployeeByID(ob.EID);
                        ViewBag.roleList = GetAllRole(ob.RID);
                        ViewBag.genderList = GetAllGender(ob.Egend);
                        return View("Create", ob);
                    }
                    EMPModel model = new EMPModel();
                    string name = ob.Ename;
                    DateTime dob = ob.Edob;
                    int rid = ob.RID;
                    int gender = ob.Egend;
                    string email = ob.Email;
                    string phone = ob.Ephone;
                    string address = ob.Eaddr;
                    string password = ob.Epass;
                    int eid = ob.EID;
                    int status = model.UpdateEmployee(name, dob, rid, gender, email, phone, address, password, eid);
                    return RedirectToAction("Index");
                }

            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        //public ActionResult EmployeeUpdateRecord(EMPModel ob, string action)
        //{
        //    if (action == "Submit")
        //    {

        //        EMPModel model = new EMPModel();
        //        string name = ob.Ename;
        //        DateTime dob = ob.Edob;
        //        int rid = ob.RID;
        //        int gender = ob.Egend;
        //        string email = ob.Email;
        //        string phone = ob.Ephone;
        //        string address = ob.Eaddr;
        //        string password = ob.Epass;
        //        int eid = ob.EID;
        //        int status = model.UpdateEmployee(name, dob, rid, gender, email, phone, address, password, eid);
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index");
        //    }
        //}

        public ActionResult EmployeeDelete(int EmpID)
        {
            EMPModel model = new EMPModel();
            model.DeleteEmployee(EmpID);
            return RedirectToAction("Index");
        }

        private SelectList GetAllGender(int intEgend)
        {
            string constr = ConfigurationManager.ConnectionStrings["sConnectionString"].ToString();
            SqlConnection _con = new SqlConnection(constr);
            SqlDataAdapter _da = new SqlDataAdapter("SELECT [gender_id],[gender_name] FROM [TimesheetManagement].[dbo].[tblGender]", constr);
            DataTable _dt = new DataTable();
            _da.Fill(_dt);
            // return ToSelectList(_dt, "pro_id", "pro_name");

            List<SelectListItem> list = new List<SelectListItem>();

            foreach (DataRow row in _dt.Rows)
            {
                bool result = (intEgend.ToString() == row["gender_id"].ToString());
                list.Add(new SelectListItem()
                {
                    Text = row["gender_name"].ToString(),
                    Value = row["gender_id"].ToString(),
                    Selected = result
                });
            }
            return new SelectList(list, "Value", "Text", "Selected");
        }

        private SelectList GetAllRole(int RID)
        {
            string constr = ConfigurationManager.ConnectionStrings["sConnectionString"].ToString();
            SqlConnection _con = new SqlConnection(constr);
            SqlDataAdapter _da = new SqlDataAdapter("SELECT [Role_id],[Role_name] FROM [TimesheetManagement].[dbo].[tblRole]", constr);
            DataTable _dt = new DataTable();
            _da.Fill(_dt);
            // return ToSelectList(_dt, "pro_id", "pro_name");

            List<SelectListItem> list = new List<SelectListItem>();

            foreach (DataRow row in _dt.Rows)
            {
                bool result = (RID.ToString() == row["Role_id"].ToString());
                list.Add(new SelectListItem()
                {
                    Text = row["Role_name"].ToString(),
                    Value = row["Role_id"].ToString(),
                    Selected = result
                });
            }
            return new SelectList(list, "Value", "Text", "Selected");

        }
    }
}