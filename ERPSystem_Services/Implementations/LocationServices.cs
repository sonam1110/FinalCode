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
    public class LocationServices : ILocationServices
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public LocationServices()
        {
            con = new SqlConnection(DatabaseOperations.ConnectionString);
        }
        public void AddLocation(LocationModel location)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblLocations", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@type", "Insert");
            cmd.Parameters.AddWithValue("@location_id", location.LocationId);
            cmd.Parameters.AddWithValue("@location_name", location.LocationName);
            cmd.Parameters.AddWithValue("@city_id", location.CityId);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteLocation(int locationId)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblLocations", con);
            cmd.CommandType =CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@type", "Delete");
            cmd.Parameters.AddWithValue("@location_id", locationId);
            cmd.Parameters.AddWithValue("@location_name", "");
            cmd.Parameters.AddWithValue("@city_id", 0);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public LocationModel GetLocation(int locationId)
        {
            return GetLocations().FirstOrDefault(e => e.LocationId.Equals(locationId));
        }

        public List<LocationModel> GetLocations()
        {
            con.Open();
            cmd = new SqlCommand("sp_fetch_tblLocations", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@location_id", 0);
            List<LocationModel> lst = new List<LocationModel>();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int lid = Convert.ToInt32(dr["location_id"].ToString());
                string lname = dr["location_name"].ToString();
                int cid = Convert.ToInt32(dr["city_id"].ToString());
                string cname = dr["city_name"].ToString();
                LocationModel lm = new LocationModel()
                {
                    LocationId = lid,
                    LocationName = lname,
                    CityId=cid,
                    CityName=cname
                };
                lst.Add(lm);
            }
            con.Close();
            return lst;
        }

        public void RestoreLocation(int locationId)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblLocations", con);
            cmd.CommandType =CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@type", "Restore");
            cmd.Parameters.AddWithValue("@location_id", locationId);
            cmd.Parameters.AddWithValue("@location_name", "");
            cmd.Parameters.AddWithValue("@city_id", 0);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateLocation(LocationModel location)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblLocations", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@type", "Update");
            cmd.Parameters.AddWithValue("@location_id", location.LocationId);
            cmd.Parameters.AddWithValue("@location_name", location.LocationName);
            cmd.Parameters.AddWithValue("@city_id", location.CityId);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
