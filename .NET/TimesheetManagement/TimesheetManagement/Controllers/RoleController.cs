using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using TimesheetManagement.Models;
namespace TimesheetManagement.Controllers
{
    public interface Role
    {
        DataTable implement();
    }
    public class RoleController : Controller, Role
    {
        public DataTable implement()
        {
            RoleModel model = new RoleModel();
            DataTable dt = model.GetAllRoles();
            return dt;
        }
        void connectionString()
        {
            con.ConnectionString = @"Data Source=DESKTOP-9J9EK05\ARAVIND;Initial Catalog=TimesheetManagement;Integrated Security=True";
        }

        public ActionResult Index()
        {
            Role role = new RoleController();
            DataTable dt = role.implement();
            return View("index", dt);
        }
        
       
        public ActionResult Insert(int RoleID = 0)
        {
            if (RoleID != 0)
            {
                ViewBag.message = "Edit";
                RoleModel model = new RoleModel();
                DataTable dt = model.GetRoleByID(RoleID);
                return View("Add", dt);

            }
            return View("Add");
        }


        public ActionResult InsertRecord(RoleModel ob, string action)
        {
            if (action == "Submit")
            {
                if (ob.hdnID.Equals(0))
                {
                    connectionString();
                    con.Open();
                    com.Connection = con;
                    com.CommandText = "Select * from tblRole where Role_name ='" + ob.txtName + "'";
                    dr = com.ExecuteReader();
                    if (dr.Read())
                    {
                        ViewBag.message = "Name already exist";
                        con.Close();
                        return View("Add");
                    }
                   
                        RoleModel model = new RoleModel();
                        string name = ob.txtName;
                        string descript = ob.description;
                        int status = model.InsertRole(name, descript);
                        return RedirectToAction("Index");
             
                }
                else
                {

                    connectionString();
                    con.Open();
                    com.Connection = con;
                    com.CommandText = "Select * from tblRole where Role_name ='" + ob.txtName + "'except Select * from tblRole where Role_id ='" + ob.hdnID + "'";
                    dr = com.ExecuteReader();
                    if (dr.Read())
                    {
                        ViewBag.role = "Name already exist";
                        con.Close();
                        return View("Add");
                    }

                    RoleModel model = new RoleModel();
                        string name = ob.txtName;
                        string descript = ob.description;
                        int id = ob.hdnID;
                        int status = model.UpdateRole(id, name, descript);
                        return RedirectToAction("Index");
                    
                    
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        public ActionResult Delete(int RoleID)
        {
            RoleModel model = new RoleModel();
            model.DeleteRole(RoleID);
            return RedirectToAction("Index");
        }
        public ActionResult Logout()
        {
            return RedirectToAction("Login", "Login");
        }



    }
}