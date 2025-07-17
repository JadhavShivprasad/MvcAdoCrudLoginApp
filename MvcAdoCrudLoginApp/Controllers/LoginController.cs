using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace MvcAdoCrudLoginApp.Controllers
{
    public class LoginController : Controller
    {
        string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        // GET: Login
        [HttpGet]
        public ActionResult Index() => View();

        [HttpPost]
        public ActionResult Index(string username, string password)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_AuthenticateUser", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    Session["Username"] = username;
                    return RedirectToAction("Index", "Employee");
                }
                ViewBag.Message = "Invalid credentials";

            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}