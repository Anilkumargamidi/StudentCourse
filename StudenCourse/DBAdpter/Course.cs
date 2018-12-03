using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudenCourse.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace StudenCourse.DBAdpter
{
    public class Course
    {
        static string ConnectionStirng = ConfigurationManager.ConnectionStrings["Test_Anil"].ConnectionString;
        public int AddCourse(Models.CourseModel obj)
        {
            SqlConnection con = new SqlConnection(ConnectionStirng);
            con.Open();
            string query = "pro_course";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CourseName", SqlDbType.VarChar).Value = obj.CourseName;
            cmd.Parameters.Add("@StartDate", SqlDbType.VarChar).Value = obj.StartDate;
            cmd.Parameters.Add("@Enddate", SqlDbType.VarChar).Value = obj.EndDate;
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public List<CourseModel> GetCourse()
        {

            List<CourseModel> lst = null;
            SqlConnection con = new SqlConnection(ConnectionStirng);
            con.Open();
            string query = "proc_getcourse";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader != null && reader.HasRows)
            {
                lst = new List<CourseModel>();
                while (reader.Read())
                {
                    CourseModel std = new CourseModel();
                    std.CourseName = reader["CourseName"].ToString();
                    std.CourseId = Convert.ToInt32(reader["CourseId"].ToString());
                    lst.Add(std);
                }

            }

            con.Close();
            return lst;
        }
    }
}