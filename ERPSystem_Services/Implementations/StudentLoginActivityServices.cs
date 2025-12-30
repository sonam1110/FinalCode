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
    public class StudentLoginActivityServices : IStudentLoginActivitiyServices
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public StudentLoginActivityServices()
        {
            con = new SqlConnection(DatabaseOperations.ConnectionString);
        }
        public void AddLoginActivity(StudentLoginActivityModel activity)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblStudent_Login_Activities", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@command", "Insert");
            cmd.Parameters.AddWithValue("@activity_id", activity.ActivityId);
            cmd.Parameters.AddWithValue("@student_id", activity.StudentId);
            cmd.Parameters.AddWithValue("@login_time", activity.LoginTime);
            cmd.Parameters.AddWithValue("@logout_time", activity.LogoutTime);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteLoginActivity(int activityId)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblStudent_Login_Activities", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@command", "Delete");
            cmd.Parameters.AddWithValue("@activity_id", activityId);
            cmd.Parameters.AddWithValue("@student_id", 0);
            cmd.Parameters.AddWithValue("@login_time", "");
            cmd.Parameters.AddWithValue("@logout_time", "");

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public List<StudentLoginActivityModel> GetLoginActivities()
        {
            List<StudentLoginActivityModel> lst = new List<StudentLoginActivityModel>();

            con.Open();
            cmd = new SqlCommand("sp_fetch_tblstudent_login_activities", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@activity_id", 0);

            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                StudentLoginActivityModel model = new StudentLoginActivityModel();
                model.ActivityId = Convert.ToInt32(dr["activity_id"].ToString());
                model.StudentId = Convert.ToInt32(dr["student_id"].ToString());
                model.FirstName = dr["first_name"].ToString();
                model.LastName = dr["last_name"].ToString();
                model.LoginTime = Convert.ToDateTime(dr["login_time"].ToString());
                model.LogoutTime = Convert.ToDateTime(dr["logout_time"].ToString());

                lst.Add(model);
            }
            con.Close();
            return lst;
        }

        public StudentLoginActivityModel GetLoginActivity(int activityId)
        {
            return GetLoginActivities().FirstOrDefault(e => e.ActivityId.Equals(activityId));
        }

        public void RestoreLoginActivity(int activityId)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblStudent_Login_Activities", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@command", "Restore");
            cmd.Parameters.AddWithValue("@activity_id", activityId);
            cmd.Parameters.AddWithValue("@student_id", 0);
            cmd.Parameters.AddWithValue("@login_time", "");
            cmd.Parameters.AddWithValue("@logout_time", "");

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateLoginActivity(StudentLoginActivityModel activity)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblStudent_Login_Activities", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@command", "Update");
            cmd.Parameters.AddWithValue("@activity_id", activity.ActivityId);
            cmd.Parameters.AddWithValue("@student_id", activity.StudentId);
            cmd.Parameters.AddWithValue("@login_time", activity.LoginTime);
            cmd.Parameters.AddWithValue("@logout_time", activity.LogoutTime);

            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
