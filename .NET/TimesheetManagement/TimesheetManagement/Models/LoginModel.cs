using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace TimesheetManagement.Models
{
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public string Subject = "Password Recovery Mail";
        public string Body = "Your Password is 123";
        public string CPEmail { get; set; }
        public string CPPassword { get; set; }
        public string CurrentPassword { get; set; }


        public int UpdatePassword(string Password, string Email)
        {
            string strConString = @"Data Source=DESKTOP-9J9EK05\ARAVIND;Initial Catalog=TimesheetManagement;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string query = "Update tblEmployee1 SET emp_password=@pass where emp_email=@email";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@pass", Password);
                cmd.Parameters.AddWithValue("@email", Email);
                return cmd.ExecuteNonQuery();
            }
        }

    }
}