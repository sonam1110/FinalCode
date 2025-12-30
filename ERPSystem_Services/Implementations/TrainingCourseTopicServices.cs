using ERPSystem_Models;
using ERPSystem_Services.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem_Services.Implementations
{
    public class TrainingCourseTopicServices : ITrainingCourseTopicServices
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public TrainingCourseTopicServices()
        {
            con = new SqlConnection(DatabaseOperations.ConnectionString);
        }
        public void AddCourseTopic(TrainingCourseTopicModel courseTopic)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblTraining_course_Topics", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@command", "Insert");
            cmd.Parameters.AddWithValue("@course_topic_id", 0);
            cmd.Parameters.AddWithValue("@course_id", courseTopic.CourseId);
            cmd.Parameters.AddWithValue("@topic_id", courseTopic.TopicId);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteCourseTopic(int courseTopicId)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblTraining_course_Topics", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@command", "Delete");
            cmd.Parameters.AddWithValue("@course_topic_id", courseTopicId);
            cmd.Parameters.AddWithValue("@course_id", 0);
            cmd.Parameters.AddWithValue("@topic_id", 0);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public TrainingCourseTopicModel GetCourseTopic(int courseTopicId)
        {
            return GetCourseTopics().FirstOrDefault(e => e.CourseTopicId.Equals(courseTopicId));
        }

        public List<TrainingCourseTopicModel> GetCourseTopics()
        {
            List<TrainingCourseTopicModel> lst = new List<TrainingCourseTopicModel>();

            con.Open();
            cmd = new SqlCommand("sp_fetch_tblTraining_course_Topics", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@course_topic_id",0);

            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int ctid = Convert.ToInt32(dr["course_topic_id"].ToString());
                int cid = Convert.ToInt32(dr["course_id"].ToString());
                string cname = dr["course_name"].ToString();
                int tid = Convert.ToInt32(dr["topic_id"].ToString());
                string tname = dr["topic_name"].ToString();

                TrainingCourseTopicModel m = new TrainingCourseTopicModel()
                {
                    CourseTopicId = ctid,
                    CourseId = cid,
                    CourseName = cname,
                    TopicId = tid,
                    TopicName = tname
                };

                lst.Add(m);
            }
            con.Close();
            return lst;
        }

        public void RestoreCourseTopic(int courseTopicId)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblTraining_course_Topics", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@command", "Restore");
            cmd.Parameters.AddWithValue("@course_topic_id", courseTopicId);
            cmd.Parameters.AddWithValue("@course_id", 0);
            cmd.Parameters.AddWithValue("@topic_id", 0);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateCourseTopic(TrainingCourseTopicModel courseTopic)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblTraining_course_Topics", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@command", "Update");
            cmd.Parameters.AddWithValue("@course_topic_id", 0);
            cmd.Parameters.AddWithValue("@course_id", courseTopic.CourseId);
            cmd.Parameters.AddWithValue("@topic_id", courseTopic.TopicId);

            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
