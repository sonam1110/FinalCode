using ERPSystem_Models;
using ERPSystem_Services.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem_Services.Implementations
{
    public class FeeModeServices : IFeeModeServices
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public FeeModeServices()
        {
            con = new SqlConnection(DatabaseOperations.ConnectionString);
        }


        public void AddFeeMode(FeeModeModel feeMode)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblFee_Modes", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@command", "Insert");
            cmd.Parameters.AddWithValue("@fee_mode_id", feeMode.FeeModeId);
            cmd.Parameters.AddWithValue("@fee_mode", feeMode.FeeMode);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteFeeMode(int feeModeId)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblFee_Modes", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@command", "Delete");
            cmd.Parameters.AddWithValue("@fee_mode_id", feeModeId);
            cmd.Parameters.AddWithValue("@fee_mode", "");
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public FeeModeModel GetFeeMode(int feeModeId)
        {
            return GetFeeModes().FirstOrDefault(e => e.FeeModeId.Equals(feeModeId));
        }

        public List<FeeModeModel> GetFeeModes()
        {
            con.Open();
            cmd = new SqlCommand("sp_fetch_tblFee_Modes", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fee_mode_id", 0);

            List<FeeModeModel> lst = new List<FeeModeModel>();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                int fid = Convert.ToInt32(dr["fee_mode_id"].ToString());
                string fname = dr["fee_mode"].ToString();

                FeeModeModel fm = new FeeModeModel()
                {
                    FeeModeId = fid,
                    FeeMode = fname
                };
                lst.Add(fm);
            }
            con.Close();
            return lst;
        }

        public void RestoreFeeMode(int feeModeId)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblFee_Modes", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@command", "Restore");
            cmd.Parameters.AddWithValue("@fee_mode_id", feeModeId);
            cmd.Parameters.AddWithValue("@fee_mode", "");
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateFeeMode(FeeModeModel feeMode)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblFee_Modes", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@command", "Update");
            cmd.Parameters.AddWithValue("@fee_mode_id", feeMode.FeeModeId);
            cmd.Parameters.AddWithValue("@fee_mode", feeMode.FeeMode);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
