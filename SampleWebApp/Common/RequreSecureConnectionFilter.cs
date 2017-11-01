using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleWebApp
{
    public class RequreSecureConnectionFilter : RequireHttpsAttribute
    {
    }
}