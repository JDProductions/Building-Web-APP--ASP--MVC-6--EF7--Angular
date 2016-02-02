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
using Microsoft.AspNet.Mvc.ModelBinding.Validation;

namespace AxpCallerRewrite.Concrete
{
    public class SendTemplate
    {
        Uri baseUri = new Uri("http://www.test.com/");

        public async void SendAxpTemplate(List<string> companyIDs, string template, string environment)
        {
            var responses = new StringBuilder();
            var input = new FileInputModel();


            for (var i = 0; i < companyIDs.Count(); i++) // Might need to change count because its counting strings
            {
                Console.Write(string.Format("Processing company {0} of {1}", i, companyIDs.Count()));
                var item = companyIDs[i];
                if (string.IsNullOrEmpty(item))
                    continue;

                await CallController(environment,template);
                var test = "";




            }
            

      
        }
        // How does it fill thhis parameter
        private async Task<string> CallController(string environment, string axpTemplate)
        {
            var test = "";
            // Creating the Request

                using (var client = new HttpClient())
                    {
                        switch (environment)
                       {       
                            case "Prod":
                            break;

                           case "Dev":
                               try
                               {
                                   baseUri = new Uri("http://devapp1/OEConnection.Application.SubscriptionController.Web/ControllerServices.svc.DoWork");
                                   client.BaseAddress = baseUri;
                                   client.DefaultRequestHeaders.Accept.Add(
                                       new MediaTypeWithQualityHeaderValue("application/xml"));

                                    var request = new HttpRequestMessage(HttpMethod.Post, baseUri);
                                    request.Content = new StringContent("text/xml");
                                    var response = await client.SendAsync(request);

                            return await response.Content.ReadAsStringAsync();
                               }
                               catch (Exception e)
                               {
                                   Console.Write(e.Message);
                               }
                               // Http Post

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
