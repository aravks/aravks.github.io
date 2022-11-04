using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TimesheetManagement.Models
{
    public class RoleModel
    {

        public int hdnID { get; set; }
        public string txtName { get; set; }
        
        public string description { get; set; }
        public SqlConnection con;
        public void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);

        }
        public DataTable GetAllRoles()
        {
            DataTable dt = new DataTable();
            string strConString = @"Data Source=DESKTOP-9J9EK05\ARAVIND;Initial Catalog=TimesheetManagement;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand com = new SqlCommand("GetRoleDetail", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable GetRoleByID(int intRoleID)
        {
            DataTable dt = new DataTable();

            string strConString = @"Data Source=DESKTOP-9J9EK05\ARAVIND;Initial Catalog=TimesheetManagement;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand com = new SqlCommand("GetRoleById1", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Role_id", intRoleID);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(dt);
            }
            return dt;
        }
        public int UpdateRole(int intRoleID, string strRoleName, string strDescription)
        {
            string strConString = @"Data Source=DESKTOP-9J9EK05\ARAVIND;Initial Catalog=TimesheetManagement;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand com = new SqlCommand("UpdateRoleDetails1", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Role_name", strRoleName);                
                com.Parameters.AddWithValue("@Role_description", string.IsNullOrEmpty(strDescription) ? (object)DBNull.Value : strDescription);
                com.Parameters.AddWithValue("@Role_id", intRoleID);
                return com.ExecuteNonQuery();
            }
        }
        public int InsertRole(string strRoleName, string strDescription)
        {
            string strConString = @"Data Source=DESKTOP-9J9EK05\ARAVIND;Initial Catalog=TimesheetManagement;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand com = new SqlCommand("AddNewRoleDetails1", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Role_name", strRoleName);                
                com.Parameters.AddWithValue("@Role_description", string.IsNullOrEmpty(strDescription) ? (object)DBNull.Value : strDescription);
                return com.ExecuteNonQuery();
            }
        }
        public int DeleteRole(int intRoleID)
        {
            string strConString = @"Data Source=DESKTOP-9J9EK05\ARAVIND;Initial Catalog=TimesheetManagement;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand com = new SqlCommand("DeleteRoleById1", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Role_id", intRoleID);
                return com.ExecuteNonQuery();
            }
        }
    }
}