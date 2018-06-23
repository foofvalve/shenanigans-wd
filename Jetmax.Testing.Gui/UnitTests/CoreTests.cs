using Jetmax.Testing.Gui.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Reflection;
using Shouldly;

namespace Jetmax.Testing.Gui.UnitTests
{
    [TestClass]
    public class CoreTests : AutotestContext
    {
        private string _baseUrl;
        private ScreenRecorder _screenRecorder;
      
        [TestInitialize]
        public void Setup()
        {
            Init(TestContext.TestName);
            _screenRecorder = new ScreenRecorder(Path.GetTempPath(), TestContext.TestName);
            _screenRecorder.StartRecording();
            string codeBase = Assembly.GetExecutingAssembly().Location;
            var dir = new FileInfo(codeBase).Directory + @"\UnitTests\Test.html";
            _baseUrl = new Uri(dir).ToString();
            Wd.Visit(_baseUrl);
        }

        [TestMethod]
        public void TestInputtingValueIntoTextField()
        {
            Wd.Get(TestPage.EnterTextField).SetText("cheese");
            Wd.Get(TestPage.EnterTextField).GetAttribute("value").ShouldBe("cheese");
        }

        [TestMethod]
        [ExpectedException(typeof(OpenQA.Selenium.NoSuchElementException),
            "Unable to locate element")]
        public void TestNonExistentElement()
        {
            Wd.Get("#this-does-not-exists");
        }

        [TestMethod]
        public void TestElementRequiringRuntimeData()
        {
            var textContent = Wd.Get(TestPage.ListOption, "Coffee").Text;
            textContent.ShouldBe("Black Coffee");
        }

        [TestMethod]
        public void TestClickingElement()
        {
            Wd.Get(TestPage.HideButton).PerformClick();
            Wd.Get(TestPage.SecretText).Displayed.ShouldBeFalse();
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception),
            "Element was not visible and enabled")]
        public void TestForElementUnclikable()
        {
            Wd.Get(TestPage.HiddenUnclickable).PerformClick();
        }

        [TestMethod]
        [ExpectedException(typeof(OpenQA.Selenium.NoSuchElementException),
            "Unable to locate element")]
        public void TestInputElementUneditable()
        {
            Wd.Get(TestPage.DisableField).SetText("THis field should fail input because it disabled");
        }

        [TestMethod]
        public void TestSelectValueFromDropDown()
        {
            Wd.Get(TestPage.DropDown).SelectOption("Third Value");
            Wd.Get(TestPage.DropDown).GetAttribute("value").ShouldBe("third");
        }

        [TestMethod]
        public void TestTickingCheckbox()
        {
            Wd.Get(TestPage.SubscribeCheckbox).PerformClick();
            Wd.Get(TestPage.SubscribeCheckbox).Selected.ShouldBeTrue();
        }

        [TestMethod]
        public void TestSwitchingBetweenIframe()
        {
            Wd.Get(TestPage.OkButton).PerformClick();
            Wd.SwitchIframe(TestPage.WikiPeadiaIFrame);
            var textInsideIframe = Wd.Get(TestPage.DivInsideiFrame).Text;
            textInsideIframe.ShouldBe("This is insed the iFrame");
            Wd.SwitchBackToMainContent();
            Wd.Get(TestPage.OkButton).PerformClick();
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            var recording = _screenRecorder.StopRecording();
            Console.WriteLine(recording);
        }
    }
}
