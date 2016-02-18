using AxpCallerRewrite.Models;
using System.Collections.Generic;

namespace AxpCallerRewrite.Interfaces
{
    public interface ILegacyRepository
    {
        IEnumerable<CompanyType> GetCompanyTypes();
        IEnumerable<State> GetStates();
        void GetOecProducts();
        void GetActivateFeature();
        void GetDeactivateFeature();
    }
}