using ERPSystem_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem_Services.Interfaces
{
    public interface ITechnologyServices
    {
        void AddTechnology(TechnologyModel technology);
        void UpdateTechnology(TechnologyModel technology);
        void DeleteTechnology(int technologyId);
        void RestoreTechnology(int technologyId);

        List<TechnologyModel> GetTechnologies();
        TechnologyModel GetTechnology(int technologyId);
    }
}
