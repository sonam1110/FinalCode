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
    public class TrainingTopicServices : ITrainingTopicServices
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public TrainingTopicServices()
        {
            con = new SqlConnection(DatabaseOperations.ConnectionString);
        }
        public void AddTopic(TrainingTopicModel topic)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblTraining_Topics", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@command", "Insert");
            cmd.Parameters.AddWithValue("@topic_id", topic.TopicId);
            cmd.Parameters.AddWithValue("@topic_name", topic.TopicName);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteTopic(int topicId)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblTraining_Topics", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@command", "Delete");
            cmd.Parameters.AddWithValue("@topic_id", topicId);
            cmd.Parameters.AddWithValue("@topic_name", "");
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public TrainingTopicModel GetTopic(int topicId)
        {
            return GetTopics().FirstOrDefault(e => e.TopicId.Equals(topicId));
        }

        public List<TrainingTopicModel> GetTopics()
        {
            con.Open();
            cmd = new SqlCommand("sp_fetch_tblTraining_Topics", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@topic_id", 0);

            List<TrainingTopicModel> lst = new List<TrainingTopicModel>();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                int tid = Convert.ToInt32(dr["topic_id"].ToString());
                string tname = dr["topic_name"].ToString();

                TrainingTopicModel tm = new TrainingTopicModel()
                {
                    TopicId = tid,
                    TopicName = tname
                };
                lst.Add(tm);
            }

            con.Close();
            return lst;
        }

        public void RestoreTopic(int topicId)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblTraining_Topics", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@command", "Restore");
            cmd.Parameters.AddWithValue("@topic_id", topicId);
            cmd.Parameters.AddWithValue("@topic_name", "");
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateTopic(TrainingTopicModel topic)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblTraining_Topics", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@command", "Update");
            cmd.Parameters.AddWithValue("@topic_id", topic.TopicId);
            cmd.Parameters.AddWithValue("@topic_name", topic.TopicName);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
