using System;
using System.Data.SqlClient;
using AxpCallerRewrite.Interfaces;
using Dapper;
using Microsoft.AspNet.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using AxpCallerRewrite.Models;

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
                return new SqlConnection("Server=sdvdb1\\oec;Database=OECMain;Trusted_Connection=true");
        }

        public IEnumerable<CompanyType> GetCompanyTypes()
        {
            using (SqlConnection conn = OpenConnection())
            {
                return conn.Query<CompanyType>("SELECT CompanyTypeID, CompanyTypeDesc FROM oecmain..CompanyTypeMaster");
            }
        }

        public IEnumerable<State> GetStates()
        {
            using (SqlConnection conn = OpenConnection())
            {
                return conn.Query<State>("SELECT StateAbbr, StateName FROM OECGeoData..USStates_vw");
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
