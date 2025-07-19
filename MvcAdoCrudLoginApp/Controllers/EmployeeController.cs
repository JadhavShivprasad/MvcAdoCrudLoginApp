using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAdoCrudLoginApp.Models;

namespace MvcAdoCrudLoginApp.Controllers
{
    public class EmployeeController : Controller
    {
        string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        // GET: Employee
        public ActionResult Index()
        {
            //CheckSession();
            var result = CheckSession();
            if (result != null)
                return result;

            List<Employee> employees = new List<Employee>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_GetEmployees", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    employees.Add(new Employee
                    {
                        EmployeeId = Convert.ToInt32(rdr["EmployeeId"]),
                        Name = rdr["Name"].ToString(),
                        Email = rdr["Email"].ToString(),
                        Department = rdr["Department"].ToString()
                    });
                }
            }
            return View(employees);
        }

        [HttpGet]
        //public ActionResult Create() => View();
        public ActionResult Create()
        {
            //if (Session["Username"] == null)
            //{
            //    return RedirectToAction("Index", "Login");
            //}

            var result = CheckSession();
            if (result != null)
                return result;

            var departments = GetAllDepartments();
            ViewBag.DepartmentList = new SelectList(departments, "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            var result = CheckSession();
            if (result != null)
                return result;
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_AddEmployee ", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Email", emp.Email);
                cmd.Parameters.AddWithValue("@Department", emp.Department);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var result = CheckSession();
            if (result != null)
                return result;

            Employee emp = new Employee();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_GetEmployeeById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    emp.EmployeeId = id;
                    emp.Name = rdr["Name"].ToString();
                    emp.Email = rdr["Email"].ToString();
                    emp.Department = rdr["Department"].ToString();
                    //emp.Department = Convert.ToInt32(rdr["Department"]);
                }
            }
            return View(emp);
        }

        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            var result = CheckSession();
            if (result != null)
                return result;

            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", emp.EmployeeId);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Email", emp.Email);
                cmd.Parameters.AddWithValue("@Department", emp.Department);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        //public ActionResult Delete(int id)
        //{
        //    var result = CheckSession();
        //    if (result != null)
        //        return result;
        //    using (SqlConnection con = new SqlConnection(constr))
        //    {
        //        SqlCommand cmd = new SqlCommand("sp_DeleteEmployee", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@Id", id);
        //        con.Open();
        //        cmd.ExecuteNonQuery();
        //    }
        //    return RedirectToAction("Index");
        //}


        public ActionResult Delete(int id)
        {
            var Result = CheckSession();
            if (Result != null) 
            {
                return Result;
            }

            Employee emp = new Employee();
            using (SqlConnection con = new SqlConnection(constr))
            { 
                SqlCommand cmd = new SqlCommand("sp_GetEmployeeById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    emp.EmployeeId = id;
                    emp.Name = rdr["Name"].ToString();
                    emp.Email = rdr["Email"].ToString();
                    emp.Department = rdr["Department"].ToString();
                }
            }

            return View(emp);
            //return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var Result = CheckSession();
            if (Result != null)
            {
                return Result;
            }

            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }

            return RedirectToAction("Index");
        }

        public List<Department> GetAllDepartments()
        {
            List<Department> departments = new List<Department>();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetAllDepartments", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    departments.Add(new Department
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString()
                    });
                }
            }
            return departments;
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