using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetStudents()
        {
            var student = new Student() { StudentId = 1, Name = "Mosiul", Address = "67 hyay St" };
            var subjects = new List<Subject>()
            {
                new Subject(){SubjectId=1,Name="Computer Programming"},
                new Subject(){SubjectId=2,Name="IOT"},
                new Subject(){SubjectId=3,Name="Cyber Security"}
            };
            var viewModel = new StudentViewModel()
            {
                Student=student,
                Subjects=subjects
            };
            return View(viewModel);
        }
        public ActionResult Student()
        {
            var students = new List<Student>()
            {
                new Student()
                {
                    StudentId=1,
                    Name="Jamil",
                    Address = "Dhaka"
                },
                new Student()
                {
                    StudentId=2,
                    Name="Sharif",
                    Address = "Vatapara"
                },
                new Student()
                {
                    StudentId=3,
                    Name="Tania",
                    Address = "Dhaka"
                }
            };
            return View(students);
        }
    }
}