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
    public class ExamLevelServices : IExamLevelServices
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public ExamLevelServices()
        {
            con = new SqlConnection(DatabaseOperations.ConnectionString);
        }

        public void AddExamLevel(ExamLevelModel examLevel)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblExam_Levels", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@command", "Insert");
            cmd.Parameters.AddWithValue("@level_id", examLevel.LevelId);
            cmd.Parameters.AddWithValue("@level_name", examLevel.LevelName);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteExamLevel(int examLevelId)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblExam_Levels", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@command", "Delete");
            cmd.Parameters.AddWithValue("@level_id", examLevelId);
            cmd.Parameters.AddWithValue("@level_name", "");
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public ExamLevelModel GetExamLevel(int examLevelId)
        {
            return GetExamLevels().FirstOrDefault(e => e.LevelId.Equals(examLevelId));
        }

        public List<ExamLevelModel> GetExamLevels()
        {
            con.Open();
            cmd = new SqlCommand("sp_fetch_tblExam_Levels", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@level_id", 0);

            List<ExamLevelModel> lst = new List<ExamLevelModel>();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                int lid = Convert.ToInt32(dr["level_id"].ToString());
                string lname = dr["level_name"].ToString();

                ExamLevelModel lm = new ExamLevelModel()
                {
                    LevelId = lid,
                    LevelName = lname
                };
                lst.Add(lm);
            }

            con.Close();
            return lst;
        }

        public void RestoreExamLevel(int examLevelId)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblExam_Levels", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@command", "Restore");
            cmd.Parameters.AddWithValue("@level_id", examLevelId);
            cmd.Parameters.AddWithValue("@level_name", "");
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateExamLevel(ExamLevelModel examLevel)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblExam_Levels", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@command", "Update");
            cmd.Parameters.AddWithValue("@level_id", examLevel.LevelId);
            cmd.Parameters.AddWithValue("@level_name", examLevel.LevelName);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
