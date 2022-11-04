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
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index()              
        {
            ProjectModel model = new ProjectModel();    //creating object for model
            DataTable dt = model.GetAllProjects();     //getting all the projects using the method GetAllProjects from model and storing in dt
            return View("Index", dt);                  //returning the dt values in index view
        }
       

        public ActionResult AddEdit(int ProjectId = 0)    //AddEdit method with parameter projectid=0
        {
            if (ProjectId != 0)                         //if projectid is not equal to 0 it returns addedit view    
            {
                ViewBag.message = "Edit";                 //if projectid is equal to 0,if statement executes and viewbag stores the message
                ProjectModel model = new ProjectModel();  
                DataTable dt = model.GetProjectByID(ProjectId);  //getting projectId using the method GetProjectById from the model and storing it in dt
                return View("AddEdit", dt);              //displaying the projectId stored in the dt in addedit view

            }
            return View("AddEdit");
        }

        public ActionResult InsertRecord(ProjectModel obj, string action) //InsertRecord method with 2 input parameter
        {
            if (action == "Submit")     //if the action is equal to submit ..if executes..
            {
                if (obj.ProjectId.Equals(0))   //if projectId is equal to 0, if executes
                {

                    SqlConnection con = new SqlConnection();                       //connection object is initialized
                    SqlCommand com = new SqlCommand();                            //command obj is initialised
                    SqlDataReader dr;                                              // datareader is defined and is used to read the data from sql
                    con.ConnectionString = @"Data Source=DESKTOP-9J9EK05\ARAVIND;Initial Catalog=TimesheetManagement;Integrated Security=True";
                    con.Open();                                             //cpnnection is opened
                    com.Connection = con;
                    com.CommandText = "Select * from tblProject where ProjectName='" + obj.ProjectName + "' "; //command/query is passed to the database
                    dr = com.ExecuteReader();                               //executes the sql command and returns the values( multiple rows)to dr
                    if (dr.Read())                                           //reads the other available rows, if it present if executes.. 
                    {
                        con.Close();                                        //connection get closed 
                        ViewBag.Message = "Project Name already exists";     //returns a message
                        return View("AddEdit");                                 //and returns addedit view
                    }
                    else        
                    {
                        ProjectModel model = new ProjectModel();

                        string ProjectName = obj.ProjectName;              //  given projectname is assigned here
                        string Description = obj.Description;              //given description is assigned here
                        int status = model.InsertProject(ProjectName, Description);  //  ProjectName and description is passed to InsertProject method in model
                        return RedirectToAction("Index");              //after the name and description is inserted it returns to index action
                    }

                }
                else   //if projectId is not equal to zero else part executes..
                {
                    SqlConnection con = new SqlConnection();
                    SqlCommand com = new SqlCommand();
                    SqlDataReader dr;
                    con.ConnectionString = @"Data Source=DESKTOP-9J9EK05\ARAVIND;Initial Catalog=TimesheetManagement;Integrated Security=True";
                    con.Open();
                    com.Connection = con;
                    com.CommandText = "Select * from tblProject where ProjectName='" + obj.ProjectName + "'except Select  * from tblProject where ProjectId ='" + obj.ProjectId + "'  ";
                    dr = com.ExecuteReader();
                    bool result = dr.Read();
                    if(result)
                    {
                         ViewBag.Message = "Project name already exists"; 
                        con.Close();
                        DataTable dt = new DataTable();
                        dt = obj.GetProjectByID(obj.ProjectId);
                        return View("AddEdit");
                    }
                    else { 

                    ProjectModel model = new ProjectModel();
                        int ProjectId = obj.ProjectId;
                        string ProjectName = obj.ProjectName;
                        string Description = obj.Description;
                        int status = model.UpdateProject(ProjectId, ProjectName, Description);
                        return RedirectToAction("Index");
                    }

                }
                
            }
            else //if action is not equal to submit else executes..
            {
                return RedirectToAction("Index");//if action other than submit it then redirects to index action
            }
        }

        public ActionResult Delete(int ProjectId)
        {
            ProjectModel model = new ProjectModel();
            model.DeleteProject(ProjectId);
            return RedirectToAction("Index");
        }
    }
}