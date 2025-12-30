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
    public class GenderServices : IGenderServices
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public GenderServices()
        {
            con = new SqlConnection(DatabaseOperations.ConnectionString);
        }


        public void AddGender(GenderModel gender)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblGenders", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@command", "Insert");
            cmd.Parameters.AddWithValue("@gender_id", gender.GenderId);
            cmd.Parameters.AddWithValue("@gender_name", gender.GenderName);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteGender(int genderId)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblGenders", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@command", "Delete");
            cmd.Parameters.AddWithValue("@gender_id", genderId);
            cmd.Parameters.AddWithValue("@gender_name", "");
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public GenderModel GetGender(int genderId)
        {
            return GetGenders().FirstOrDefault(e => e.GenderId.Equals(genderId));
        }

        public List<GenderModel> GetGenders()
        {
            con.Open();
            cmd = new SqlCommand("sp_fetch_tblGenders", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@gender_id", 0);

            List<GenderModel> lst = new List<GenderModel>();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                int gid = Convert.ToInt32(dr["gender_id"].ToString());
                string gname = dr["gender_name"].ToString();

                GenderModel gm = new GenderModel()
                {
                    GenderId = gid,
                    GenderName = gname
                };
                lst.Add(gm);
            }

            con.Close();
            return lst;
        }

        public void RestoreGender(int genderId)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblGenders", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@command", "Restore");
            cmd.Parameters.AddWithValue("@gender_id", genderId);
            cmd.Parameters.AddWithValue("@gender_name", "");
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateGender(GenderModel gender)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblGenders", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@command", "Update");
            cmd.Parameters.AddWithValue("@gender_id", gender.GenderId);
            cmd.Parameters.AddWithValue("@gender_name", gender.GenderName);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
