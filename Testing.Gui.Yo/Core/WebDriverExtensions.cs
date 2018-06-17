using OpenQA.Selenium;

namespace Jetmax.Testing.Gui.Core
{
    public static class WebDriverExtensions
    {
        public static void Visit(this IWebDriver driver, string url)
        {
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

        private static By UsingLocator(string locator)
        {
            // TODO: Case statement to figure locator strategy
            return By.CssSelector(locator);
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
