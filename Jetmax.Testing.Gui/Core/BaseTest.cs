using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Jetmax.Testing.Gui.Core
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
