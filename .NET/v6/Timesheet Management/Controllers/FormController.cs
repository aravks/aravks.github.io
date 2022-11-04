using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using TimesheetManagement.Models;
using System.Configuration;


namespace TimesheetManagement.Controllers
{
    public class FormController : Controller
    {
        public ActionResult Index()
        {
            FormModel model = new FormModel();
            DataTable dt = model.GetAll();
            return View("index", dt);
        }


        public ActionResult Insert(int RoleFormAccessId = 0,int ROID = 1 ,string Eform = "1")
        {
            FormModel model = new FormModel();
            DataTable dt = new DataTable();
            ViewBag.roleList = GetAllRole(ROID);
            ViewBag.FormList = GetAllForms(Eform);
            if (RoleFormAccessId != 0)
            {
                ViewBag.message = "Edit";
                dt = model.GetFormByID(RoleFormAccessId);
                ViewBag.roleList = GetAllRole(ROID);
                ViewBag.FormList = GetAllForms(Eform);
                return View("Add", dt);

            }
           
            return View("Add");
        }

        void connectionString()
        {
            con.ConnectionString = @"Data Source=DESKTOP-9J9EK05\ARAVIND;Initial Catalog=TimesheetManagement;Integrated Security=True";
        }

        public ActionResult InsertRecord(FormModel ob, string action)
        {
            if (action == "Submit")
            {
                if (ob.hndID.Equals(0))
                {
                    connectionString();
                    con.Open();
                    com.Connection = con;
                    com.CommandText = "Select * from RoleFormAccess where Role_id ='" + ob.ROID + "' or Form_id ='" + ob.Eform + "'";
                    dr = com.ExecuteReader();
                    bool result = dr.Read();
                    if(result)
                    {
                        ViewBag.message = "Role/Access already exist";
                        con.Close();
                        DataTable dt = new DataTable();
                        dt = ob.GetFormByID(ob.RoleFormAccessId);
                        ViewBag.roleList = GetAllRole(ob.ROID);
                        ViewBag.FormList = GetAllForms(ob.Eform);
                        return View("Add", dt);
                    }

                    FormModel model = new FormModel();
                        int role = ob.ROID;
                        string form = ob.Eform;
                        int status = model.InsertForm(role, form);
                        return RedirectToAction("Index");
                    
                }
                else
                {
                    connectionString();
                    con.Open();
                    com.Connection = con;
                    com.CommandText = "Select * from RoleFormAccess where Role_id ='" + ob.ROID + "' or Form_id ='" + ob.Eform + "' except Select  * from RoleFormAccess where RoleFormAccessId  ='" + ob.hndID + "'";
                    dr = com.ExecuteReader();
                    bool result = dr.Read();
                    if (result)
                    {
                        ViewBag.message = "Role/Access already exist";
                        con.Close();
                        DataTable dt = new DataTable();
                        dt = ob.GetFormByID(ob.RoleFormAccessId);
                        ViewBag.roleList = GetAllRole(ob.ROID);
                        ViewBag.FormList = GetAllForms(ob.Eform);
                        return View("Add", dt);
                    }
                    FormModel model = new FormModel();
                    int role = ob.ROID;
                    string form = ob.Eform;
                    int id = ob.hndID;
                    int status = model.UpdateForm(id, role, form);
                    return RedirectToAction("Index");

                }
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int RoleFormAccessId)
        {
            FormModel model = new FormModel();
            model.DeleteForm(RoleFormAccessId);
            return RedirectToAction("Index");
        }



        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        
        private SelectList GetAllRole(int ROID)
        {
            string constr = ConfigurationManager.ConnectionStrings["sConnectionString"].ToString();
            SqlConnection _con = new SqlConnection(constr);
            SqlDataAdapter _da = new SqlDataAdapter("SELECT [Role_id],[Role_name] FROM [TimesheetManagement].[dbo].[tblRole]", constr);
            DataTable _dt = new DataTable();
            _da.Fill(_dt);
           
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (DataRow row in _dt.Rows)
            {
                bool result = (ROID.ToString() == row["Role_id"].ToString());
                list.Add(new SelectListItem()
                {
                    Text = row["Role_name"].ToString(),
                    Value = row["Role_id"].ToString(),
                    Selected = result
                });
            }
           
            //foreach (DataRow row in _dt.Rows)
            //{
            //    bool result = (intROID.ToString() == row["role_id"].ToString());
            //    list.Add(new SelectListItem()
            //    {
            //        Text = row["role_name"].ToString(),
            //        Value = row["role_id"].ToString(),
            //        Selected = result
            //    });
            //}
            return new SelectList(list, "Value", "Text", "Selected");

        }
        private SelectList GetAllForms(string strEform)
        {
            string constr = ConfigurationManager.ConnectionStrings["sConnectionString"].ToString();
            SqlConnection _con = new SqlConnection(constr);
            SqlDataAdapter _da = new SqlDataAdapter("SELECT [Form_id],[Form_name] FROM [TimesheetManagement].[dbo].[FormDetail]", constr);
            DataTable _dt = new DataTable();
            _da.Fill(_dt);
           
            List<SelectListItem> list = new List<SelectListItem>();
                foreach (DataRow row in _dt.Rows)
                {
                    //bool result = (item.ToString() == row["Form_id"].ToString());
                    list.Add(new SelectListItem()
                    {
                        Text = row["Form_name"].ToString(),
                        Value = row["Form_id"].ToString(),
                        //Selected = result
                    });
                }
            

            return new SelectList(list, "Value", "Text");
        }


    }
}