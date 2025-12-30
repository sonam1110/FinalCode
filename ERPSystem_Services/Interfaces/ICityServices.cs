using ERPSystem_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem_Services.Interfaces
{
    public interface ICityServices
    {
        void AddCity(CityModel city);
        void UpdateCity(CityModel city);
        void DeleteCity(int cityId);
        void RestoreCity(int cityId);
        List<CityModel> GetCities();
        CityModel GetCity(int cityId);

      
    }
}
