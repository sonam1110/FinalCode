using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem_Models
{
    public class TrainingCourseFeeModel
    {
        public int CourseFeeId { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int FeeModeId { get; set; }
        public string FeeMode    { get; set; }
        public float Amount { get; set; }
        public float Tax { get; set; }
    }
}
