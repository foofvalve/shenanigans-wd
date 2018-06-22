using System;
using OpenQA.Selenium;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;

namespace Jetmax.Testing.Gui.Core
{
    public static class WebDriverExtensions
    {
        public static void Visit(this IWebDriver driver, string url, int timeout = 20)
        {
            try
            {
                Console.WriteLine(url);
                driver.Navigate().GoToUrl(url);
                WaitForPageLoad(driver, timeout);
                Assert.IsNotNull(driver.Get("//body"), "The page failed to load content");
                // TODO: Log
            }
            catch (Exception e)
            {
                e.Data.Add("UserMessage", $"Failed to load {url} after {timeout} seconds, current url is {driver.Url}");
                throw;
            }
        }

        public static IWebElement Get(this IWebDriver driver, string locator, string runtimeData)
        {
            return Get(driver, locator.Replace("RUNTIME", runtimeData));
        }

        public static IWebElement Get(this IWebDriver driver, string locator)
        {
            var element = WaitForElement(driver, locator);
            return element;
        }

        public static void SwitchIframe(this IWebDriver driver, string iframeLocator)
        {
            driver.SwitchTo().Frame(WaitForElement(driver, iframeLocator));
        }

        public static void SwitchBackToMainContent(this IWebDriver driver)
        {
            driver.SwitchTo().DefaultContent();
        }

        public static void WaitForPageLoad(this IWebDriver driver, int timeout = 20)
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, timeout));
            wait.Until(wd => wd.ExecuteJs("return document.readyState") == "complete");
        }

        public static By UsingLocator(string locator)
        {
            if (locator.StartsWith("//"))
            {
                return By.XPath(locator);
            }

            if (locator.StartsWith("#"))
            {
                return By.CssSelector(locator);
            }

            if (locator.StartsWith("."))
            {
                return By.CssSelector(locator);
            }

            if (locator.Count(w => w == ' ') == 0 && !locator.Contains("[")) // will not work for by tag name/by link text
            {
                return By.Id(locator);
            }

            return By.CssSelector(locator);
        }

        private static IWebElement WaitForElement(this IWebDriver driver, string locator, int timeout = 10)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver)
            {
                Timeout = TimeSpan.FromSeconds(timeout),
                PollingInterval = TimeSpan.FromMilliseconds(250)
            };
            //fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            var element = fluentWait.Until(x => x.FindElement(UsingLocator(locator)));
            return element;
        }

        private static void WaitForElementToDisappear(this IWebDriver driver, string locator)
        {
            throw new NotImplementedException("TODO");
        }

        private static string ExecuteJs(this IWebDriver driver, string script)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            return (string)js.ExecuteScript(script);
            // TODO: Log
        }
    }
}
