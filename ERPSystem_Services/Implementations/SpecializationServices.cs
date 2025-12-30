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
    public class SpecializationServices : ISpecializationServices
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public SpecializationServices()
        {
            con = new SqlConnection(DatabaseOperations.ConnectionString);
        }
        public void AddSpecialization(SpecializationModel specialization)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblSpecializations", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@type", "Insert");
            cmd.Parameters.AddWithValue("@specialization_id", specialization.SpecializationId);
            cmd.Parameters.AddWithValue("@specialization_name", specialization.SpecializationName);
            cmd.Parameters.AddWithValue("@qualification_id", specialization.QualificationId);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteSpecialization(int specializationId)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblSpecializations", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@type", "Delete");
            cmd.Parameters.AddWithValue("@specialization_id", specializationId);
            cmd.Parameters.AddWithValue("@specialization_name", "");
            cmd.Parameters.AddWithValue("@qualification_id", 0);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public SpecializationModel GetSpecialization(int specializationId)
        {
            return GetSpecializations().FirstOrDefault(e => e.SpecializationId.Equals(specializationId));
        }

        public List<SpecializationModel> GetSpecializations()
        {
            con.Open();
            cmd = new SqlCommand("sp_fetch_tblSpecializations", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@specialization_id", 0);
            List<SpecializationModel> lst = new List<SpecializationModel>();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int spid = Convert.ToInt32(dr["specialization_id"]);
                string spname = dr["specialization_name"].ToString();
                int qid = Convert.ToInt32(dr["qualification_id"]);
                string qname = dr["qualification_name"].ToString();

                SpecializationModel spm = new SpecializationModel()
                {
                    SpecializationId = spid,
                    SpecializationName = spname,
                    QualificationId = qid,
                    QualificationName = qname
                };
                lst.Add(spm);
            }
            con.Close();
            return lst;
        }

        public void RestoreSpecialization(int specializationId)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblSpecializations", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@type", "Restore");
            cmd.Parameters.AddWithValue("@specialization_id", specializationId);
            cmd.Parameters.AddWithValue("@specialization_name", "");
            cmd.Parameters.AddWithValue("@qualification_id", 0);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateSpecialization(SpecializationModel specialization)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblSpecializations", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@type", "Update");
            cmd.Parameters.AddWithValue("@specialization_id", specialization.SpecializationId);
            cmd.Parameters.AddWithValue("@specialization_name", specialization.SpecializationName);
            cmd.Parameters.AddWithValue("@qualification_id", specialization.QualificationId);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
