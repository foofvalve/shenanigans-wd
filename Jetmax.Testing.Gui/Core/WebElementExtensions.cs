using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Jetmax.Testing.Gui.Core
{
    public static class WebElementExtensions
    {
        public static void PerformClick(this IWebElement element)
        {
            if (IsInteractable(element))
            {
                element.Click();
                Log.Add($"\t Clicked");
            }
        }

        public static void SetText(this IWebElement element, string text)
        {
            if (IsInteractable(element))
            {
                element.Clear();
                element.SendKeys(text);
                Log.Add($"\t SetText => value: {text}");
            }
        }

        public static void SelectOption(this IWebElement element, string text)
        {
            if (IsInteractable(element))
            {
                var selectElement = new SelectElement(element);
                selectElement.SelectByText(text);
                Log.Add($"\t Selected => value: {text}");
            }
        }

        private static bool IsInteractable(IWebElement element)
        {
            if (element.Displayed && element.Enabled)
            {
                return true;
            }
            throw new Exception("Element was not visible and enabled");
        }
    }
}
