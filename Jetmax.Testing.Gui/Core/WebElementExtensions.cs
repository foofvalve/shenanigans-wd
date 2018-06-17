using OpenQA.Selenium;

namespace Jetmax.Testing.Gui.Core
{
    public static class WebElementExtensions
    {
        public static void PerformClick(this IWebElement element)
        {
            // check if element is displayed
            // check if element is visible
        }

        public static void SetText(this IWebElement element, string text)
        {
            // check if element is displayed
            // check if element is editable
        }

        public static void SelectOption(this IWebElement element, string text)
        {

        }

        public static void SetCheckBox(this IWebElement element, bool check)
        {

        }
    }
}
