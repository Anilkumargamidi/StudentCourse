using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudenCourse.Models;
using StudenCourse.DBAdpter;

namespace StudenCourse.Controllers
{
    
    public class CourseController : Controller
    {
        // GET: Course
        DBAdpter.Course obj = new DBAdpter.Course();

    
        [HttpGet]
        public ActionResult Course()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Course(Models.CourseModel course)
        {
            int i = obj.AddCourse(course);
            if (i == 1)
            {
                Response.Write("Course Added");

            }
            else
            {
                Response.Write("Course Not Added");
            }
            return View();
            
        }
        public ActionResult GetCourse()
        {
            IEnumerable<CourseModel> students = obj.GetCourse();
            return Json(students);
        }


    }
}