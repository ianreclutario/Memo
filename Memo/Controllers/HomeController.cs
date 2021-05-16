using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data.SqlClient;

namespace Memo.Controllers
{
    //nagawa ko na putangina!!!!!!
    public class HomeController : Controller
    {
        //get dbconnection
        string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public JsonResult InsertFields(string firstName, string lastName, string choice)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string query =  "INSERT INTO PERSON(FIRST_NAME, LAST_NAME, CHOICE) VALUES (@firstName, @lastName, @choice)";
                SqlCommand cmd = new SqlCommand(query,con);
                cmd.Parameters.AddWithValue("@firstName", firstName);
                cmd.Parameters.AddWithValue("@lastName", lastName);
                cmd.Parameters.AddWithValue("@choice", choice);
                cmd.ExecuteNonQuery();
                con.Close();

                return Json("success", JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json("failure", JsonRequestBehavior.AllowGet);
            }
        }
    }
}