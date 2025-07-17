using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAdoCrudLoginApp.Models;

namespace MvcAdoCrudLoginApp.Controllers
{
    public class StudentController : Controller
    {
        string ConStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public ActionResult CheckSession()
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return null;
        }
        // GET: Student
        public ActionResult Index()
        {
            var Result = CheckSession();
            if (Result != null)
            {
                return Result;
            }

            List<Student> students = new List<Student>();
            using (SqlConnection con = new SqlConnection(ConStr))
            {
                SqlCommand cmd = new SqlCommand("sp_GetAllStudents", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    students.Add(new Student
                    {
                        Id = Convert.ToInt32(rdr["Id"]),
                        Name = rdr["Name"].ToString(),
                        Email = rdr["Email"].ToString()
                    });
                }
                ViewData["students"] = students;
                return View();
            }
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            var Result = CheckSession();
            if (Result != null)
            {
                return Result;
            }

            using (SqlConnection con = new SqlConnection(ConStr))
            {
                SqlCommand cmd = new SqlCommand("sp_AddStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", form["Name"]);
                cmd.Parameters.AddWithValue("@Email", form["Email"]);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var Result = CheckSession();
            if (Result != null)
            {
                return Result;
            }

            Student s = new Student();
            using (SqlConnection con = new SqlConnection(ConStr))
            {
                SqlCommand cmd = new SqlCommand("sp_GetStudentById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    s.Id = id;
                    s.Name = rdr["Name"].ToString();
                    s.Email = rdr["Email"].ToString();
                }
            }
            ViewData["student"] = s;
            return View();
        }
        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
            var Result = CheckSession();
            if (Result != null)
            {
                return Result;
            }


            using (SqlConnection con = new SqlConnection(ConStr))
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(form["Id"]));
                cmd.Parameters.AddWithValue("@Name", form["Name"]);
                cmd.Parameters.AddWithValue("@Email", form["Email"]);
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

            using (SqlConnection con = new SqlConnection(ConStr))
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }
    }
}