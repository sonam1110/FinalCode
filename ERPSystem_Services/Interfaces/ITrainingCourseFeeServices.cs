using ERPSystem_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem_Services.Interfaces
{
    public interface ITrainingCourseFeeServices
    {
        void AddCourseFee(TrainingCourseFeeModel fee);
        void UpdateCourseFee(TrainingCourseFeeModel fee);
        void DeleteCourseFee(int feeId);
        void RestoreCourseFee(int feeId);

        List<TrainingCourseFeeModel> GetCourseFees();
        TrainingCourseFeeModel GetCourseFee(int feeId);
    }
}
