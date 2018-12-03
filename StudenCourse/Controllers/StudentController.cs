using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudenCourse.DAL;
using StudenCourse.Models;

namespace StudenCourse.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        DAL.Student obj = new DAL.Student();
        public ActionResult Index()
        {
            IEnumerable<StudentModel> std = obj.GetStudentinfo();
            return View(std);
        }

        public ActionResult Student()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Student(Models.StudentModel objstu)
        {
            int i = obj.AddStudent(objstu);
            if (i == 1)
            {
                Response.Write("Student Added");

            }
            else
            {
                Response.Write("Studenet Not Added");
            }
            return View();
        }

        [HttpPost]
        public ActionResult GetStudent()
        {
            IEnumerable<StudentModel> students = obj.GetStudent();
            return Json(students);
        }

        //[HttpPost]
        //public ActionResult AddSC(SCModel obj)
        //{
        //    //SCModel obj = new SCModel { StudentId = studnetId, CourseId = CourseId };
        //    DBAdpter.StudentCourse objsc = new DBAdpter.StudentCourse();
        //    objsc.AddStudentCourse(obj);
        //    return RedirectToAction("Index");
        //}
        [HttpPost]
        public ActionResult AddSC(SCModel obj)
        {
            string inserted = "";
            //SCModel obj = new SCModel { StudentId = studnetId, CourseId = CourseId };
            DBAdpter.StudentCourse objsc = new DBAdpter.StudentCourse();
            var alreadyAvail = objsc.CheckStudentcourse(obj);
            if (alreadyAvail)
            {
                inserted = "already";
            }
            int i = objsc.AddStudentCourse(obj);
            if (i > 0)
            {
                inserted = "added";
            }
            return Json(inserted);
        }

    }
}