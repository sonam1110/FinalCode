using ERPSystem_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem_Services.Interfaces
{
    public interface IStudentLoginActivitiyServices
    {
        void AddLoginActivity(StudentLoginActivityModel activity);
        void UpdateLoginActivity(StudentLoginActivityModel activity);
        void DeleteLoginActivity(int activityId);
        void RestoreLoginActivity(int activityId);

        List<StudentLoginActivityModel> GetLoginActivities();
        StudentLoginActivityModel GetLoginActivity(int activityId);
    }
}
