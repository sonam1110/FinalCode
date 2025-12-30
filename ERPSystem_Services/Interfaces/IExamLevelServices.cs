using ERPSystem_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem_Services.Interfaces
{
    public interface IExamLevelServices
    {
        void AddExamLevel(ExamLevelModel examLevel);
        void UpdateExamLevel(ExamLevelModel examLevel);
        void DeleteExamLevel(int examLevelId);
        void RestoreExamLevel(int examLevelId);

        List<ExamLevelModel> GetExamLevels();
        ExamLevelModel GetExamLevel(int examLevelId);
    }
}
