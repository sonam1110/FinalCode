using ERPSystem_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem_Services.Interfaces
{
     public interface ITrainingTopicServices
    {
        void AddTopic(TrainingTopicModel topic);
        void UpdateTopic(TrainingTopicModel topic);
        void DeleteTopic(int topicId);
        void RestoreTopic(int topicId);

        List<TrainingTopicModel> GetTopics();
        TrainingTopicModel GetTopic(int topicId);
    }
}
