using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem_Models
{
    public class TrainingCourseTopicModel
    {
        public int CourseTopicId { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int TopicId { get; set; }
        public string TopicName { get; set; }
    }
}
