using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;

namespace Testing.Gui.Yo.Core
{
    public class BaseTest
    {
        public static IWebDriver Wd { get; private set; }
        
        public static void Init()
        {
            var browser = Environment.GetEnvironmentVariable("browser");
            if (browser == "chrome")
            {

            }
            else
            {
                Wd = new FirefoxDriver();
            }
        }

        public static void CleanUp()
        {
            Wd?.Dispose();
        }
    }
}
