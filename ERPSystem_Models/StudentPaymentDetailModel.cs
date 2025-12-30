using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem_Models
{
    public class StudentPaymentDetailModel
    {
        public int PaymentId { get; set; }
        public int RegistrationId { get; set; }
        public string RegistrationCode { get; set; }
        public DateTime PaymentDate { get; set; }
        public float PaymentAmount { get; set; }
        public string PaymentMode { get; set; }
        public string Description { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }

    }
}
