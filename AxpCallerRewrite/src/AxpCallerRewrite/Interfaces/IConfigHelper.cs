using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc.Rendering;

namespace AxpCallerRewrite.Interfaces
{
    public interface IConfigHelper
    {
        SelectList GetEnvironments();
    }
}
