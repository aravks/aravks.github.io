using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace TimesheetManagement.Models
{
    public class ProjectModel
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }

        public DataTable GetAllProjects()
        {
            DataTable dt = new DataTable();
            string strConString = @"Data Source=DESKTOP-9J9EK05\ARAVIND;Initial Catalog=TimesheetManagement;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("GetProjects", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable GetProjectByID(int intProjectId)
        {
            DataTable dt = new DataTable();

            string strConString = @"Data Source=DESKTOP-9J9EK05\ARAVIND;Initial Catalog=TimesheetManagement;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("GetProjectById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProjectId", intProjectId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public int UpdateProject(int intProjectId, string strProjectName, string strDescription)
        {
            string strConString = @"Data Source=DESKTOP-9J9EK05\ARAVIND;Initial Catalog=TimesheetManagement;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UpdateProjectDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProjectName", strProjectName);
                cmd.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(strDescription) ? (object)DBNull.Value : strDescription);
                cmd.Parameters.AddWithValue("@ProjectId", intProjectId);
                return cmd.ExecuteNonQuery();
            }
        }

        public int InsertProject(string strProjectName, string strDescription)
        {
            string strConString = @"Data Source=DESKTOP-9J9EK05\ARAVIND;Initial Catalog=TimesheetManagement;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("AddNewProjectDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProjectName", strProjectName);
                cmd.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(strDescription)?(object)DBNull.Value:strDescription);
                return cmd.ExecuteNonQuery();
            }
        }
       

        public int DeleteProject(int intProjectId)
        {
            string strConString = @"Data Source=DESKTOP-9J9EK05\ARAVIND;Initial Catalog=TimesheetManagement;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DeleteProjectById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProjectId", intProjectId);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}