using ERPSystem_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem_Services.Interfaces
{
    public interface IStudentRegistrationDetailServices
    {
        void AddStudentRegistration(StudentRegistrationDetailModel registration);
        void UpdateStudentRegistration(StudentRegistrationDetailModel registration);
        void DeleteStudentRegistration(int registrationId);
        void RestoreStudentRegistration(int registrationId);

        List<StudentRegistrationDetailModel> GetStudentRegistrations();
        StudentRegistrationDetailModel GetStudentRegistration(int registrationId);
    }
}
