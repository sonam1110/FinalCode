using ERPSystem_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem_Services.Interfaces
{
     public interface ITopicContentServices
    {
        void AddTopicContent(TopicContentModel content);
        void UpdateTopicContent(TopicContentModel content);
        void DeleteTopicContent(int contentId);
        void RestoreTopicContent(int contentId);

        List<TopicContentModel> GetTopicContents();
        TopicContentModel GetTopicContent(int contentId);
    }
}
