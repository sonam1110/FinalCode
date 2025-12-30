using ERPSystem_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem_Services.Interfaces
{
    public interface IEmployeeDetailServices
    {
        void AddEmployeeDetail(EmployeeDetailModel employeeDetail);
        void UpdateEmployeeDetail(EmployeeDetailModel employeeDetail);
        void DeleteEmployeeDetail(int employeeDetailId);
        void RestoreEmployeeDetail(int employeeDetailId);

        List<EmployeeDetailModel> GetEmployeeDetails();
        EmployeeDetailModel GetEmployeeDetails(int employeeDetailId);
    }
}
