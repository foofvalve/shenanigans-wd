using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Jetmax.Testing.Gui.Core;
using Jetmax.Testing.Gui.Pages.BYOJet;
using Microsoft.Expression.Encoder.ScreenCapture;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jetmax.Testing.Gui.Tests
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
            File.Delete(@"C:\_temp\ScreenRecording.wmv");
            int height =
            Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height % 16);
            int width =
            Screen.PrimaryScreen.Bounds.Width - (Screen.PrimaryScreen.Bounds.Width % 16);


            scj = new ScreenCaptureJob();
            scj.ScreenCaptureVideoProfile.Size = new Size(width, height);
            scj.CaptureRectangle = new Rectangle(0, 0, width, height);
            scj.ScreenCaptureVideoProfile.Force16Pixels = true;
            scj.ShowFlashingBoundary = true;
            scj.ScreenCaptureVideoProfile.FrameRate = 30;
            scj.CaptureMouseCursor = true;
            scj.ScreenCaptureVideoProfile.Quality = 20;
            
            scj.ScreenCaptureVideoProfile.AutoFit = true;
            scj.OutputScreenCaptureFileName = @"C:\_temp\ScreenRecording.wmv";
            

            scj.Start();

            
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
