using System;
using System.Runtime.InteropServices;
using Jetmax.Testing.Gui.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Shouldly;

namespace Jetmax.Testing.Gui.UnitTests
{
    [TestClass]
    public class LocatorTests
    {
        [TestMethod]
        public void TestLocatorUsingCssId()
        {
            var by = WebDriverExtensions.UsingLocator("#test");
            by.ToString().ShouldBe("By.CssSelector: #test");
        }

        [TestMethod]
        public void TestLocatorUsingId()
        {
            var by = WebDriverExtensions.UsingLocator("test-of-div");
            by.ToString().ShouldBe("By.Id: test-of-div");
        }

        [TestMethod]
        public void TestLocatorUsingXpath()
        {
            var by = WebDriverExtensions.UsingLocator("//*[@type='text']");
            by.ToString().ShouldBe("By.XPath: //*[@type='text']");
        }

        [TestMethod]
        public void TestLocatorUsingCss()
        {
            var by = WebDriverExtensions.UsingLocator(".main-content");
            by.ToString().ShouldBe("By.CssSelector: .main-content");
        }

        [TestMethod]
        public void TestLocatorUsingMultipleCss()
        {
            var by = WebDriverExtensions.UsingLocator("div input[id='okbutton']");
            by.ToString().ShouldBe("By.CssSelector: div input[id='okbutton']");
        }

        [TestMethod]
        public void TestLocatorUsingCssTagName()
        {
            var by = WebDriverExtensions.UsingLocator("input[type='checkbox']");
            by.ToString().ShouldBe("By.CssSelector: input[type='checkbox']");
        }
    }
}
