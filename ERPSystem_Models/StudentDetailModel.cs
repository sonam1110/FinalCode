using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem_Models
{
    public class StudentDetailModel
    {
        public int StudentId { get; set; }
        public string StudentCode { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress{ get; set; }
        public string MobileNumber { get; set; }
        public string AlternativeNumber { get; set; }
        public string Photo { get; set; }
        public DateTime BirthDate { get; set; }
        public string Password { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public string LocalAddress { get; set; }
        public string PermenantAddress { get; set; }
    }
}
