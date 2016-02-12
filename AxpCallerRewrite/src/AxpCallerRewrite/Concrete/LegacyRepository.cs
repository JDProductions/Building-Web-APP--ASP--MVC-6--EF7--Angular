using System;
using System.Data.SqlClient;
using AxpCallerRewrite.Interfaces;

namespace AxpCallerRewrite.Concrete
{
    public class LegacyRepository : ILegacyRepository
    {
        public void GetActivateFeature()
        {
            throw new NotImplementedException();
        }

        //I understand why this needs to be used now
        public SqlConnection OpenConnection()

        {
            using (SqlConnection connection = new SqlConnection())
            {
                // Connection pool created
               connection.ConnectionString = "Server=[test_server];Database=[dataBASE!@@];Trusted_Connection=true";
                return connection;

            }   

        }

        public SqlCommand GetCompanyTypes()
        {
            using (SqlConnection conn = OpenConnection())
            {
                // Connection pool created
                SqlCommand companyTypes = new SqlCommand("SELECT * FROM TableName", conn);
                conn.Open();
                return companyTypes;
            }
        }

        public void GetDeactivateFeature()
        {
            throw new NotImplementedException();
        }

        public void GetOecProducts()
        {
            return;
        }
    }
}
