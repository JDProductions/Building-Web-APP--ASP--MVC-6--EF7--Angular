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
        SelectList GetProdIdLevelNum();
        string CreateCompany(CompanyModel company);
        string ActivateFeature(FeatureModel feature);
        string DeactivateFeature(FeatureModel feature);
        string ActivateProduct(ProductModel product);
   }
}
