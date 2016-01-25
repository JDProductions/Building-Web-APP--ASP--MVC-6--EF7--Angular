using System;
using System.Collections.Generic;
using AxpCaller.Controllers.Web;
using AxpCaller.ViewModels;
using System.Linq;

namespace AxpCaller.Controllers.ViewLogicControllers
{
    public class CompanyIDSplitterController
    {
        public List<string> SplitCompanyIDs(ActivateViewModel aModel)
        {
            List<string> companyIDList = new List<string>();
            if (aModel.CompanyID != null)
            {
                companyIDList = aModel.CompanyID.Split(',', ' ', '\n', '\r').ToList();
                foreach (var item in companyIDList)
                {
                    Console.WriteLine(item.ToString());
                }
            }

            return companyIDList;
        } 

        
        
       
    }

}