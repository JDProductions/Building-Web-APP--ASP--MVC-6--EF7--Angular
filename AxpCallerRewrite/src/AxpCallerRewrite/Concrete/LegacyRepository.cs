using System;
using AxpCallerRewrite.Interfaces;

namespace AxpCallerRewrite.Concrete
{
    public class LegacyRepository : ILegacyRepository
    {
        public void GetActivateFeature()
        {
            throw new NotImplementedException();
        }

        public void GetCompanyTypes()
        {
        }

        public void GetDeactivateFeature()
        {
            throw new NotImplementedException();
        }

        public void GetOecProducts()
        {
            return;
        }

        public void Weseleysmells()
        {
            throw new NotImplementedException();
        }
    }
}
