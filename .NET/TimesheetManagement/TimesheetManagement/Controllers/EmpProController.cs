using EmpPro.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace EmpPro.Controllers
{
    public class EmpProController : Controller
    {
        // GET: EmpPro
       public ActionResult Index()
        {
            EmpproModel model = new EmpproModel();
            DataTable dt = model.GetAllEmppromap();
           // ViewBag.projectList = GetAllProject(projname);
            //ViewBag.employeeList = GetAllEmployee(empname);
            return View("Table", dt);
        }

        public ActionResult SheetInsert(int empproID = 0, int projname=1, int empname=1 )
        {
            DataTable dt = new DataTable();
           ViewBag.projectList = GetAllProject(projname);
           ViewBag.employeeList = GetAllEmployee(empname);
            if (empproID != 0)
            {
                ViewBag.message = "Edit";
                EmpproModel model = new EmpproModel();
                dt = model.GetEmpproByID(empproID);
                 ViewBag.projectList = GetAllProject(projname);
                 ViewBag.employeeList = GetAllEmployee(empname);
            }
            return View("EmpPro", dt);
        }

        public ActionResult InsertRecord(EmpproModel ob, string action)
        {
            if (action == "Submit")
            {
                if (ob.empproID.Equals(0)) ///ob.hdnID.Equals(0) ob.hdnID == 0
                {
                    EmpproModel model = new EmpproModel();
                    int employee = ob.empname;
                    int project = ob.projname;

                    int status = model.Insert(employee,project);
                    return RedirectToAction("Index");
                }
                else
                {
                    EmpproModel model = new EmpproModel();
                    int employee = ob.empname;
                    int project = ob.projname;
                    int id = ob.empproID;
                    int status = model.Update(id, employee, project);
                    return RedirectToAction("Index");

                }
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int empproID)
        {
            EmpproModel model = new EmpproModel();
            model.DeleteSheet(empproID);
            return RedirectToAction("Index");
        }



        private SelectList GetAllProject(int projname)
        {
            string constr = ConfigurationManager.ConnectionStrings["sConnectionString"].ToString();
            SqlConnection _con = new SqlConnection(constr);
            SqlDataAdapter _da = new SqlDataAdapter("SELECT [ProjectId],[ProjectName] FROM [TimesheetManagement].[dbo].[tblProject]", constr);
            DataTable _dt = new DataTable();
            _da.Fill(_dt);
            // return ToSelectList(_dt, "pro_id", "pro_name");

            List<SelectListItem> list = new List<SelectListItem>();

            foreach (DataRow row in _dt.Rows)
            {
                bool bow = (projname.ToString() == row["ProjectId"].ToString());
                list.Add(new SelectListItem()
                {
                    Text = row["ProjectName"].ToString(),
                    Value = row["ProjectId"].ToString(),
                     Selected = bow
                });
            }
            return new SelectList(list, "Value", "Text" , "Selected");

        }


        private SelectList GetAllEmployee(int empname)
        {
            string constr = ConfigurationManager.ConnectionStrings["sConnectionString"].ToString();
            SqlConnection _con = new SqlConnection(constr);
            SqlDataAdapter _da = new SqlDataAdapter("SELECT [emp_id],[emp_name] FROM [TimesheetManagement].[dbo].[tblEmployee1]", constr);
            DataTable _dt = new DataTable();
            _da.Fill(_dt);

            List<SelectListItem> list = new List<SelectListItem>();

            foreach (DataRow row in _dt.Rows)
            {
                bool b = (empname.ToString() == row["emp_id"].ToString());
                list.Add(new SelectListItem()
                {
                    Text = row["emp_name"].ToString(),
                    Value = row["emp_id"].ToString(),
                    Selected = b
                });
            }
            return new SelectList(list, "Value", "Text" , "Selected");

        }

       


      
    }

}



