using ERPSystem_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem_Services.Interfaces
{
    public interface IGenderServices
    {
        void AddGender(GenderModel gender);
        void UpdateGender(GenderModel gender);
        void DeleteGender(int genderId);
        void RestoreGender(int genderId);

        List<GenderModel> GetGenders();
        GenderModel GetGender(int genderId);
    }
}
