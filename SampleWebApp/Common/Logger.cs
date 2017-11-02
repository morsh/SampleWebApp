using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace SampleWebApp.Common
{
    static public class Logger
    {
        static public void Log(string message)
        {
            Console.Out.WriteLine(DateTime.Now.ToString() + " [Console] :: " + message);
            Debug.WriteLine(DateTime.Now.ToString() + " [Debug] :: " + message);
        }
    }
}