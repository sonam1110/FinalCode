using ERPSystem_Models;
using ERPSystem_Services.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem_Services.Implementations
{
    public class TrainingCourseServices : ITrainingCourseServices
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public TrainingCourseServices()
        {
            con = new SqlConnection(DatabaseOperations.ConnectionString);
        }


        public void AddCourse(TrainingCourseModel course)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblTraining_Courses", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@command", "Insert");
            cmd.Parameters.AddWithValue("@course_id", course.CourseId);
            cmd.Parameters.AddWithValue("@course_name", course.CourseName);
            cmd.Parameters.AddWithValue("@course_code", course.CourseCode);
            cmd.Parameters.AddWithValue("@technology_id", course.TechnologyId);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteCourse(int courseId)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblTraining_Courses", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@command", "Delete");
            cmd.Parameters.AddWithValue("@course_id", courseId);
            cmd.Parameters.AddWithValue("@course_name", "");
            cmd.Parameters.AddWithValue("@course_code", "");
            cmd.Parameters.AddWithValue("@technology_id", 0);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public TrainingCourseModel GetCourse(int courseId)
        {
            return GetCourses().FirstOrDefault(e => e.CourseId.Equals(courseId));
        }

        public List<TrainingCourseModel> GetCourses()
        {
            con.Open();
            cmd = new SqlCommand("sp_fetch_tblTraining_Courses", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@course_id", 0);

            List<TrainingCourseModel> lst = new List<TrainingCourseModel>();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                int cid = Convert.ToInt32(dr["course_id"].ToString());
                string cname = dr["course_name"].ToString();
                string ccode = dr["course_code"].ToString();
                int tid = Convert.ToInt32(dr["technology_id"].ToString());
                string tname = dr["technology_name"].ToString();

                TrainingCourseModel cm = new TrainingCourseModel()
                {
                    CourseId = cid,
                    CourseName = cname,
                    CourseCode = ccode,
                    TechnologyId = tid,
                    TechnologyName = tname
                };
                lst.Add(cm);
            }

            con.Close();
            return lst;
        }

        public void RestoreCourse(int courseId)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblTraining_Courses", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@command", "Restore");
            cmd.Parameters.AddWithValue("@course_id", courseId);
            cmd.Parameters.AddWithValue("@course_name", "");
            cmd.Parameters.AddWithValue("@course_code", "");
            cmd.Parameters.AddWithValue("@technology_id", 0);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateCourse(TrainingCourseModel course)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblTraining_Courses", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@command", "Update");
            cmd.Parameters.AddWithValue("@course_id", course.CourseId);
            cmd.Parameters.AddWithValue("@course_name", course.CourseName);
            cmd.Parameters.AddWithValue("@course_code", course.CourseCode);
            cmd.Parameters.AddWithValue("@technology_id", course.TechnologyId);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
