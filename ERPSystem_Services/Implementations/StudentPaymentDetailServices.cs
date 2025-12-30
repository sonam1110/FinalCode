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
    public class StudentPaymentDetailServices : IStudentPaymentDetailServices
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public StudentPaymentDetailServices()
        {
            con = new SqlConnection(DatabaseOperations.ConnectionString);
        }
        public void AddStudentPaymentDetail(StudentPaymentDetailModel paymentDetail)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblStudent_payment_Details", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@command", "Insert");
            cmd.Parameters.AddWithValue("@payment_id", paymentDetail.PaymentId);
            cmd.Parameters.AddWithValue("@registration_id", paymentDetail.RegistrationId);
            cmd.Parameters.AddWithValue("@payment_date", paymentDetail.PaymentDate);
            cmd.Parameters.AddWithValue("@payment_amount", paymentDetail.PaymentAmount);
            cmd.Parameters.AddWithValue("@payment_mode", paymentDetail.PaymentMode);
            cmd.Parameters.AddWithValue("@description", paymentDetail.Description);
            cmd.Parameters.AddWithValue("@employee_id", paymentDetail.EmployeeId);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteStudentPaymentDetail(int paymentId)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblStudent_payment_Details", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@command", "Delete");
            cmd.Parameters.AddWithValue("@payment_id", paymentId);
            cmd.Parameters.AddWithValue("@registration_id", 0);
            cmd.Parameters.AddWithValue("@payment_date", "");
            cmd.Parameters.AddWithValue("@payment_amount", 0);
            cmd.Parameters.AddWithValue("@payment_mode", "");
            cmd.Parameters.AddWithValue("@description", "");
            cmd.Parameters.AddWithValue("@employee_id", 0);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public StudentPaymentDetailModel GetStudentPaymentDetail(int paymentId)
        {
            return GetStudentPaymentDetails().FirstOrDefault(p => p.PaymentId.Equals(paymentId));

        }

        public List<StudentPaymentDetailModel> GetStudentPaymentDetails()
        {
            List<StudentPaymentDetailModel> lst = new List<StudentPaymentDetailModel>();

            con.Open();
            cmd = new SqlCommand("sp_fetch_tblstudent_payment_details", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@payment_id", 0);

            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                StudentPaymentDetailModel pay = new StudentPaymentDetailModel();
                pay.PaymentId = Convert.ToInt32(dr["payment_id"].ToString());
                pay.RegistrationId = Convert.ToInt32(dr["registration_id"].ToString());
                pay.RegistrationCode = dr["registration_code"].ToString();
                pay.PaymentDate = Convert.ToDateTime(dr["payment_date"].ToString());
                pay.PaymentAmount = (float)Convert.ToDouble(dr["payment_amount"].ToString());
                pay.PaymentMode = dr["payment_mode"].ToString();
                pay.Description = dr["description"].ToString();
                pay.EmployeeId = Convert.ToInt32(dr["employee_id"].ToString());
                pay.EmployeeFirstName = dr["employee_first_name"].ToString();
                pay.EmployeeLastName = dr["employee_last_name"].ToString();

                lst.Add(pay);
            }
            con.Close();
            return lst;
        }

        public void RestoreStudentPaymentDetail(int paymentId)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblStudent_payment_Details", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@command", "Restore");
            cmd.Parameters.AddWithValue("@payment_id", paymentId);
            cmd.Parameters.AddWithValue("@registration_id", 0);
            cmd.Parameters.AddWithValue("@payment_date", "");
            cmd.Parameters.AddWithValue("@payment_amount", 0);
            cmd.Parameters.AddWithValue("@payment_mode", "");
            cmd.Parameters.AddWithValue("@description", "");
            cmd.Parameters.AddWithValue("@employee_id", 0);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateStudentPaymentDetail(StudentPaymentDetailModel paymentDetail)
        {
            con.Open();
            cmd = new SqlCommand("sp_tblStudent_payment_Details", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@command", "Update");
            cmd.Parameters.AddWithValue("@payment_id", paymentDetail.PaymentId);
            cmd.Parameters.AddWithValue("@registration_id", paymentDetail.RegistrationId);
            cmd.Parameters.AddWithValue("@payment_date", paymentDetail.PaymentDate);
            cmd.Parameters.AddWithValue("@payment_amount", paymentDetail.PaymentAmount);
            cmd.Parameters.AddWithValue("@payment_mode", paymentDetail.PaymentMode);
            cmd.Parameters.AddWithValue("@description", paymentDetail.Description);
            cmd.Parameters.AddWithValue("@employee_id", paymentDetail.EmployeeId);

            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
