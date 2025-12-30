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
    public class LeadSourceServices : ILeadSourceServices
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public LeadSourceServices()
        {
            con = new SqlConnection(DatabaseOperations.ConnectionString);
        }
        public void AddLeadSource(LeadSourceModel source)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblLead_Sources", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@command", "Insert");
            cmd.Parameters.AddWithValue("@source_id", source.SourceId);
            cmd.Parameters.AddWithValue("@source_name", source.SourceName);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteLeadSource(int sourceId)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblLead_Sources", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@command", "Delete");
            cmd.Parameters.AddWithValue("@source_id", sourceId);
            cmd.Parameters.AddWithValue("@source_name", ""); 
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public LeadSourceModel GetLeadSource(int sourceId)
        {
            return GetLeadSources().FirstOrDefault(e => e.SourceId.Equals(sourceId));
        }

        public List<LeadSourceModel> GetLeadSources()
        {
            con.Open();
            cmd = new SqlCommand("sp_fetch_tblLead_Sources", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@source_id", 0); 

            List<LeadSourceModel> lst = new List<LeadSourceModel>();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                int sid = Convert.ToInt32(dr["source_id"].ToString());
                string sname = dr["source_name"].ToString();

                LeadSourceModel lsm = new LeadSourceModel()
                {
                    SourceId = sid,
                    SourceName = sname
                };
                lst.Add(lsm);
            }

            con.Close();
            return lst;
        }

        public void RestoreLeadSource(int sourceId)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblLead_Sources", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@command", "Restore");
            cmd.Parameters.AddWithValue("@source_id", sourceId);
            cmd.Parameters.AddWithValue("@source_name", "");
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateLeadSource(LeadSourceModel source)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblLead_Sources", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@command", "Update");
            cmd.Parameters.AddWithValue("@source_id", source.SourceId);
            cmd.Parameters.AddWithValue("@source_name", source.SourceName);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
