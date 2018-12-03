using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StudenCourse.Models
{
    public class StudentModel
    {
        public int StudentId { get; set; }

       
        public string FirstName { get; set; }
        
        public string SurName { get; set; }
        public string Email { get; set; }
        public string IDNumber { get; set; }
        public int CourseId { get; set; }
        public string CousreName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }


    }
}