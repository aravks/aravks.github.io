using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Timesheet_Management.Models
{
    public class EMPModel
    {
        public int EID { get; set; }
        public string Ename { get; set; }
        public DateTime Edob { get; set; }
        public int RID { get; set; }
        public int Egend { get; set; }
        public string Email { get; set; }
        public string Ephone { get; set; }
        public string Eaddr { get; set; }
        public string Epass { get; set; }
        public string EgendName { get; set; }
        public string Rname { get; set; }

        public SqlConnection con;
        public void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);

        }
        public DataTable GetAllEmployees()
        {
            DataTable dt = new DataTable();
            string strConString = @"Data Source=DESKTOP-9J9EK05\ARAVIND;Initial Catalog=TimesheetManagement;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand com = new SqlCommand("GetEmployees", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable GetAll()
        {
            DataTable dt = new DataTable();
            string strConString = @"Data Source=DESKTOP-9J9EK05\ARAVIND;Initial Catalog=TimesheetManagement;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SELECT tblEmployee1.emp_id, tblEmployee1.emp_name, tblEmployee1.emp_dob, tblRole.Role_id, tblRole.Role_name, " +
                    "tblGender.gender_id, tblGender.gender_name, tblEmployee1.emp_email, tblEmployee1.emp_phone, tblEmployee1.emp_address " +
                    "FROM ((tblEmployee1 " +
                    "INNER JOIN tblGender ON tblEmployee1.gender_id = tblGender.gender_id)" +
                    "INNER JOIN tblRole ON tblEmployee1.role_id = tblRole.Role_id); ", con);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable GetEmployeeByID(int intEID)
        {
            DataTable dt = new DataTable();

            string strConString = @"Data Source=DESKTOP-9J9EK05\ARAVIND;Initial Catalog=TimesheetManagement;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand com = new SqlCommand("GetEmployeesById", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@emp_id", intEID);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(dt);
            }
            return dt;
        }
        public int InsertEmployee(string strEname, DateTime dateEdob, int intRID, int intEgend, string strEmail, string strEphone, string strEaddr, string strEpass)
        {
            string strConString = @"Data Source=DESKTOP-9J9EK05\ARAVIND;Initial Catalog=TimesheetManagement;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand com = new SqlCommand("AddNewEmployeeDetails", con);
                com.CommandType = CommandType.StoredProcedure;

                if (string.IsNullOrEmpty(strEphone))
                {
                    com.Parameters.AddWithValue("@emp_phone", "");
                }
                else
                {
                    com.Parameters.AddWithValue("@emp_phone", strEphone);
                }

                if (string.IsNullOrEmpty(strEaddr))
                {
                    com.Parameters.AddWithValue("@emp_address", "");
                }
                else
                {
                    com.Parameters.AddWithValue("@emp_address", strEaddr);

                }


                com.Parameters.AddWithValue("@emp_dob", dateEdob);



                com.Parameters.AddWithValue("@emp_name", strEname);
                com.Parameters.AddWithValue("@role_id", intRID);
                com.Parameters.AddWithValue("@gender_id", intEgend);
                com.Parameters.AddWithValue("@emp_email", strEmail);
                com.Parameters.AddWithValue("@emp_password", strEpass);
                return com.ExecuteNonQuery();
            }
        }
        public int UpdateEmployee(string strEname, DateTime dateEdob, int intRID, int intEgend, string strEmail, string strEphone, string strEaddr, string strEpass, int intEID)
        {
            string strConString = @"Data Source=DESKTOP-9J9EK05\ARAVIND;Initial Catalog=TimesheetManagement;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand com = new SqlCommand("UpdateEmployeeDetails", con);
                com.CommandType = CommandType.StoredProcedure;

                if (string.IsNullOrEmpty(strEphone))
                {
                    com.Parameters.AddWithValue("@emp_phone", "");
                }
                else
                {
                    com.Parameters.AddWithValue("@emp_phone", strEphone);
                }

                if (string.IsNullOrEmpty(strEaddr))
                {
                    com.Parameters.AddWithValue("@emp_address", "");
                }
                else
                {
                    com.Parameters.AddWithValue("@emp_address", strEaddr);

                }


                com.Parameters.AddWithValue("@emp_dob", dateEdob);
               com.Parameters.AddWithValue("@emp_name", strEname);
                com.Parameters.AddWithValue("@role_id", intRID);
                com.Parameters.AddWithValue("@gender_id", intEgend);
                com.Parameters.AddWithValue("@emp_email", strEmail);
                com.Parameters.AddWithValue("@emp_password", strEpass);
                com.Parameters.AddWithValue("@emp_id", intEID);
                return com.ExecuteNonQuery();
            }
        }

        public int DeleteEmployee(int intEID)
        {
            string strConString = @"Data Source=DESKTOP-9J9EK05\ARAVIND;Initial Catalog=TimesheetManagement;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand com = new SqlCommand("DeleteEmployeeById", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@emp_id", intEID);
                return com.ExecuteNonQuery();
            }
        }
    }
}