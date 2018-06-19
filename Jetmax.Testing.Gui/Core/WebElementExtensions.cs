using OpenQA.Selenium;

namespace Jetmax.Testing.Gui.Core
{
    public static class WebElementExtensions
    {
        public static void PerformClick(this IWebElement element)
        {
            if (element.Displayed && element.Enabled)
            {
                element.Click();
            }
        }

        public static void SetText(this IWebElement element, string text)
        {
            if (element.Displayed && element.Enabled)
            {
                element.Clear();
                element.SendKeys(text);
            }
        }

        public static void SelectOption(this IWebElement element, string text)
        {

        }

        public static void SetCheckBox(this IWebElement element, bool check)
        {

        }
    }
}
