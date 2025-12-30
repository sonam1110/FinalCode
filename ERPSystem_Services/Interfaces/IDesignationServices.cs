using ERPSystem_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem_Services.Interfaces
{
    public interface IDesignationServices
    {
        void AddDesignation(DesignationModel designation);
        void UpdateDesignation(DesignationModel designation);
        void DeleteDesignation(int designationId);
        void RestoreDesignation(int designationId);

        List<DesignationModel> GetDesignations();
        DesignationModel GetDesignation(int designationId);
    }
}
