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
    public class TechnologyServices : ITechnologyServices
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public TechnologyServices()
        {
            con = new SqlConnection(DatabaseOperations.ConnectionString);
        }

        public void AddTechnology(TechnologyModel technology)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblTechnologies", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@command", "Insert");
            cmd.Parameters.AddWithValue("@technology_id", technology.TechnologyId);
            cmd.Parameters.AddWithValue("@technology_name", technology.TechnologyName);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteTechnology(int technologyId)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblTechnologies", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@command", "Delete");
            cmd.Parameters.AddWithValue("@technology_id", technologyId);
            cmd.Parameters.AddWithValue("@technology_name", "");
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public List<TechnologyModel> GetTechnologies()
        {
            con.Open();
            cmd = new SqlCommand("sp_fetch_tblTechnologies", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@technology_id", 0); 

            List<TechnologyModel> lst = new List<TechnologyModel>();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                int tid = Convert.ToInt32(dr["technology_id"].ToString());
                string tname = dr["technology_name"].ToString();

                TechnologyModel tm = new TechnologyModel()
                {
                    TechnologyId = tid,
                    TechnologyName = tname
                };
                lst.Add(tm);
            }
            con.Close();
            return lst;
        }

        public TechnologyModel GetTechnology(int technologyId)
        {
            return GetTechnologies().FirstOrDefault(e => e.TechnologyId.Equals(technologyId));
        }

        public void RestoreTechnology(int technologyId)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblTechnologies", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@command", "Restore");
            cmd.Parameters.AddWithValue("@technology_id", technologyId);
            cmd.Parameters.AddWithValue("@technology_name", "");
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateTechnology(TechnologyModel technology)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblTechnologies", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@command", "Update");
            cmd.Parameters.AddWithValue("@technology_id", technology.TechnologyId);
            cmd.Parameters.AddWithValue("@technology_name", technology.TechnologyName);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
