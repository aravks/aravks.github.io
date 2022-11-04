using TimesheetManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace TimesheetManagement.Controllers
{
    public class TimesheetManagementController : Controller
    {
        // GET: TimesheetManagement
        public object InsertSheet { get; private set; }
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        public ActionResult Index()
        {
            TimesheetManagementModel model = new TimesheetManagementModel();
            int empid = Convert.ToInt32(Session["empid"]);
            DataTable dt = model.GetAll(empid);
            return View("UTable", dt);
        }

        public ActionResult SheetInsert(int timesheetID = 0, int projid = 1)
        {
            TimesheetManagementModel model = new TimesheetManagementModel();
            DataTable dt = new DataTable();
            ViewBag.projectList = GetAllProject(projid);
            if (timesheetID != 0)
            {
                ViewBag.message = "Edit";
                dt = model.GetSheetByID(timesheetID);
                model.vstsref = dt.Rows[0]["vstsref"].ToString();
                model.fortime = dt.Rows[0]["frm_time"].ToString();
                model.totaltime = dt.Rows[0]["tot_time"].ToString();
                model.taskdes = dt.Rows[0]["task_des"].ToString();
                model.date = Convert.ToDateTime(dt.Rows[0]["project_date"]);
                model.totime = dt.Rows[0]["to_time"].ToString();
                model.remarks = dt.Rows[0]["ts_remarks"].ToString();
                model.timesheetID = Convert.ToInt32(dt.Rows[0]["timesheet_id"]);
                ViewBag.projectList = GetAllProject(projid);
            }
            return View("Timesheet", model);
        }
        void connectionString()
        {
            con.ConnectionString = @"Data Source=DESKTOP-9J9EK05\ARAVIND;Initial Catalog=TimesheetManagement;Integrated Security=True";
        }
        public ActionResult InsertRecord(TimesheetManagementModel ob, string action)
        {
            if (action == "Submit")
            {
                if (ob.timesheetID.Equals(0)) ///ob.hdnID.Equals(0) ob.hdnID == 0
                {
                    bool result;
                    if (ob.date >= Convert.ToDateTime("1/1/1753 00:00:00") && ob.date <= Convert.ToDateTime("31/12/9999 23:59:59"))
                    {
                        result = false;
                    }
                    else
                    {
                        result = true;
                    }
                    if (result)
                    {
                        ViewBag.date = "Enter a valid DOB";
                        con.Close();
                        DataTable dt = new DataTable();
                        dt = ob.GetSheetByID(ob.timesheetID);
                        ViewBag.projectList = GetAllProject(ob.projid);
                        return View("Timesheet", ob);
                    }
                    TimesheetManagementModel model = new TimesheetManagementModel();
                    int empid = Convert.ToInt32(Session["empid"]);

                    string vsts = ob.vstsref;
                    int emmpid = empid;
                    string task = ob.taskdes;
                    int project = ob.projid;
                    DateTime dat = ob.date;
                    string ftime = ob.fortime;
                    string ttime = ob.totime;
                    string total = ob.totaltime;
                    string rem = ob.remarks;
                   int status = model.InsertSheet(vsts, task, project, dat, ftime, ttime, total, rem, emmpid);

                    return RedirectToAction("Index");
                }
                else
                {
                    TimesheetManagementModel model = new TimesheetManagementModel();
                    int empid = Convert.ToInt32(Session["empid"]);
                    string vsts = ob.vstsref;
                    int emmpid = empid;
                    string task = ob.taskdes;
                    int project = ob.projid;
                    DateTime dat = ob.date;
                    string ftime = ob.fortime;
                    string ttime = ob.totime;
                    string total = ob.totaltime;
                    string rem = ob.remarks;
                    int id = ob.timesheetID;
                    int status = model.UpdateSheet(id, vsts, task, project, dat, ftime, ttime, total, rem, emmpid);

                    return RedirectToAction("Index");

                }
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int timesheetID)
        {
            TimesheetManagementModel model = new TimesheetManagementModel();
            model.DeleteSheet(timesheetID);
            return RedirectToAction("Index");
        }



        
        private SelectList GetAllProject(int projid)
        {
                string constr = ConfigurationManager.ConnectionStrings["sConnectionString"].ToString();
                SqlConnection _con = new SqlConnection(constr);
                SqlDataAdapter _da = new SqlDataAdapter("SELECT [ProjectId],[ProjectName]  FROM [TimesheetManagement].[dbo].[tblProject]", constr);
                DataTable _dt = new DataTable();
                _da.Fill(_dt);
               // return ToSelectList(_dt, "pro_id", "pro_name");

                List<SelectListItem> list = new List<SelectListItem>();

                foreach (DataRow row in _dt.Rows)
                {
                bool bo = (projid.ToString() == row["ProjectId"].ToString());
                list.Add(new SelectListItem()
                {
                    Text = row["ProjectName"].ToString(),
                    Value = row["ProjectId"].ToString(),
                    Selected = bo //if statement pro_id==model.Row
                }) ;
                }
                return new SelectList(list, "Value", "Text", "Selected");

        }

    }
}