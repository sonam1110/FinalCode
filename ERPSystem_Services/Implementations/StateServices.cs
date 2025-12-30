using ERPSystem_Models;
using ERPSystem_Services.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;


namespace ERPSystem_Services.Implementations
{
    public class StateServices : IStateServices
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public StateServices()
        {
            con=new SqlConnection(DatabaseOperations.ConnectionString);
        }
        public void AddState(StateModel state)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblStates", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@type", "Insert");
            cmd.Parameters.AddWithValue("@state_id", state.StateId);
            cmd.Parameters.AddWithValue("@state_name", state.StateName);
            cmd.ExecuteNonQuery();
            con.Close();
           
        }

        public void DeleteState(int stateId)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblStates", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@type", "Delete");
            cmd.Parameters.AddWithValue("@state_id", stateId);
            cmd.Parameters.AddWithValue("@state_name", "");
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public StateModel GetState(int stateId)
        {
            //con.Open();
            //cmd = new SqlCommand("sp_fetch_tblStates", con);
            //cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@state_id", stateId);
            //List<StateModel> lst = new List<StateModel>();
            //dr = cmd.ExecuteReader();
            //while (dr.Read())
            //{
            //    int sid = Convert.ToInt32(dr["StateId"].ToString());
            //    string sname = dr["StateName"].ToString();
            //    StateModel sm = new StateModel()
            //    {
            //        StateId = sid,
            //        StateName = sname
            //    };
            //    lst.Add(sm);
            //}
            //con.Close();
            //return lst.First();
            return GetStates().FirstOrDefault(e => e.StateId.Equals(stateId));
        }

        public List<StateModel> GetStates()
        {
            con.Open();
            cmd = new SqlCommand("sp_fetch_tblStates", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@state_id", 0);
            List<StateModel> lst = new List<StateModel>();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int sid = Convert.ToInt32(dr["state_id"].ToString());
                string sname = dr["state_name"].ToString();
                StateModel sm = new StateModel()
                {
                    StateId = sid,
                    StateName = sname
                };
                lst.Add(sm);
            }
            con.Close();
            return lst;
        }

        public void RestoreState(int stateId)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblStates", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@type", "Restore");
            cmd.Parameters.AddWithValue("@state_id", stateId);
            cmd.Parameters.AddWithValue("@state_name", "");
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateState(StateModel state)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblStates", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@type", "Update");
            cmd.Parameters.AddWithValue("@state_id", state.StateId);
            cmd.Parameters.AddWithValue("@state_name", state.StateName);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
