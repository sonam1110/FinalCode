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
    public class QualificationServices : IQualificationServices
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public QualificationServices()
        {
            con = new SqlConnection(DatabaseOperations.ConnectionString);
        }
        public void AddQualification(QualificationModel qualification)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblQualifications", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@command", "Insert");
            cmd.Parameters.AddWithValue("@qualification_id", qualification.QualificationId);
            cmd.Parameters.AddWithValue("@qualification_name", qualification.QualificationName);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteQualification(int qualificationId)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblQualifications", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@command", "Delete");
            cmd.Parameters.AddWithValue("@qualification_id", qualificationId);
            cmd.Parameters.AddWithValue("@qualification_name", "");  

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public QualificationModel GetQualification(int qualificationId)
        {
            return GetQualifications().FirstOrDefault(e => e.QualificationId.Equals(qualificationId));
        }

        public List<QualificationModel> GetQualifications()
        {
            List<QualificationModel> lst = new List<QualificationModel>();

            con.Open();
            cmd = new SqlCommand("sp_fetch_tblQualifications", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@qualification_id", 0);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int qid = Convert.ToInt32(dr["qualification_id"]);
                string qname = dr["qualification_name"].ToString();

                QualificationModel qm = new QualificationModel()
                {
                    QualificationId = qid,
                    QualificationName = qname
                };
                lst.Add(qm);
            }
            con.Close();
            return lst;
        }

        public void RestoreQualification(int qualificationId)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblQualifications", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@command", "Restore");
            cmd.Parameters.AddWithValue("@qualification_id", qualificationId);
            cmd.Parameters.AddWithValue("@qualification_name", ""); 

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateQualification(QualificationModel qualification)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblQualifications", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@command", "Update");
            cmd.Parameters.AddWithValue("@qualification_id", qualification.QualificationId);
            cmd.Parameters.AddWithValue("@qualification_name", qualification.QualificationName);

            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
