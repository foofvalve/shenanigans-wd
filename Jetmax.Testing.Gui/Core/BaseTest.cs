using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Jetmax.Testing.Gui.Core
{
    public class BaseTest
    {
        public static IWebDriver Wd { get; private set; }
        public static string Browser;
        
        public static void Init()
        {
            if (Wd != null) return; //use the same instance
            
            if (Browser == "chrome")
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
