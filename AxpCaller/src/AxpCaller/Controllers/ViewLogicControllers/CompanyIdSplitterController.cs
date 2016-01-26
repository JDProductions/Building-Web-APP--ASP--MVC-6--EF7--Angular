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
                // Checks for new line and if file has a new line then replace \n\r and add a comma and split list items to a list
                if (aModel.CompanyID.Contains("\n"))
                {
                    companyIDList = aModel.CompanyID.Replace("\r\n", ",").Split(',').ToList();
                }
                else
                {

                    companyIDList = aModel.CompanyID.Split(',').ToList();
                    var test = "";
                }


                foreach (var item in companyIDList)
                {
                    Console.WriteLine(item.ToString());
                    Console.WriteLine(companyIDList[0]);
;
                }
            }

            return companyIDList;
        } 

        
        
       
    }

}