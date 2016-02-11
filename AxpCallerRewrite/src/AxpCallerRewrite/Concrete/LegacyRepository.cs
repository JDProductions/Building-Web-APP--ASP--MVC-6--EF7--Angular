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
            SqlConnection conn = OpenConnection();
            conn.Open();
            SqlCommand companyTypes = new SqlCommand("SELECT * FROM TableName", conn);
            return companyTypes;


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
