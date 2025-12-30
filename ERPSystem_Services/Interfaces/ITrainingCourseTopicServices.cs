using ERPSystem_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem_Services.Interfaces
{
     public interface ITrainingCourseTopicServices
    {
        void AddCourseTopic(TrainingCourseTopicModel courseTopic);
        void UpdateCourseTopic(TrainingCourseTopicModel courseTopic);
        void DeleteCourseTopic(int courseTopicId);
        void RestoreCourseTopic(int courseTopicId);

        List<TrainingCourseTopicModel> GetCourseTopics();
        TrainingCourseTopicModel GetCourseTopic(int courseTopicId);
    }
}
