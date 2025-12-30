using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem_Models
{
    public class StudentBreakDetailModel
    {
        public int BreakId { get; set; }
        public int RegistrationId { get; set; }
        public string RegistrationCode { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string BreakReason { get; set; }
    }
}
