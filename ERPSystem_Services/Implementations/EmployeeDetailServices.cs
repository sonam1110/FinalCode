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
    public class EmployeeDetailServices : IEmployeeDetailServices
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public EmployeeDetailServices()
        {
            con = new SqlConnection(DatabaseOperations.ConnectionString);
        }

        public void AddEmployeeDetail(EmployeeDetailModel employeeDetail)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblemployee_details", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@command", "Insert");
            cmd.Parameters.AddWithValue("@employee_id", employeeDetail.EmployeeId);
            cmd.Parameters.AddWithValue("@employee_code", employeeDetail.EmployeeCode);
            cmd.Parameters.AddWithValue("@first_name", employeeDetail.FirstName);
            cmd.Parameters.AddWithValue("@middle_name", employeeDetail.MiddleName);
            cmd.Parameters.AddWithValue("@last_name", employeeDetail.LastName);
            cmd.Parameters.AddWithValue("@birth_date", employeeDetail.BirthDate);
            cmd.Parameters.AddWithValue("@joining_date", employeeDetail.JoiningDate);
            cmd.Parameters.AddWithValue("@mobile_number", employeeDetail.MobileNumber);
            cmd.Parameters.AddWithValue("@email_address", employeeDetail.EmailAddress);
            cmd.Parameters.AddWithValue("@photo", employeeDetail.Photo);
            cmd.Parameters.AddWithValue("@designation_id", employeeDetail.DesignationId);
            cmd.Parameters.AddWithValue("@location_id", employeeDetail.LocationId);
            cmd.Parameters.AddWithValue("@permenant_address", employeeDetail.PermenantAddress);
            cmd.Parameters.AddWithValue("@local_address", employeeDetail.LocalAddress);
            cmd.Parameters.AddWithValue("@password", employeeDetail.Password);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteEmployeeDetail(int employeeDetailId)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblemployee_details", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@command", "Delete");
            cmd.Parameters.AddWithValue("@employee_id", employeeDetailId);
            cmd.Parameters.AddWithValue("@employee_code", "");
            cmd.Parameters.AddWithValue("@first_name", "");
            cmd.Parameters.AddWithValue("@middle_name", "");
            cmd.Parameters.AddWithValue("@last_name", "");
            cmd.Parameters.AddWithValue("@birth_date", "");
            cmd.Parameters.AddWithValue("@joining_date", "");
            cmd.Parameters.AddWithValue("@mobile_number", "");
            cmd.Parameters.AddWithValue("@email_address", "");
            cmd.Parameters.AddWithValue("@photo", "");
            cmd.Parameters.AddWithValue("@designation_id", 0);
            cmd.Parameters.AddWithValue("@location_id", 0);
            cmd.Parameters.AddWithValue("@permenant_address", "");
            cmd.Parameters.AddWithValue("@local_address", "");
            cmd.Parameters.AddWithValue("@password", "");

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public List<EmployeeDetailModel> GetEmployeeDetails()
        {
            List<EmployeeDetailModel> lst = new List<EmployeeDetailModel>();

            con.Open();
            cmd = new SqlCommand("sp_fetch_tblemployee_details", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@employee_id", 0);

            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                EmployeeDetailModel emp = new EmployeeDetailModel();
                emp.EmployeeId = Convert.ToInt32(dr["employee_id"].ToString());
                emp.EmployeeCode = dr["employee_code"].ToString();
                emp.FirstName = dr["first_name"].ToString();
                emp.MiddleName = dr["middle_name"].ToString();
                emp.LastName = dr["last_name"].ToString();
                emp.BirthDate = Convert.ToDateTime(dr["birth_date"].ToString());
                emp.JoiningDate = Convert.ToDateTime(dr["joining_date"].ToString());
                emp.MobileNumber = dr["mobile_number"].ToString();
                emp.EmailAddress = dr["email_address"].ToString();
                emp.Photo = dr["photo"].ToString();
                emp.DesignationId = Convert.ToInt32(dr["designation_id"].ToString());
                emp.DesignationName = dr["designation_name"].ToString();
                emp.LocationId = Convert.ToInt32(dr["location_id"].ToString());
                emp.LocationName = dr["location_name"].ToString();
                emp.PermenantAddress = dr["permenant_address"].ToString();
                emp.LocalAddress = dr["local_address"].ToString();
                emp.Password = dr["password"].ToString();

                lst.Add(emp);
            }
            con.Close();
            return lst;
        }

        public EmployeeDetailModel GetEmployeeDetails(int employeeDetailId)
        {
            return GetEmployeeDetails().FirstOrDefault(e => e.EmployeeId.Equals(employeeDetailId));
        }

        public void RestoreEmployeeDetail(int employeeDetailId)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblemployee_details", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@command", "Restore");
            cmd.Parameters.AddWithValue("@employee_id", employeeDetailId);
            cmd.Parameters.AddWithValue("@employee_code", "");
            cmd.Parameters.AddWithValue("@first_name", "");
            cmd.Parameters.AddWithValue("@middle_name", "");
            cmd.Parameters.AddWithValue("@last_name", "");
            cmd.Parameters.AddWithValue("@birth_date", "");
            cmd.Parameters.AddWithValue("@joining_date", "");
            cmd.Parameters.AddWithValue("@mobile_number", "");
            cmd.Parameters.AddWithValue("@email_address", "");
            cmd.Parameters.AddWithValue("@photo", "");
            cmd.Parameters.AddWithValue("@designation_id", 0);
            cmd.Parameters.AddWithValue("@location_id", 0);
            cmd.Parameters.AddWithValue("@permenant_address", "");
            cmd.Parameters.AddWithValue("@local_address", "");
            cmd.Parameters.AddWithValue("@password", "");

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateEmployeeDetail(EmployeeDetailModel employeeDetail)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblemployee_details", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@command", "Update");
            cmd.Parameters.AddWithValue("@employee_id", employeeDetail.EmployeeId);
            cmd.Parameters.AddWithValue("@employee_code", employeeDetail.EmployeeCode);
            cmd.Parameters.AddWithValue("@first_name", employeeDetail.FirstName);
            cmd.Parameters.AddWithValue("@middle_name", employeeDetail.MiddleName);
            cmd.Parameters.AddWithValue("@last_name", employeeDetail.LastName);
            cmd.Parameters.AddWithValue("@birth_date", employeeDetail.BirthDate);
            cmd.Parameters.AddWithValue("@joining_date", employeeDetail.JoiningDate);
            cmd.Parameters.AddWithValue("@mobile_number", employeeDetail.MobileNumber);
            cmd.Parameters.AddWithValue("@email_address", employeeDetail.EmailAddress);
            cmd.Parameters.AddWithValue("@photo", employeeDetail.Photo);
            cmd.Parameters.AddWithValue("@designation_id", employeeDetail.DesignationId);
            cmd.Parameters.AddWithValue("@location_id", employeeDetail.LocationId);
            cmd.Parameters.AddWithValue("@permenant_address", employeeDetail.PermenantAddress);
            cmd.Parameters.AddWithValue("@local_address", employeeDetail.LocalAddress);
            cmd.Parameters.AddWithValue("@password", employeeDetail.Password);

            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
