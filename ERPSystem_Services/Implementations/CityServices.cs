using ERPSystem_Models;
using ERPSystem_Services.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem_Services.Implementations
{
    public class CityServices : ICityServices
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public CityServices()
        {
            con = new SqlConnection(DatabaseOperations.ConnectionString);
        }
        public void AddCity(CityModel city)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblCities", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@type", "Insert");
            cmd.Parameters.AddWithValue("@city_id", city.CityId);
            cmd.Parameters.AddWithValue("@city_name", city.CityName);
            cmd.Parameters.AddWithValue("@state_id", city.StateId);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteCity(int cityId)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblCities", con);
            cmd.CommandType =CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@type", "Delete");
            cmd.Parameters.AddWithValue("@city_id", cityId);
            cmd.Parameters.AddWithValue("@city_name", "");
            cmd.Parameters.AddWithValue("@state_id","");
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public List<CityModel> GetCities()
        {
            con.Open();
            cmd = new SqlCommand("sp_fetch_tblCities", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@city_id", 0);
            List<CityModel> lst = new List<CityModel>();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int cid = Convert.ToInt32(dr["city_id"].ToString());
                string cname= dr["city_name"].ToString();
                int sid = Convert.ToInt32(dr["state_id"].ToString());
                string sname = dr["state_name"].ToString();
                
                CityModel cm = new CityModel()
                {
                    CityId=cid,
                    CityName=cname,
                    StateId = sid,
                    StateName = sname
                };
                lst.Add(cm);
            }
            con.Close();
            return lst;
        }

        public CityModel GetCity(int cityId)
        {
            return GetCities().FirstOrDefault(e => e.CityId.Equals(cityId));
        }

        public void RestoreCity(int cityId)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblCities", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@type", "Restore");
            cmd.Parameters.AddWithValue("@city_id",cityId);
            cmd.Parameters.AddWithValue("@city_name", "");
            cmd.Parameters.AddWithValue("@state_id","");
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateCity(CityModel city)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblCities", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@type", "Update");
            cmd.Parameters.AddWithValue("@city_id", city.CityId);
            cmd.Parameters.AddWithValue("@city_name", city.CityName);
            cmd.Parameters.AddWithValue("@state_id", city.StateId);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
