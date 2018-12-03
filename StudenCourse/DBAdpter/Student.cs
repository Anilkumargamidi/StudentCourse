using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using StudenCourse.Models;
using System.Configuration;

namespace StudenCourse.DAL
{
    public class Student
    {
        static string ConnectionStirng = ConfigurationManager.ConnectionStrings["Test_Anil"].ConnectionString;
        public int AddStudent(Models.StudentModel objstu)
        {
            SqlConnection con = new SqlConnection(ConnectionStirng);
            con.Open();
            string query = "pro_student";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = objstu.FirstName;
            cmd.Parameters.Add("@SurName", SqlDbType.VarChar).Value = objstu.SurName;
            cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = objstu.Email;
            cmd.Parameters.Add("@IDNumber", SqlDbType.VarChar).Value = objstu.IDNumber;
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public List<StudentModel> GetStudentinfo()
        {

            List<StudentModel> lst = null;
            SqlConnection con = new SqlConnection(ConnectionStirng);
            con.Open();
            string query = "usp_GetStudentinfo";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader != null && reader.HasRows)
            {
                lst = new List<StudentModel>();
                while (reader.Read())
                {
                    StudentModel std = new StudentModel();
                    std.FirstName = reader["FirstName"].ToString();
                    std.SurName = reader["SurName"].ToString();
                    std.CousreName = reader["CourseName"].ToString();
                    std.StartDate = DateTime.Parse(reader["StartDate"].ToString());
                    std.EndDate = DateTime.Parse(reader["EndDate"].ToString());
                    lst.Add(std);
                }

            }

            con.Close();
            return lst;
        }


        public List<StudentModel> GetStudent()
        {

            List<StudentModel> lst = null;
            SqlConnection con = new SqlConnection(ConnectionStirng);
            con.Open();
            string query = "proc_getstudent";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader != null && reader.HasRows)
            {
                lst = new List<StudentModel>();
                while (reader.Read())
                {
                    StudentModel std = new StudentModel();
                    std.FirstName = reader["FirstName"].ToString();
                    std.SurName = reader["SurName"].ToString();
                    std.StudentId = Convert.ToInt32(reader["StudentId"].ToString());
                    std.FirstName = std.SurName + "," + std.FirstName;
                    lst.Add(std);
                }

            }

            con.Close();
            return lst;
        }

       
    }
}