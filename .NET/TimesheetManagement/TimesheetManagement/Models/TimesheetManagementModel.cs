using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace TimesheetManagement.Models
{
    public class TimesheetManagementModel
    {
        public int timesheetID { get; set; }
        public string vstsref { get; set; }
        public string taskdes { get; set; }
        public DateTime date { get; set; }
        public string fortime { get; set; }
        public string totime { get; set; }
        public string totaltime { get; set; }
        public string remarks { get; set; }
        public int proid { get; set; }
        public int projid { get; set; }

        public SelectList MobileList { get; set; }

        public SqlConnection con;
        public void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);

        }
        public DataTable GetAllSheets()
        {
            DataTable dt = new DataTable();
            string strConString = @"Data Source=DESKTOP-9J9EK05\ARAVIND;Initial Catalog=TimesheetManagement;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand com = new SqlCommand("GetSheet", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable GetSheetByID(int inttimesheetID)
        {
            DataTable dt = new DataTable();

            string strConString = @"Data Source=DESKTOP-9J9EK05\ARAVIND;Initial Catalog=TimesheetManagement;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand com = new SqlCommand("GetSheetById", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@timesheet_id", inttimesheetID);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(dt);
            }
            return dt;
        }

        public int UpdateSheet(int inttimesheetID, string strVstsref, string strTaskDef, int intProjName, DateTime strDate, string strFrom, string strTo, string strTot, string strRemark, int intempid)
        {
            string strConString = @"Data Source=DESKTOP-9J9EK05\ARAVIND;Initial Catalog=TimesheetManagement;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand com = new SqlCommand("UpdateSheetDetails", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@vstsref", strVstsref);
                if (string.IsNullOrEmpty(strTaskDef))
                {
                    com.Parameters.AddWithValue("@task_des", "");
                }
                else
                {
                    com.Parameters.AddWithValue("@task_des", strTaskDef);
                }
                com.Parameters.AddWithValue("@project_id", intProjName);
                com.Parameters.AddWithValue("@project_date", strDate);
                com.Parameters.AddWithValue("@frm_time", strFrom);
                com.Parameters.AddWithValue("@to_time", strTo);
                com.Parameters.AddWithValue("@tot_time", strTot);
                if (string.IsNullOrEmpty(strRemark))
                {
                    com.Parameters.AddWithValue("@ts_remarks", "");
                }
                else
                {
                    com.Parameters.AddWithValue("@ts_remarks", strRemark);
                }
                com.Parameters.AddWithValue("@timesheet_id", inttimesheetID);
                com.Parameters.AddWithValue("@empid", intempid);
                return com.ExecuteNonQuery();
            }
        }

        public int InsertSheet(string strVstsref, string strTaskDef, int intProjName, DateTime strDate, string strFrom, string strTo, string strTot, string strRemark, int intempid)
        {
            string strConString = @"Data Source=DESKTOP-9J9EK05\ARAVIND;Initial Catalog=TimesheetManagement;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand com = new SqlCommand("AddNewSheetDetails", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@vstsref", strVstsref);
                if (string.IsNullOrEmpty(strTaskDef))
                {
                    com.Parameters.AddWithValue("@task_des", "");
                }
                else
                {
                    com.Parameters.AddWithValue("@task_des", strTaskDef);
                }
                com.Parameters.AddWithValue("@project_id", intProjName);
                com.Parameters.AddWithValue("@project_date", strDate);
                com.Parameters.AddWithValue("@frm_time", strFrom);
                com.Parameters.AddWithValue("@to_time", strTo);
                com.Parameters.AddWithValue("@tot_time", strTot);
                if (string.IsNullOrEmpty(strRemark))
                {
                    com.Parameters.AddWithValue("@ts_remarks", "");
                }
                else
                {
                    com.Parameters.AddWithValue("@ts_remarks", strRemark);
                }
                com.Parameters.AddWithValue("@empid", intempid);
                return com.ExecuteNonQuery();
            }
        }

        public int DeleteSheet(int inttimesheetID)
        {
            string strConString = @"Data Source=DESKTOP-9J9EK05\ARAVIND;Initial Catalog=TimesheetManagement;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand com = new SqlCommand("DeleteSheetById", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@timesheet_id", inttimesheetID);
                return com.ExecuteNonQuery();
            }
        }

        public DataTable GetAll(int intempid)//empid>0,check
        {
            DataTable dt = new DataTable();
            string strConString = @"Data Source=DESKTOP-9J9EK05\ARAVIND;Initial Catalog=TimesheetManagement;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand com = new SqlCommand("GetAllTsm", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@empid", intempid);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(dt);
            }
            return dt;
        }

    }
}