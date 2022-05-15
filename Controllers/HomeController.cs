using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.FirstName = "Mosiul";
            ViewBag.LastName = "Khan";
            return View();
        }
        public ActionResult GetEmployee()
        {
            List<Employee> employee = new List<Employee>()
            {
                new Employee()
                {
                    EmployeeId = 1,
                    EmployeeName = "Mosiul",
                    Address = "67 Hay St",
                    DateofJoining = System.DateTime.Now,
                    MaritalStatus = 1,
                    IsEligibleForLoad = true,
                    Salary = 150000,
                    CreatedBy = "Admin",
                    CreatedDate = System.DateTime.Now
                },
                new Employee
                {
                    EmployeeId = 2,
                    EmployeeName = "Hasan",
                    Address = "67 Hay St",
                    DateofJoining = System.DateTime.Now,
                    MaritalStatus = 1,
                    IsEligibleForLoad = true,
                    Salary = 120000,
                    CreatedBy = "Mosiul",
                    CreatedDate = System.DateTime.Now
                },
                new Employee
                {
                    EmployeeId = 3,
                    EmployeeName = "Shakil",
                    Address = "67 Hay St",
                    DateofJoining = System.DateTime.Now,
                    MaritalStatus = 0,
                    IsEligibleForLoad = true,
                    Salary = 150000,
                    CreatedBy = "Admin",
                    CreatedDate = System.DateTime.Now
                }
            };

            ViewBag.Employee = employee;
            return View();

        }
    }
}