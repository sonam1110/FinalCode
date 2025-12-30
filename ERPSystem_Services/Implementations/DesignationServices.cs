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
    public class DesignationServices : IDesignationServices
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public DesignationServices()
        {
            con = new SqlConnection(DatabaseOperations.ConnectionString);
        }

        public void AddDesignation(DesignationModel designation)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblDesignations", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@command", "Insert");
            cmd.Parameters.AddWithValue("@designation_id", designation.DesignationId);
            cmd.Parameters.AddWithValue("@designation_name", designation.DesignationName);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteDesignation(int designationId)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblDesignations", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@command", "Delete");
            cmd.Parameters.AddWithValue("@designation_id", designationId);
            cmd.Parameters.AddWithValue("@designation_name", "");
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DesignationModel GetDesignation(int designationId)
        {
            return GetDesignations().FirstOrDefault(e => e.DesignationId.Equals(designationId));
        }

        public List<DesignationModel> GetDesignations()
        {
            con.Open();
            cmd = new SqlCommand("sp_fetch_tblDesignations", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@designation_id", 0);

            List<DesignationModel> lst = new List<DesignationModel>();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                int did = Convert.ToInt32(dr["designation_id"].ToString());
                string dname = dr["designation_name"].ToString();

                DesignationModel dm = new DesignationModel()
                {
                    DesignationId = did,
                    DesignationName = dname
                };
                lst.Add(dm);
            }

            con.Close();
            return lst;
        }

        public void RestoreDesignation(int designationId)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblDesignations", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@command", "Restore");
            cmd.Parameters.AddWithValue("@designation_id", designationId);
            cmd.Parameters.AddWithValue("@designation_name", "");
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateDesignation(DesignationModel designation)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblDesignations", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@command", "Update");
            cmd.Parameters.AddWithValue("@designation_id", designation.DesignationId);
            cmd.Parameters.AddWithValue("@designation_name", designation.DesignationName);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
