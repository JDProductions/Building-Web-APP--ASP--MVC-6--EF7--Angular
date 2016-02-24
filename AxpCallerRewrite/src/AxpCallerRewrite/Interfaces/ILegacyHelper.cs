using AxpCallerRewrite.Models;
using Microsoft.AspNet.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AxpCallerRewrite.Interfaces
{
   public  interface ILegacyHelper
   {
        SelectList GetCompanyData();
        SelectList GetStates();
        SelectList GetOEMs();
        SelectList GetProducts();
        SelectList GetFeatures();
        Task<string> CreateCompany(CompanyModel company);
        Task<string> ActivateFeature(FeatureModel feature);
        Task<string> DeactivateFeature(FeatureModel feature);
        Task<string> ActivateProduct(ProductModel product);
   }
}
