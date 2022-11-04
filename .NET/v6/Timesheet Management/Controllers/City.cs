//using System.Collections.Generic;
//using System.Configuration;
//using System.Data;
//using System.Data.SqlClient;
//using System.Web.Mvc;

//namespace Timesheet_Management.Controllers
//{
//    public class City
//    {
//        public bool IsSelected { get; set; }
//        public int City_ID { get; set; }
//        public string City_Name { get; set; }
//        public IEnumerable<string> Cities { get; set; }

//        Cities = GetAllCity();

//        public SelectList GetAllCity()
//        {
//            string constr = ConfigurationManager.ConnectionStrings["sConnectionString"].ToString();
//            SqlConnection _con = new SqlConnection(constr);
//            SqlDataAdapter _da = new SqlDataAdapter("SELECT [City_id],[City_name] FROM [timestampmanagement].[dbo].[City]", constr);
//            DataTable _dt = new DataTable();
//            _da.Fill(_dt);
//            // return ToSelectList(_dt, "pro_id", "pro_name");

//            List<SelectListItem> list = new List<SelectListItem>();

//            foreach (DataRow row in _dt.Rows)
//            {
//                list.Add(new SelectListItem()
//                {
//                    Text = row["City_name"].ToString(),
//                    Value = row["City_id"].ToString(),
//                });
//            }
//            return new SelectList(list, "Value", "Text", "Selected");

//        }
//    }
//}