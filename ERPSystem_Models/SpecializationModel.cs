using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem_Models
{
    public class SpecializationModel
    {
        public int SpecializationId { get; set; }
        public string SpecializationName { get; set; }
        public int QualificationId { get; set; }
        public string QualificationName { get; set; }
    }
}
