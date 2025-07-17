using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAdoCrudLoginApp.Models;

namespace MvcAdoCrudLoginApp.Controllers
{
    public class DepartmentController : Controller
    {
        string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public ActionResult Index()
        {
            List<Department> list = new List<Department>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Departments", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    list.Add(new Department
                    {
                        Id = Convert.ToInt32(rdr["Id"]),
                        Name = rdr["Name"].ToString()
                    });
                }
            }
            return View(list);
        }

        [HttpPost]
        public ActionResult Add(string name)
        {
            var Result = CheckSession();
            if (Result != null)
            {
                return Result;
            }

            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Departments (Name) VALUES (@Name)", con);
                cmd.Parameters.AddWithValue("@Name", name);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Update(int id, string name)
        {
            var Result = CheckSession();
            if (Result != null)
            {
                return Result;
            }
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("UPDATE Departments SET Name=@Name WHERE Id=@Id", con);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Name", name);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var Result = CheckSession();
            if (Result != null)
            {
                return Result;
            }

            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Departments WHERE Id=@Id", con);
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }
        public ActionResult CheckSession()
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return null;
        }
    }
}