using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AxpCallerRewrite.Models;


namespace AxpCallerRewrite.Concrete
{
    // This is describing how Github works i guess?
    public class SendTemplate
    {
        Uri baseUri = new Uri("http://www.test.com/");

        public async void SendAxpTemplate(List<string> companyIDs, string template, string environment)
        {
            
            var input = new FileInputModel();
            var responses = new StringBuilder();


            for (var i = 0; i < companyIDs.Count(); i++) // Might need to change count because its counting strings and it may be skipping a company ID
            {
                Console.Write(string.Format("Processing company {0} of {1}", i, companyIDs.Count()));
                responses.AppendLine(template.Replace("[COMPANYID]", companyIDs[i]));
                responses.Clear();
                responses.AppendLine(template.Replace("[COMPANYID]", companyIDs[i]));
                
                // send the template with new data to post????
                Console.Write(responses);
                var test = "";
                await CallController(environment,template, responses);
                var test2 = "";
                
            }
                await CallController(environment, template, responses);
            var testfdsf = "";





        }
        private async Task<string> CallController(string environment, string axpTemplate, StringBuilder r)
        {
            var httpContent = new StringContent(r.ToString(), Encoding.UTF8, "application/xml");
            if (r.Length == 0)
            {
               httpContent = new StringContent(axpTemplate, Encoding.UTF8, "application/xml");
            }
            var testdsfs = "";
            
            

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
                            // Testing
                                   baseUri = new Uri("http://devapp1/OEConnection.Application.SubscriptionController.Web/ControllerService.svc/DoWork");
                                   client.BaseAddress = baseUri;
                                   client.DefaultRequestHeaders.Accept.Add(
                                       new MediaTypeWithQualityHeaderValue("application/xml"));
                                   var httpResponseMessage = await client.PostAsync(baseUri, httpContent);
                                    
                                   if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
                                   {
                                       var messageContents = await httpResponseMessage.Content.ReadAsStringAsync();
                                Console.WriteLine(messageContents);
                                Console.Write(httpResponseMessage.IsSuccessStatusCode);
                                       var testing = "";
                                   }

                               }
                               catch (HttpRequestException e)
                               {
                                   Console.Write(e.Message);
                               }
                               var test1 = "";

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
