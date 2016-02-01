using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace AxpCallerRewrite.Concrete
{
    public class SendTemplate
    {
        public void SendAxpTemplate(List<string> companyIDs, string template)
        {
            var responses = new StringBuilder();

            ParseHelper parse = new ParseHelper();
            
            

            for (var i = 0; i < companyIDs.Count(); i++) // Might need to change count because its counting strings
            {
                Console.Write(string.Format("Processing company {0} of {1}", i, companyIDs.Count()));
                var item = companyIDs[i];
                if (string.IsNullOrEmpty(item))
                    continue;

                HttpClient client = new HttpClient();
            }
        }
    }
}
