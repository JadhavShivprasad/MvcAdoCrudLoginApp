using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAdoCrudLoginApp.Models
{
    public class Employee
    {
        //chatGPT chat :- MVC ADO.NET CRUD App
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
    }

}