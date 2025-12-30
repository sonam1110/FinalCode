using ERPSystem_Models;
using ERPSystem_Services.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem_Services.Implementations
{
    public class TopicContentServices : ITopicContentServices
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public TopicContentServices()
        {
            con = new SqlConnection(DatabaseOperations.ConnectionString);
        }

        public void AddTopicContent(TopicContentModel content)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblTopic_Contents", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@command", "Insert");
            cmd.Parameters.AddWithValue("@content_id", content.ContentId);
            cmd.Parameters.AddWithValue("@content_name", content.ContentName);
            cmd.Parameters.AddWithValue("@topic_id", content.TopicId);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteTopicContent(int contentId)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblTopic_Contents", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@command", "Delete");
            cmd.Parameters.AddWithValue("@content_id", contentId);
            cmd.Parameters.AddWithValue("@content_name", "");
            cmd.Parameters.AddWithValue("@topic_id", 0);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public TopicContentModel GetTopicContent(int contentId)
        {
            return GetTopicContents().FirstOrDefault(e => e.ContentId.Equals(contentId));
        }

        public List<TopicContentModel> GetTopicContents()
        {
            con.Open();
            cmd = new SqlCommand("sp_fetch_tblTopic_Contents", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@content_id", 0);

            List<TopicContentModel> lst = new List<TopicContentModel>();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                int cid = Convert.ToInt32(dr["content_id"].ToString());
                string cname = dr["content_name"].ToString();
                int tid = Convert.ToInt32(dr["topic_id"].ToString());
                string tname = dr["topic_name"].ToString();

                TopicContentModel cm = new TopicContentModel()
                {
                    ContentId = cid,
                    ContentName = cname,
                    TopicId = tid,
                    TopicName = tname
                };
                lst.Add(cm);
            }

            con.Close();
            return lst;
        }

        public void RestoreTopicContent(int contentId)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblTopic_Contents", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@command", "Restore");
            cmd.Parameters.AddWithValue("@content_id", contentId);
            cmd.Parameters.AddWithValue("@content_name", "");
            cmd.Parameters.AddWithValue("@topic_id", 0);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateTopicContent(TopicContentModel content)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblTopic_Contents", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@command", "Update");
            cmd.Parameters.AddWithValue("@content_id", content.ContentId);
            cmd.Parameters.AddWithValue("@content_name", content.ContentName);
            cmd.Parameters.AddWithValue("@topic_id", content.TopicId);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
