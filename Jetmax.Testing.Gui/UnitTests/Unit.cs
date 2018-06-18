using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Jetmax.Testing.Gui.Core;
using Jetmax.Testing.Gui.Pages.BYOJet;
using Microsoft.Expression.Encoder.ScreenCapture;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jetmax.Testing.Gui.UnitTests
{
    [TestClass]
    public class Unit : BaseTest
    {
        private ScreenCaptureJob scj;
        private string baseUrl;

        [TestInitialize]
        public void Setup()
        {
            Init();
            
            baseUrl = "file:///C:/Users/ryanr/source/repos/Jetmax.Testing.Gui/Jetmax.Testing.Gui/Tests/Test.html";
        }

        [TestMethod]
        public void TestInputtingValueIntoTextField()
        {
            Console.WriteLine("Test");
            Wd.Visit(baseUrl);
            
            Wd.Get(HomePage.SearchForm).SetText("fsd");
        }

        [TestMethod]
        public void TestVisitingInvalidWebUrl()
        {

        }

        [TestMethod]
        public void TestWaitForElement()
        {

        }

        [TestMethod]
        public void TestClickingElement()
        {

        }

        [TestMethod]
        public void TestForElementUnclikable()
        {

        }

        [TestMethod]
        public void TestInputElementUneditable()
        {

        }

        [TestMethod]
        public void TestSelectValueFromDropDown()
        {

        }

        [TestMethod]
        public void TestTickingCheckbox()
        {

        }

        [TestMethod]
        public void TestGettingElementText()
        {

        }

        [TestMethod]
        public void TestExecuteJavascript()
        {

        }

        [TestMethod]
        public void TestSwitchingBetweenIframe()
        {

        }

        [TestCleanup]
        public void TestCleanUp()
        {
            scj.Stop();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            CleanUp();
        }
    }
}
