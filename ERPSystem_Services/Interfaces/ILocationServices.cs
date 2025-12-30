using ERPSystem_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem_Services.Interfaces
{
    public interface ILocationServices
    {
        void AddLocation(LocationModel location);
        void UpdateLocation(LocationModel location);
        void DeleteLocation(int locationId);
        void RestoreLocation(int locationId);

        List<LocationModel> GetLocations();
        LocationModel GetLocation(int locationId);
    }
}
