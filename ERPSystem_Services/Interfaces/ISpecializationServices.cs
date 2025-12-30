using ERPSystem_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem_Services.Interfaces
{
    public interface ISpecializationServices
    {
        void AddSpecialization(SpecializationModel specialization);
        void UpdateSpecialization(SpecializationModel specialization);
        void DeleteSpecialization(int specializationId);
        void RestoreSpecialization(int specializationId);

        List<SpecializationModel> GetSpecializations();
        SpecializationModel GetSpecialization(int specializationId);

    }
}
