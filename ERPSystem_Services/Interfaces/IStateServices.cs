using ERPSystem_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem_Services.Interfaces
{
    public interface IStateServices
    {
        void AddState(StateModel state);
        void UpdateState(StateModel state);
        void DeleteState(int stateId);
        void RestoreState(int stateId);

        List<StateModel> GetStates();
        StateModel GetState(int stateId);


    }
}
