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
    public class StudentQualificationServices : IStudentQualificationServices
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public StudentQualificationServices()
        {
            con = new SqlConnection(DatabaseOperations.ConnectionString);
        }
        public void AddStudentQualification(StudentQualificationModel studentQualification)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblStudent_Qualifications", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@command", "Insert");
            cmd.Parameters.AddWithValue("@student_qualification_id", studentQualification.StudentQualificationId);
            cmd.Parameters.AddWithValue("@student_id", studentQualification.StudentId);
            cmd.Parameters.AddWithValue("@specialization_id", studentQualification.SpecializationId);
            cmd.Parameters.AddWithValue("@medium", studentQualification.Medium);
            cmd.Parameters.AddWithValue("@passing_year", studentQualification.PassingYear);
            cmd.Parameters.AddWithValue("@percentage", studentQualification.Percentage);
            cmd.Parameters.AddWithValue("@university", studentQualification.University);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteStudentQualification(int studentQualificationId)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblStudent_Qualifications", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@command", "Delete");
            cmd.Parameters.AddWithValue("@student_qualification_id", studentQualificationId);
            cmd.Parameters.AddWithValue("@student_id", 0);
            cmd.Parameters.AddWithValue("@specialization_id", 0);
            cmd.Parameters.AddWithValue("@medium", "");
            cmd.Parameters.AddWithValue("@passing_year", 0);
            cmd.Parameters.AddWithValue("@percentage", 0);
            cmd.Parameters.AddWithValue("@university", "");

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public StudentQualificationModel GetStudentQualification(int studentQualificationId)
        {
            return GetStudentQualifications().FirstOrDefault(e => e.StudentQualificationId.Equals(studentQualificationId));
        }

        public List<StudentQualificationModel> GetStudentQualifications()
        {
                List<StudentQualificationModel> lst = new List<StudentQualificationModel>();
                con.Open();
                cmd = new SqlCommand("sp_fetch_tblstudent_qualifications", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@student_qualification_id", 0);

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int qid = Convert.ToInt32(dr["student_qualification_id"].ToString());
                    int sid = Convert.ToInt32(dr["student_id"].ToString());
                    string fname = dr["first_name"].ToString();
                    string lname = dr["last_name"].ToString();
                    int spid = Convert.ToInt32(dr["specialization_id"].ToString());
                    string spname = dr["specialization_name"].ToString();
                    int qualId = Convert.ToInt32(dr["qualification_id"].ToString());
                    string qualName = dr["qualification_name"].ToString();
                    string medium = dr["medium"].ToString();
                    int passingYear = Convert.ToInt32(dr["passing_year"].ToString());
                    float percentage = float.Parse(dr["percentage"].ToString());
                    string university = dr["university"].ToString();

                    StudentQualificationModel sqm = new StudentQualificationModel()
                    {
                        StudentQualificationId = qid,
                        StudentId = sid,
                        FirstName = fname,
                        LastName = lname,
                        SpecializationId = spid,
                        SpecializationName = spname,
                        QualificationId = qualId,
                        QualificationName = qualName,
                        Medium = medium,
                        PassingYear = passingYear,
                        Percentage = percentage,
                        University = university
                    };
                    lst.Add(sqm);
                }
               con.Close();
               return lst;
        }

        public void RestoreStudentQualification(int studentQualificationId)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblStudent_Qualifications", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@command", "Restore");
            cmd.Parameters.AddWithValue("@student_qualification_id", studentQualificationId);
            cmd.Parameters.AddWithValue("@student_id", 0);
            cmd.Parameters.AddWithValue("@specialization_id", 0);
            cmd.Parameters.AddWithValue("@medium", "");
            cmd.Parameters.AddWithValue("@passing_year", 0);
            cmd.Parameters.AddWithValue("@percentage", 0);
            cmd.Parameters.AddWithValue("@university", "");

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateStudentQualification(StudentQualificationModel studentQualification)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblStudent_Qualifications", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@command", "Update");
            cmd.Parameters.AddWithValue("@student_qualification_id", studentQualification.StudentQualificationId);
            cmd.Parameters.AddWithValue("@student_id", studentQualification.StudentId);
            cmd.Parameters.AddWithValue("@specialization_id", studentQualification.SpecializationId);
            cmd.Parameters.AddWithValue("@medium", studentQualification.Medium);
            cmd.Parameters.AddWithValue("@passing_year", studentQualification.PassingYear);
            cmd.Parameters.AddWithValue("@percentage", studentQualification.Percentage);
            cmd.Parameters.AddWithValue("@university", studentQualification.University);

            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
