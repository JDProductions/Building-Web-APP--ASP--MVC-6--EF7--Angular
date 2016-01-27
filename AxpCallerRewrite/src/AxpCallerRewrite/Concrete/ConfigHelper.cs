using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AxpCallerRewrite.Interfaces;
using AxpCallerRewrite.Models;
using Microsoft.AspNet.Mvc.Rendering;

namespace AxpCallerRewrite.Concrete
{
    public class ConfigHelper : IConfigHelper
    {
        public SelectList GetEnvironments()
        {
            var environments = new List<EnvironmentModel>
            {
                new EnvironmentModel
                {
                    Name = "DEV",
                    EnvironmentLevel =
                        "http://devapp1/OEConnection.Application.SubscriptionController.Web/ContollerService.svc/DoWork"
                },
                new EnvironmentModel
                {
                    Name = "QA",
                    EnvironmentLevel =
                        "http://qa/OEConnection.Application.SubscriptionController.Web/ContollerService.svc/DoWork"
                },
                new EnvironmentModel
                {
                    Name = "NEWQA",
                    EnvironmentLevel =
                        "http://newqa/OEConnection.Application.SubscriptionController.Web/ContollerService.svc/DoWork"
                },
                new EnvironmentModel
                {
                    Name = "PROD",
                    EnvironmentLevel =
                        "http://prod/OEConnection.Application.SubscriptionController.Web/ContollerService.svc/DoWork"
                }
            };
            return new SelectList(environments, "EnvironmentLevel", "Name");
        }
    }
}
