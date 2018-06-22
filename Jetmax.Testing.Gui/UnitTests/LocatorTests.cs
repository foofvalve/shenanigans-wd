using System;
using System.Runtime.InteropServices;
using Jetmax.Testing.Gui.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Jetmax.Testing.Gui.UnitTests
{
    [TestClass]
    public class LocatorTests
    {
        [TestMethod]
        public void TestLocatorUsingCssId()
        {
            var by = WebDriverExtensions.UsingLocator("#test");
            Assert.AreEqual("By.CssSelector: #test", by.ToString());
        }

        [TestMethod]
        public void TestLocatorUsingId()
        {
            var by = WebDriverExtensions.UsingLocator("test-of-div");
            Assert.AreEqual("By.Id: test-of-div", by.ToString());
        }

        [TestMethod]
        public void TestLocatorUsingXpath()
        {
            var by = WebDriverExtensions.UsingLocator("//*[@type='text']");
            Assert.AreEqual("By.XPath: //*[@type='text']", by.ToString());
        }

        [TestMethod]
        public void TestLocatorUsingCss()
        {
            var by = WebDriverExtensions.UsingLocator(".main-content");
            Assert.AreEqual("By.CssSelector: .main-content", by.ToString());
        }

        [TestMethod]
        public void TestLocatorUsingMultipleCss()
        {
            var by = WebDriverExtensions.UsingLocator("div input[id='okbutton']");
            Assert.AreEqual("By.CssSelector: div input[id='okbutton']", by.ToString());
        }

        [TestMethod]
        public void TestLocatorUsingCssTagName()
        {
            var by = WebDriverExtensions.UsingLocator("input[type='checkbox']");
            Assert.AreEqual("By.CssSelector: input[type='checkbox']", by.ToString());
        }
    }
}
