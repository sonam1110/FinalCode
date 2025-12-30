using ERPSystem_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem_Services.Interfaces
{
    public interface IStudentBreakDetailServices
    {
        void AddBreakDetail(StudentBreakDetailModel breakDetail);
        void UpdateBreakDetail(StudentBreakDetailModel breakDetail);
        void DeleteBreakDetail(int breakDetailId);
        void RestoreBreakDetail(int breakDetailId);

        List<StudentBreakDetailModel> GetBreakDetails();
        StudentBreakDetailModel GetBreakDetail(int breakDetailId);

    }
}
