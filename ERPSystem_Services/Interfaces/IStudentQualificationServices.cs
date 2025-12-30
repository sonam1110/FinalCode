using ERPSystem_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem_Services.Interfaces
{
    public interface IStudentQualificationServices
    {
        void AddStudentQualification(StudentQualificationModel studentQualification);
        void UpdateStudentQualification(StudentQualificationModel studentQualification);
        void DeleteStudentQualification(int studentQualificationId);
        void RestoreStudentQualification(int studentQualificationId);

        List<StudentQualificationModel> GetStudentQualifications();
        StudentQualificationModel GetStudentQualification(int studentQualificationId);
    }
}
