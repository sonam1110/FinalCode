using ERPSystem_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem_Services.Interfaces
{
    public interface IStudentPaymentDetailServices
    {
        void AddStudentPaymentDetail(StudentPaymentDetailModel paymentDetail);
        void UpdateStudentPaymentDetail(StudentPaymentDetailModel paymentDetail);
        void DeleteStudentPaymentDetail(int paymentId);
        void RestoreStudentPaymentDetail(int paymentId);

        List<StudentPaymentDetailModel> GetStudentPaymentDetails();
        StudentPaymentDetailModel GetStudentPaymentDetail(int paymentId);

    }
}
