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
    public class StudentBreakDetailServices : IStudentBreakDetailServices
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public StudentBreakDetailServices()
        {
            con = new SqlConnection(DatabaseOperations.ConnectionString);
        }
        public void AddBreakDetail(StudentBreakDetailModel breakDetail)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblstudent_break_Details", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@command", "Insert");
            cmd.Parameters.AddWithValue("@break_id", breakDetail.BreakId);
            cmd.Parameters.AddWithValue("@registration_id", breakDetail.RegistrationId);
            cmd.Parameters.AddWithValue("@from_date", breakDetail.FromDate);
            cmd.Parameters.AddWithValue("@to_date", breakDetail.ToDate);
            cmd.Parameters.AddWithValue("@break_reason", breakDetail.BreakReason);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteBreakDetail(int breakDetailId)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblstudent_break_Details", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@command", "Delete");
            cmd.Parameters.AddWithValue("@break_id", breakDetailId);
            cmd.Parameters.AddWithValue("@registration_id", 0);
            cmd.Parameters.AddWithValue("@from_date", "");
            cmd.Parameters.AddWithValue("@to_date", "");
            cmd.Parameters.AddWithValue("@break_reason", "");

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public StudentBreakDetailModel GetBreakDetail(int breakDetailId)
        {
            return GetBreakDetails().FirstOrDefault(b => b.BreakId.Equals(breakDetailId));
        }

        public List<StudentBreakDetailModel> GetBreakDetails()
        {
            List<StudentBreakDetailModel> lst = new List<StudentBreakDetailModel>();

            con.Open();
            cmd = new SqlCommand("sp_fetch_tblstudent_break_details", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@break_id", 0);

            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                StudentBreakDetailModel brk = new StudentBreakDetailModel();
                brk.BreakId = Convert.ToInt32(dr["break_id"].ToString());
                brk.RegistrationId = Convert.ToInt32(dr["registration_id"].ToString());
                brk.RegistrationCode = dr["registration_code"].ToString();
                brk.FromDate = Convert.ToDateTime(dr["from_date"].ToString());
                brk.ToDate = Convert.ToDateTime(dr["to_date"].ToString());
                brk.BreakReason = dr["break_reason"].ToString();

                lst.Add(brk);
            }
            con.Close();
            return lst;
        }

        public void RestoreBreakDetail(int breakDetailId)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblstudent_break_Details", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@command", "Restore");
            cmd.Parameters.AddWithValue("@break_id", breakDetailId);
            cmd.Parameters.AddWithValue("@registration_id", 0);
            cmd.Parameters.AddWithValue("@from_date", "");
            cmd.Parameters.AddWithValue("@to_date", "");
            cmd.Parameters.AddWithValue("@break_reason", "");

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateBreakDetail(StudentBreakDetailModel breakDetail)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblstudent_break_Details", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@command", "Update");
            cmd.Parameters.AddWithValue("@break_id", breakDetail.BreakId);
            cmd.Parameters.AddWithValue("@registration_id", breakDetail.RegistrationId);
            cmd.Parameters.AddWithValue("@from_date", breakDetail.FromDate);
            cmd.Parameters.AddWithValue("@to_date", breakDetail.ToDate);
            cmd.Parameters.AddWithValue("@break_reason", breakDetail.BreakReason);

            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
