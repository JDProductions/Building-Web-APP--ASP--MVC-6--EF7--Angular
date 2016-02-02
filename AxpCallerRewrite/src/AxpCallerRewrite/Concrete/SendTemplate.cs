using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AxpCallerRewrite.Models;
using Newtonsoft.Json;
using Microsoft.AspNet.Mvc;

namespace AxpCallerRewrite.Concrete
{
    public class SendTemplate
    {
        Uri baseUri = new Uri("http://www.test.com/");

        public void SendAxpTemplate(List<string> companyIDs, string template, string environment)
        {
            var responses = new StringBuilder();
            var input = new FileInputModel();


            for (var i = 0; i < companyIDs.Count(); i++) // Might need to change count because its counting strings
            {
                Console.Write(string.Format("Processing company {0} of {1}", i, companyIDs.Count()));
                var item = companyIDs[i];
                if (string.IsNullOrEmpty(item))
                    continue;

                CallController(environment,template);
                var test = "";




            }
            

      
        }
        // How does it fill thhis parameter
        private string CallController(string environment, string axpTemplate)
        {
            string response = null;
            // Creating the Request

                using (var client = new HttpClient())
                    {
                        switch (environment)
                       {       
                            case "Prod":
                            break;

                           case "Dev":
                        baseUri = new Uri("http://www.dev.com/");
                        client.BaseAddress = baseUri;
                            break;

                            case "QA":
                                baseUri = new Uri("http://www.QA.com/");
                                   client.BaseAddress = baseUri;
                            break;
                            case "NewQA":
                                baseUri = new Uri("http://www.NewQA.com/");
                                client.BaseAddress = baseUri;
                            break;

                    }   

            }

           

            return environment;
        }

    }
}
