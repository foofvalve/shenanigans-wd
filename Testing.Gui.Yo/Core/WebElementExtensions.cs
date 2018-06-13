using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Testing.Gui.Yo.Core
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
    }
}
