using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem_Models
{
    public class StudentQualificationModel
    {
        public int StudentQualificationId { get; set; }
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int SpecializationId { get; set; }
        public string SpecializationName { get; set; }
        public int QualificationId { get; set; }
        public string QualificationName { get; set; }
        public string Medium { get; set; }
        public int PassingYear { get; set; }
        public float Percentage { get; set; }
        public string University { get; set; }
    }
}
