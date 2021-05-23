using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.Services;
using Memo.Models;

namespace Memo.Controllers
{
   
    public class HomeController : Controller
    {
        //get dbconnection
        string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        [HttpGet]
        
        public ActionResult Index()
        {
            Header h = new Header();
            DataTable dtbl = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                
                con.Open();
                string query = "select * from header";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.Fill(dtbl);
                


            }
            return View(dtbl);
        }

        public ActionResult Create(Header h )
        {
            h.Name = "Ian Rex Clutario";
            h.Department = "MISD";
         

            


            return View(h);
        }
        public ActionResult Edit(int id)
        {
            Header h = new Header();
            DataTable dtbl = new DataTable(); 
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "select * from header where ID = @ID";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.SelectCommand.Parameters.AddWithValue("@ID", id);
                da.Fill(dtbl);
            }

            if( dtbl.Rows.Count == 1)
            {
                h.ID = Convert.ToInt32(dtbl.Rows[0][0].ToString());
                h.Type = dtbl.Rows[0][1].ToString();
                h.RNo = dtbl.Rows[0][3].ToString();
                h.To = dtbl.Rows[0][4].ToString();
                h.Date = dtbl.Rows[0][5].ToString();
                h.Address = dtbl.Rows[0][6].ToString();
                h.Store = dtbl.Rows[0][7].ToString();
                h.Text = dtbl.Rows[0][8].ToString();
                h.Amount = dtbl.Rows[0][9].ToString();
                h.Reference = dtbl.Rows[0][11].ToString();
                return View(h);

            }
            else
            { 
                return RedirectToAction("Index");
            }
           
        }
        [HttpPost]
        public ActionResult Edit(Header h)
        {
           
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = @"update header set H_TYPE = @h_type, H_TO = @h_to, H_RNO = @h_rno, H_DATE = @h_date, H_ADDRESS = @h_address, H_STORE = @h_store where ID = @ID";
                SqlCommand cmd = new SqlCommand(query,con);
                cmd.Parameters.AddWithValue("@ID", h.ID);
                cmd.Parameters.AddWithValue("@h_type", h.Type);
                cmd.Parameters.AddWithValue("@h_to", h.To);
                cmd.Parameters.AddWithValue("@h_rno", h.RNo);
                cmd.Parameters.AddWithValue("@h_date", h.Date);
                cmd.Parameters.AddWithValue("@h_address", h.Address);
                cmd.Parameters.AddWithValue("@h_store", h.Store);

                cmd.ExecuteNonQuery();
                con.Close();
                

            }
            return RedirectToAction("Index");

        }

        //public ActionResult Contact()
        //{


        //   //return RedirectToAction();
        //}

        [WebMethod]
        public JsonResult InsertFields(string encdate, string h_type, string h_rno, string h_to, string h_date, string h_address, string h_store, string h_text, string h_amount, string h_pesos, string h_reference)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string query = @"INSERT INTO HEADER(
                        [EncodedDate]
                        ,[H_TYPE]
                        ,[H_RNO]
                        ,[H_TO]
                        ,[H_DATE]
                        ,[H_ADDRESS]
                        ,[H_STORE]
                        ,[H_TEXT]
                        ,[H_AMOUNT]
                        ,[H_PESOS]
                        ,[H_REFERENCE]) 
                    VALUES (@encdate, @h_type,@h_rno,@h_to,@h_date,@h_address,@h_store,@h_text,@h_amount,@h_pesos,@h_reference)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@encdate", encdate);
                cmd.Parameters.AddWithValue("@h_type", h_type);
                cmd.Parameters.AddWithValue("@h_rno", h_rno);
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
        [WebMethod]
        public JsonResult EditFields(string id, string h_type, string h_rno, string h_to, string h_date, string h_address, string h_store, string h_text, string h_amount, string h_pesos, string h_reference)
        {
            try
            {               
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = @"update header set         
                        [H_TYPE] = @h_type
                        ,[H_RNO] = @h_rno
                        ,[H_TO] = @h_to
                        ,[H_DATE] = @h_date
                        ,[H_ADDRESS] = @h_address
                        ,[H_STORE] = @h_store
                        ,[H_TEXT] =  @h_text
                        ,[H_AMOUNT] = @h_amount
                        ,[H_PESOS] = @h_pesos
                        ,[H_REFERENCE] = @h_reference
                        where ID = @ID";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@ID", id);    
                    cmd.Parameters.AddWithValue("@h_type", h_type);
                    cmd.Parameters.AddWithValue("@h_rno", h_rno);
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

            }


            catch (Exception e)
            {
                return Json("failure", JsonRequestBehavior.AllowGet);
            }

        }
    }

}