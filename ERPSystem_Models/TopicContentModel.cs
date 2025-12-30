using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem_Models
{
    public class TopicContentModel
    {
        public int ContentId { get; set; }
        public string ContentName { get; set; }
        public int TopicId { get; set; }
        public string TopicName { get; set; }
    }
}
