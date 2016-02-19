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
        void CreateCompany(CompanyModel company);
        void ActivateFeature(FeatureModel feature);
        void DeactivateFeature(FeatureModel feature);
   }
}
