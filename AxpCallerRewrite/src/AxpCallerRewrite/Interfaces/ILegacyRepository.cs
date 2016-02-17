using System.Data.SqlClient;

namespace AxpCallerRewrite.Interfaces
{
    public interface ILegacyRepository
    {
        SqlCommand GetCompanyTypes();
        void GetOecProducts();
        void GetActivateFeature();
        void GetDeactivateFeature();
    }
}