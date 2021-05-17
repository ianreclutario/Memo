using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.Services;

namespace Memo.Controllers
{
    //nagawa ko na putangina!!!!!!
    public class HomeController : Controller
    {
        //get dbconnection
        string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        [HttpGet]
      
        public ActionResult Index()
        {
            DataTable dtbl = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "select * from header";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.Fill(dtbl);


            }
                return View();
        }

        public ActionResult Create()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [WebMethod]
        public JsonResult InsertFields(string h_type, string h_rno, string h_to, string h_date, string h_address, string h_store, string h_text, string h_amount, string h_pesos, string h_reference)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string query = @"INSERT INTO HEADER(
                         [H_RNO]
                        ,[H_TYPE]
                        ,[H_TO]
                        ,[H_DATE]
                        ,[H_ADDRESS]
                        ,[H_STORE]
                        ,[H_TEXT]
                        ,[H_AMOUNT]
                        ,[H_PESOS]
                        ,[H_REFERENCE]) 
                    VALUES (@h_type,@h_rno, @h_to,@h_date,@h_address,@h_store,@h_text,@h_amount,@h_pesos,@h_reference)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@h_rno", h_rno);
                cmd.Parameters.AddWithValue("@h_type", h_type);
                cmd.Parameters.AddWithValue("@h_to", h_to);
                cmd.Parameters.AddWithValue("@h_date", h_date);
                cmd.Parameters.AddWithValue("@h_address", h_address);
                cmd.Parameters.AddWithValue("@h_store", h_store);
                cmd.Parameters.AddWithValue("@h_text", h_text);
                cmd.Parameters.AddWithValue("@h_amount", h_amount);
                cmd.Parameters.AddWithValue("@h_pesos", h_pesos);
                cmd.Parameters.AddWithValue("@h_reference", h_reference);

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