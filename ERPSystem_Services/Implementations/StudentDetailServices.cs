using ERPSystem_Models;
using ERPSystem_Services.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ERPSystem_Services.Implementations
{
    public class StudentDetailServices : IStudentDetailServices
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public StudentDetailServices()
        {
            con = new SqlConnection(DatabaseOperations.ConnectionString);
        }

        public void AddStudentDetail(StudentDetailModel student)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblStudent_details", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@command", "Insert");
            cmd.Parameters.AddWithValue("@student_id", student.StudentId);
            cmd.Parameters.AddWithValue("@student_code", student.StudentCode);
            cmd.Parameters.AddWithValue("@first_name", student.FirstName);
            cmd.Parameters.AddWithValue("@middle_name", student.MiddleName);
            cmd.Parameters.AddWithValue("@last_name", student.LastName);
            cmd.Parameters.AddWithValue("@email_address", student.EmailAddress);
            cmd.Parameters.AddWithValue("@mobile_number", student.MobileNumber);
            cmd.Parameters.AddWithValue("@alternative_number", student.AlternativeNumber);
            cmd.Parameters.AddWithValue("@photo", student.Photo);
            cmd.Parameters.AddWithValue("@birth_date", student.BirthDate);
            cmd.Parameters.AddWithValue("@password", student.Password);
            cmd.Parameters.AddWithValue("@location_id", student.LocationId);
            cmd.Parameters.AddWithValue("@local_address", student.LocalAddress);
            cmd.Parameters.AddWithValue("@permenant_address", student.PermenantAddress);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteStudentDetail(int studentId)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblStudent_details", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@command", "Delete");
            cmd.Parameters.AddWithValue("@student_id", studentId);
            cmd.Parameters.AddWithValue("@student_code", "");
            cmd.Parameters.AddWithValue("@first_name", "");
            cmd.Parameters.AddWithValue("@middle_name", "");
            cmd.Parameters.AddWithValue("@last_name", "");
            cmd.Parameters.AddWithValue("@email_address", "");
            cmd.Parameters.AddWithValue("@mobile_number", "");
            cmd.Parameters.AddWithValue("@alternative_number", "");
            cmd.Parameters.AddWithValue("@photo", "");
            cmd.Parameters.AddWithValue("@birth_date", "");
            cmd.Parameters.AddWithValue("@password", "");
            cmd.Parameters.AddWithValue("@location_id", 0);
            cmd.Parameters.AddWithValue("@local_address", "");
            cmd.Parameters.AddWithValue("@permenant_address", "");

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public StudentDetailModel GetStudentDetail(int studentId)
        {
            return GetStudentDetails().FirstOrDefault(e => e.StudentId == studentId);
        }

        public List<StudentDetailModel> GetStudentDetails()
        {
            con.Open();
            cmd = new SqlCommand("sp_fetch_tblStudent_details", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@student_id", 0);

            List<StudentDetailModel> lst = new List<StudentDetailModel>();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int sid = Convert.ToInt32(dr["student_id"].ToString());
                string scode = dr["student_code"].ToString();
                string fname = dr["first_name"].ToString();
                string mname = dr["middle_name"].ToString();
                string lname = dr["last_name"].ToString();
                string email = dr["email_address"].ToString();
                string mobile = dr["mobile_number"].ToString();
                string altmobile = dr["alternative_number"].ToString();
                string photo = dr["photo"].ToString();
                DateTime bdate = Convert.ToDateTime(dr["birth_date"].ToString());
                string pass = dr["password"].ToString();
                int locid = Convert.ToInt32(dr["location_id"].ToString());
                string localaddr = dr["local_address"].ToString();
                string permaddr = dr["permenant_address"].ToString();

                StudentDetailModel s = new StudentDetailModel()
                {
                    StudentId = sid,
                    StudentCode = scode,
                    FirstName = fname,
                    MiddleName = mname,
                    LastName = lname,
                    EmailAddress = email,
                    MobileNumber = mobile,
                    AlternativeNumber = altmobile,
                    Photo = photo,
                    BirthDate = bdate,
                    Password = pass,
                    LocationId = locid,
                    LocalAddress = localaddr,
                    PermenantAddress = permaddr
                };

                lst.Add(s);
            }

            con.Close();
            return lst;
        }
        public void RestoreStudentDetail(int studentId)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblStudent_details", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@command", "Restore");
            cmd.Parameters.AddWithValue("@student_id", studentId);
            cmd.Parameters.AddWithValue("@student_code", "");
            cmd.Parameters.AddWithValue("@first_name", "");
            cmd.Parameters.AddWithValue("@middle_name", "");
            cmd.Parameters.AddWithValue("@last_name", "");
            cmd.Parameters.AddWithValue("@email_address", "");
            cmd.Parameters.AddWithValue("@mobile_number", "");
            cmd.Parameters.AddWithValue("@alternative_number", "");
            cmd.Parameters.AddWithValue("@photo", "");
            cmd.Parameters.AddWithValue("@birth_date", "");
            cmd.Parameters.AddWithValue("@password", "");
            cmd.Parameters.AddWithValue("@location_id", 0);
            cmd.Parameters.AddWithValue("@local_address", "");
            cmd.Parameters.AddWithValue("@permenant_address", "");

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateStudentDetail(StudentDetailModel student)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblStudent_details", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@command", "Update");
            cmd.Parameters.AddWithValue("@student_id", student.StudentId);
            cmd.Parameters.AddWithValue("@student_code", student.StudentCode);
            cmd.Parameters.AddWithValue("@first_name", student.FirstName);
            cmd.Parameters.AddWithValue("@middle_name", student.MiddleName);
            cmd.Parameters.AddWithValue("@last_name", student.LastName);
            cmd.Parameters.AddWithValue("@email_address", student.EmailAddress);
            cmd.Parameters.AddWithValue("@mobile_number", student.MobileNumber);
            cmd.Parameters.AddWithValue("@alternative_number", student.AlternativeNumber);
            cmd.Parameters.AddWithValue("@photo", student.Photo);
            cmd.Parameters.AddWithValue("@birth_date", student.BirthDate);
            cmd.Parameters.AddWithValue("@password", student.Password);
            cmd.Parameters.AddWithValue("@location_id", student.LocationId);
            cmd.Parameters.AddWithValue("@local_address", student.LocalAddress);
            cmd.Parameters.AddWithValue("@permenant_address", student.PermenantAddress);

            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
