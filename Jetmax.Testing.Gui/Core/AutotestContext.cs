using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Jetmax.Testing.Gui.Core
{
    public class AutotestContext
    {
        public static IWebDriver Wd { get; private set; }
        public static string RunInBrowser;

        public TestContext TestContext { get; set; }

        [ClassInitialize]
        public static void SuiteSetup(TestContext testContext)
        {
            RunInBrowser = testContext.Properties["runInBrowser"].ToString();
        }

        public static void Init()
        {
            if (Wd != null) return; //use the same instance
            
            if (RunInBrowser == "chrome")
            {
                Wd = new ChromeDriver();
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
