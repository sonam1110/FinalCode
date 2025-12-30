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
    public class TrainingCourseFeeServices : ITrainingCourseFeeServices
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public TrainingCourseFeeServices()
        {
            con = new SqlConnection(DatabaseOperations.ConnectionString);
        }
        public void AddCourseFee(TrainingCourseFeeModel fee)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblTraining_Course_Fees", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@command", "Insert");
            cmd.Parameters.AddWithValue("@course_fee_id", 0);
            cmd.Parameters.AddWithValue("@course_id", fee.CourseId);
            cmd.Parameters.AddWithValue("@fee_mode_id", fee.FeeModeId);
            cmd.Parameters.AddWithValue("@amount", fee.Amount);
            cmd.Parameters.AddWithValue("@tax", fee.Tax);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteCourseFee(int feeId)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblTraining_Course_Fees", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@command", "Delete");
            cmd.Parameters.AddWithValue("@course_fee_id", feeId);
            cmd.Parameters.AddWithValue("@course_id", 0);
            cmd.Parameters.AddWithValue("@fee_mode_id", 0);
            cmd.Parameters.AddWithValue("@amount", 0);
            cmd.Parameters.AddWithValue("@tax", 0);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public TrainingCourseFeeModel GetCourseFee(int feeId)
        {
            return GetCourseFees().FirstOrDefault(e => e.CourseFeeId.Equals(feeId));
        }

        public List<TrainingCourseFeeModel> GetCourseFees()
        {
            List<TrainingCourseFeeModel> lst = new List<TrainingCourseFeeModel>();

            con.Open();
            cmd = new SqlCommand("sp_fetch_tblTraining_Course_Fees", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@course_fee_id", 0);

            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int cfid = Convert.ToInt32(dr["course_fee_id"].ToString());
                int cid = Convert.ToInt32(dr["course_id"].ToString());
                string cname = dr["course_name"].ToString();
                int mid = Convert.ToInt32(dr["fee_mode_id"].ToString());
                string mname = dr["fee_mode"].ToString();
                float amt = float.Parse(dr["amount"].ToString());
                float tax = float.Parse(dr["tax"].ToString());

                TrainingCourseFeeModel m = new TrainingCourseFeeModel()
                {
                    CourseFeeId = cfid,
                    CourseId = cid,
                    CourseName = cname,
                    FeeModeId = mid,
                    FeeMode = mname,
                    Amount = amt,
                    Tax = tax
                };

                lst.Add(m);
            }
            con.Close();
            return lst;
        }

        public void RestoreCourseFee(int feeId)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblTraining_Course_Fees", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@command", "Restore");
            cmd.Parameters.AddWithValue("@course_fee_id",feeId);
            cmd.Parameters.AddWithValue("@course_id", 0);
            cmd.Parameters.AddWithValue("@fee_mode_id", 0);
            cmd.Parameters.AddWithValue("@amount", 0);
            cmd.Parameters.AddWithValue("@tax", 0);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateCourseFee(TrainingCourseFeeModel fee)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblTraining_Course_Fees", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@command", "Update");
            cmd.Parameters.AddWithValue("@course_fee_id", 0);
            cmd.Parameters.AddWithValue("@course_id", fee.CourseId);
            cmd.Parameters.AddWithValue("@fee_mode_id", fee.FeeModeId);
            cmd.Parameters.AddWithValue("@amount", fee.Amount);
            cmd.Parameters.AddWithValue("@tax", fee.Tax);

            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
