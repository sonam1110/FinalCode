using ERPSystem_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem_Services.Interfaces
{
    public interface IStudentDetailServices
    {
        void AddStudentDetail(StudentDetailModel student);
        void UpdateStudentDetail(StudentDetailModel student);
        void DeleteStudentDetail(int studentId);
        void RestoreStudentDetail(int studentId);

        List<StudentDetailModel> GetStudentDetails();
        StudentDetailModel GetStudentDetail(int studentId);

    }
}
