using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AxpCallerRewrite.Interfaces;
using AxpCallerRewrite.Models;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Razor.Tokenizer;

namespace AxpCallerRewrite.Concrete
{
    public class ParseHelper 
    {
        public List<string> SplitCompanyIDs(string value)
        {
            

            List<string> CompanyIDList = new List<string>();
            if (value != null)
            {

                if (value.Contains("\n"))
                {
                    CompanyIDList = value.Replace("\r", ",").Replace("\n", ",").Split(',').ToList();
                }
                else
                {
                    CompanyIDList = value.Split(',').ToList();
                }

                foreach (var item in CompanyIDList)
                {
                    Console.WriteLine(item.ToString());
                    Console.WriteLine(CompanyIDList[0]);

                }
            }

            return CompanyIDList;
            
        } 




    }
    
}
