using System;
using OpenQA.Selenium;
using System.Linq;

namespace Jetmax.Testing.Gui.Core
{
    public static class WebDriverExtensions
    {
        public static void Visit(this IWebDriver driver, string url)
        {
            Console.WriteLine(url);
            driver.Navigate().GoToUrl(url);
            // TODO: Log
        }

        public static IWebElement Get(this IWebDriver driver, string locator)
        {
            //TODO: Wait for element
            System.Threading.Thread.Sleep(5000);
            var element = driver.FindElement(UsingLocator(locator));
            return element;
        }

        public static void SwithIframe(this IWebDriver driver, string iframeLocator)
        {

        }

        public static void WaitForPageLoad(this IWebDriver driver)
        {

        }

        public static By UsingLocator(string locator)
        {
            if (locator.StartsWith("//"))
            {
                return By.XPath(locator);
            }
            else if (locator.StartsWith("#"))
            {
                return By.CssSelector(locator);
            }
            else if (locator.StartsWith("."))
            {
                return By.CssSelector(locator);
            }
            else if (locator.Count(w => w == ' ') == 0 && !locator.Contains("["))
            {
                return By.Id(locator);
            }
            else
            {
                return By.CssSelector(locator);  
            }
        }

        private static void WaitForElement(this IWebDriver driver, string locator)
        {

        }

        private static void WaitForElementToDisappear(this IWebDriver driver, string locator)
        {

        }

        private static void ExecuteJs(string js)
        {

        }
    }
}
