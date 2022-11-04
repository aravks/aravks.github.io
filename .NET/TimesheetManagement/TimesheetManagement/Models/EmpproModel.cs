using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EmpPro.Models
{
    public class EmpproModel
    {

        public int projname { get; set; }

        public int empname { get; set; }
        public int empproID { get; set; }


        public int Insert(int intproid, int intempid)
        {
            string strConString = @"Data Source=DESKTOP-9J9EK05\ARAVIND;Initial Catalog=TimesheetManagement;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand com = new SqlCommand("AddNewEmpProDetails", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@emp_id", intempid);
                com.Parameters.AddWithValue("@pro_id", intproid);

                return com.ExecuteNonQuery();
            }
        }

        public int Update(int intEmppromapID, int intproid, int intempid)
        {
            string strConString = @"Data Source=DESKTOP-9J9EK05\ARAVIND;Initial Catalog=TimesheetManagement;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand com = new SqlCommand("UpdateEmpProDetails", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@emp_id", intempid);
                com.Parameters.AddWithValue("@pro_id", intproid);
                com.Parameters.AddWithValue("@emppromap_id", intEmppromapID);
                return com.ExecuteNonQuery();
            }
        }


        public int DeleteSheet(int intEmppromapID)
        {
            string strConString = @"Data Source=DESKTOP-9J9EK05\ARAVIND;Initial Catalog=TimesheetManagement;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand com = new SqlCommand("DeleteEmpProById", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@emppromap_id", intEmppromapID);
                return com.ExecuteNonQuery();
            }
        }

        public DataTable GetEmpproByID(int intEmppromapID)
        {
            DataTable dt = new DataTable();

            string strConString = @"Data Source=DESKTOP-9J9EK05\ARAVIND;Initial Catalog=TimesheetManagement;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand com = new SqlCommand("GetEmpproByID", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@emppromap_id", intEmppromapID);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable GetAllEmppromap()
        {
            DataTable dt = new DataTable();
            string strConString = @"Data Source=DESKTOP-9J9EK05\ARAVIND;Initial Catalog=TimesheetManagement;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand com = new SqlCommand("Getall", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(dt);
            }
            return dt;
        }
    }
}