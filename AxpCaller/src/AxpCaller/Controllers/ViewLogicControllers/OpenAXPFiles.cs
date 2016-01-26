using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using AxpCaller.ViewModels;
using Microsoft.AspNet.Http;

namespace AxpCaller.Controllers.ViewLogicControllers
{

    public class OpenAXPFiles
    {
           public void OpenAxpFile(string fileName)
        {
            var setting = JsonConvert.DeserializeObject<AxpSetting>(File.ReadAllText(fileName));
            

        }
    }
    
}
