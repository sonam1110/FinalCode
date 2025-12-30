using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem_Models
{
    public class StudentRegistrationDetailModel
    {
        public int RegistrationId { get; set; }
        public string RegistrationCode { get; set; }
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public DateTime JoiningDate { get; set; }
        public int CourseFeeId { get; set; }
        public float Amount { get; set; }
        public float Discount { get; set; }
        public string CurrentStatus { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
    }
}
