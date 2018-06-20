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
            }
        }

        public static void SetText(this IWebElement element, string text)
        {
            if (IsInteractable(element))
            {
                element.Clear();
                element.SendKeys(text);
            }
        }

        public static void SelectOption(this IWebElement element, string text)
        {
            if (IsInteractable(element))
            {
                var selectElement = new SelectElement(element);
                selectElement.SelectByText(text);
            }
        }

        private static bool IsInteractable(IWebElement element)
        {
            if (element.Displayed && element.Enabled)
            {
                return true;
            }
            throw new Exception("Element was not visiable and enalbed");
        }
    }
}
