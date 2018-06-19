using Jetmax.Testing.Gui.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Reflection;

namespace Jetmax.Testing.Gui.UnitTests
{
    [TestClass]
    public class Unit : BaseTest
    {
        private string _baseUrl;
        private ScreenRecorder _screenRecorder;
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void Setup()
        {
            Init();
            _screenRecorder = new ScreenRecorder(Path.GetTempPath(), TestContext.TestName);
            _screenRecorder.StartRecording();
            string codeBase = Assembly.GetExecutingAssembly().Location;
            var dir = new FileInfo(codeBase).Directory + @"\UnitTests\Test.html";
            _baseUrl = new Uri(dir).ToString();
        }

        [TestMethod]
        public void TestInputtingValueIntoTextField()
        {
            Console.WriteLine("Test");
            Wd.Visit(_baseUrl);
            Wd.Get(TestPage.EnterTextField).SetText("cheese");
            Assert.IsTrue(Wd.Get(TestPage.EnterTextField).GetAttribute("value") == "cheese");
        }

        [TestMethod]
        public void TestNonExistentElement()
        {
            Wd.Visit(_baseUrl);
            Wd.Get("#this-does-not-exists");
        }

        [TestMethod]
        public void TestElementRequiringRuntimeData()
        {
            Wd.Visit(_baseUrl);
            var textContent = Wd.Get(TestPage.ListOption, "Coffee").Text;
            Assert.AreEqual(textContent, "Black Coffee");
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
        public void TestSwitchingBetweenIframe()
        {

        }

        [TestCleanup]
        public void TestCleanUp()
        {
            var recording = _screenRecorder.StopRecording();
            Console.WriteLine(recording);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            CleanUp();
        }
    }
}
