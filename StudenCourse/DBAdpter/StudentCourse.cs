using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StudenCourse.Models;

namespace StudenCourse.DBAdpter
{
    public class StudentCourse
    {
        static string ConnectionStirng = ConfigurationManager.ConnectionStrings["Test_Anil"].ConnectionString;
        public int AddStudentCourse(Models.SCModel objstu)
        {
            SqlConnection con = new SqlConnection(ConnectionStirng);
            con.Open();
            string query = "proc_scids";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@StudentID", SqlDbType.VarChar).Value = objstu.StudentId;
            cmd.Parameters.Add("@CourseID", SqlDbType.VarChar).Value = objstu.CourseId;
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public bool CheckStudentcourse(Models.SCModel objstu)
        {
            bool areRows = false;
            SqlConnection con = new SqlConnection(ConnectionStirng);
            con.Open();
            string query = "Selct * from dbo.Sudent_Course where StudentId=" + objstu.StudentId + " and CourseId=" + objstu.CourseId;
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    areRows = true;
                }
            }

            con.Close();

            return areRows;

        }



    }
}