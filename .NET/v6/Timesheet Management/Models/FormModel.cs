using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Mvc;

namespace TimesheetManagement.Models
{
    public class FormModel
    {
       
        
        
       public IEnumerable<SelectListItem> Forms { get; set; }
       
        public int hndID { get; set; }
        
        public int ROID { get; set; }
        public string Eform { get; set; }
        public int RoleFormAccessId { get; set; }

        public SqlConnection con;
        public void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);

        }
        public DataTable GetAllFormDetail()
        {
            DataTable dt = new DataTable();
            string strConString = @"Data Source=DESKTOP-9J9EK05\ARAVIND;Initial Catalog=TimesheetManagement;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand com = new SqlCommand("GetFormDetail", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable GetFormByID(int intRoleFormAccessId)
        {
            DataTable dt = new DataTable();

            string strConString = @"Data Source=DESKTOP-9J9EK05\ARAVIND;Initial Catalog=TimesheetManagement;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand com = new SqlCommand("GetFormById", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@RoleFormAccessId", intRoleFormAccessId);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(dt);
            }
            return dt;
        }
        public int UpdateForm(int intRoleFormAccessId, int intRoleid, string strFormid)
        {
            string strConString = @"Data Source=DESKTOP-9J9EK05\ARAVIND;Initial Catalog=TimesheetManagement;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand com = new SqlCommand("UpdateFormDetails", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Role_id", intRoleid);
                com.Parameters.AddWithValue("@Form_id", strFormid);
                com.Parameters.AddWithValue("@RoleFormAccessId", intRoleFormAccessId);
                return com.ExecuteNonQuery();
            }
        }
        public int InsertForm(int intRoleid, string strFormid)
        {
            string strConString = @"Data Source=DESKTOP-9J9EK05\ARAVIND;Initial Catalog=TimesheetManagement;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand com = new SqlCommand("AddNewFormDetails", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Role_id", intRoleid);
                com.Parameters.AddWithValue("@Form_id", strFormid);
                return com.ExecuteNonQuery();
            }
        }
        public int DeleteForm(int intRoleFormAccessId)
        {
            string strConString = @"Data Source=DESKTOP-9J9EK05\ARAVIND;Initial Catalog=TimesheetManagement;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand com = new SqlCommand("DeleteFormById", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@RoleFormAccessId", intRoleFormAccessId);
                return com.ExecuteNonQuery();
            }
        }
        public DataTable GetAll()
        {
            DataTable dt = new DataTable();
            string strConString = @"Data Source=DESKTOP-9J9EK05\ARAVIND;Initial Catalog=TimesheetManagement;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SelectAllRoleFormAccess", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(dt);
            }
            return dt;
        }
    }
}