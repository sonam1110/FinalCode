using ERPSystem_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem_Services.Interfaces
{
    public interface IQualificationServices
    {
        void AddQualification(QualificationModel qualification);
        void UpdateQualification(QualificationModel qualification);
        void DeleteQualification(int qualificationId);
        void RestoreQualification(int qualificationId);

        List<QualificationModel> GetQualifications();
        QualificationModel GetQualification(int qualificationId);
    }
}
