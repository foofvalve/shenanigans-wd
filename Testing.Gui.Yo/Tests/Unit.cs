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
        }

        [TestMethod]
        public void TestMethod1()
        {
            Console.WriteLine("Test");
            Wd.Visit("https://byojet.com");
            Wd.Get(HomePage.SearchForm).SetText("fsd");
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
