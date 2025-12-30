using ERPSystem_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem_Services.Interfaces
{
    public interface ILeadSourceServices
    {
        void AddLeadSource(LeadSourceModel source);
        void UpdateLeadSource(LeadSourceModel source);
        void DeleteLeadSource(int sourceId);
        void RestoreLeadSource(int sourceId);

        List<LeadSourceModel> GetLeadSources();
        LeadSourceModel GetLeadSource(int sourceId);
    }
}
