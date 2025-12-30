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
    public class StudentRegistrationDetailServices : IStudentRegistrationDetailServices
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public StudentRegistrationDetailServices()
        {
            con = new SqlConnection(DatabaseOperations.ConnectionString);
        }
        public void AddStudentRegistration(StudentRegistrationDetailModel registration)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblStudent_Registration_Details", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@command", "Insert");
            cmd.Parameters.AddWithValue("@registration_id", registration.RegistrationId);
            cmd.Parameters.AddWithValue("@registration_code", registration.RegistrationCode);
            cmd.Parameters.AddWithValue("@student_id", registration.StudentId);
            cmd.Parameters.AddWithValue("@course_id", registration.CourseId);
            cmd.Parameters.AddWithValue("@joining_date", registration.JoiningDate);
            cmd.Parameters.AddWithValue("@course_fee_id", registration.CourseFeeId);
            cmd.Parameters.AddWithValue("@discount", registration.Discount);
            cmd.Parameters.AddWithValue("@current_status", registration.CurrentStatus);
            cmd.Parameters.AddWithValue("@employee_id", registration.EmployeeId);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteStudentRegistration(int registrationId)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblStudent_Registration_Details", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@command", "Delete");
            cmd.Parameters.AddWithValue("@registration_id", registrationId);
            cmd.Parameters.AddWithValue("@registration_code", "");
            cmd.Parameters.AddWithValue("@student_id", 0);
            cmd.Parameters.AddWithValue("@course_id", 0);
            cmd.Parameters.AddWithValue("@joining_date", "");
            cmd.Parameters.AddWithValue("@course_fee_id", 0);
            cmd.Parameters.AddWithValue("@discount", 0);
            cmd.Parameters.AddWithValue("@current_status", "");
            cmd.Parameters.AddWithValue("@employee_id", 0);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public StudentRegistrationDetailModel GetStudentRegistration(int registrationId)
        {
            return GetStudentRegistrations().FirstOrDefault(e => e.RegistrationId.Equals(registrationId));
        }

        public List<StudentRegistrationDetailModel> GetStudentRegistrations()
        {
            List<StudentRegistrationDetailModel> lst = new List<StudentRegistrationDetailModel>();

            con.Open();
            cmd = new SqlCommand("sp_fetch_tblstudent_registration_details", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@registration_id", 0);

            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                StudentRegistrationDetailModel reg = new StudentRegistrationDetailModel();
                reg.RegistrationId = Convert.ToInt32(dr["registration_id"].ToString());
                reg.RegistrationCode = dr["registration_code"].ToString();
                reg.StudentId = Convert.ToInt32(dr["student_id"].ToString());
                reg.FirstName = dr["first_name"].ToString();
                reg.LastName = dr["last_name"].ToString();
                reg.CourseId = Convert.ToInt32(dr["course_id"].ToString());
                reg.CourseName = dr["course_name"].ToString();
                reg.JoiningDate = Convert.ToDateTime(dr["joining_date"].ToString());
                reg.CourseFeeId = Convert.ToInt32(dr["course_fee_id"].ToString());
                reg.Amount = (float)Convert.ToDouble(dr["amount"].ToString());
                reg.Discount = (float)Convert.ToDouble(dr["discount"].ToString());
                reg.CurrentStatus = dr["current_status"].ToString();
                reg.EmployeeId = Convert.ToInt32(dr["employee_id"].ToString());
                reg.EmployeeFirstName = dr["employee_first_name"].ToString();
                reg.EmployeeLastName = dr["employee_last_name"].ToString();

                lst.Add(reg);
            }
            con.Close();
            return lst;
        }

        public void RestoreStudentRegistration(int registrationId)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblStudent_Registration_Details", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@command", "Restore");
            cmd.Parameters.AddWithValue("@registration_id", registrationId);
            cmd.Parameters.AddWithValue("@registration_code", "");
            cmd.Parameters.AddWithValue("@student_id", 0);
            cmd.Parameters.AddWithValue("@course_id", 0);
            cmd.Parameters.AddWithValue("@joining_date", "");
            cmd.Parameters.AddWithValue("@course_fee_id", 0);
            cmd.Parameters.AddWithValue("@discount", 0);
            cmd.Parameters.AddWithValue("@current_status", "");
            cmd.Parameters.AddWithValue("@employee_id", 0);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateStudentRegistration(StudentRegistrationDetailModel registration)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblStudent_Registration_Details", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@command", "Update");
            cmd.Parameters.AddWithValue("@registration_id", registration.RegistrationId);
            cmd.Parameters.AddWithValue("@registration_code", registration.RegistrationCode);
            cmd.Parameters.AddWithValue("@student_id", registration.StudentId);
            cmd.Parameters.AddWithValue("@course_id", registration.CourseId);
            cmd.Parameters.AddWithValue("@joining_date", registration.JoiningDate);
            cmd.Parameters.AddWithValue("@course_fee_id", registration.CourseFeeId);
            cmd.Parameters.AddWithValue("@discount", registration.Discount);
            cmd.Parameters.AddWithValue("@current_status", registration.CurrentStatus);
            cmd.Parameters.AddWithValue("@employee_id", registration.EmployeeId);

            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
