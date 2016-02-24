using System;
using System.Data.SqlClient;
using AxpCallerRewrite.Interfaces;
using Dapper;
using Microsoft.AspNet.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using AxpCallerRewrite.Models;
using AxpCallerRewrite.Models.Database_Models;
using System.Threading.Tasks;

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

        public IEnumerable<OEM> GetOEMs()
        {
            using (SqlConnection conn = OpenConnection())
            {
                return conn.Query<OEM>("SELECT OEMLongName, OEMID FROM oecmain..OEMMaster");
            }
        }

        public IEnumerable<Product> GetProducts()
        {
            using (SqlConnection conn = OpenConnection())
            {
                return conn.Query<Product>("SELECT ProdID, DisplayName FROM oecmain..oecproducts");
            }
        }

        public IEnumerable<Feature> GetFeatures()
        {
            using (SqlConnection conn = OpenConnection())
            {
                return conn.Query<Feature>("SELECT FeatureID, FeatureName FROM oecmain..oecfeatures");
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

        public Task<string> SendXml (string xmlString, string environmentLevel)
        {
            // Created an instance of SendTemplate 
            SendTemplate template = new SendTemplate();
            // Send Create Company Template to Server
            return template.SendAxpTemplate(xmlString, environmentLevel);
        }
    }
}
