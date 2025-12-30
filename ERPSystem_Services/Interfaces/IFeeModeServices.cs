using ERPSystem_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem_Services.Interfaces
{
    public interface IFeeModeServices
    {
        void AddFeeMode(FeeModeModel feeMode);
        void UpdateFeeMode(FeeModeModel feeMode);
        void DeleteFeeMode(int feeModeId);
        void RestoreFeeMode(int feeModeId);

        List<FeeModeModel> GetFeeModes();
        FeeModeModel GetFeeMode(int feeModeId);
    }

}
