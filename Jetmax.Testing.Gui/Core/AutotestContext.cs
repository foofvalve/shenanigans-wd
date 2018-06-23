﻿using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Jetmax.Testing.Gui.Core
{
    [TestClass]
    public class AutotestContext
    {
        public static ScreenRecorder ScreenRecorder;
        public static IWebDriver Wd { get; private set; }
        public static string RunInBrowser;

        public TestContext TestContext { get; set; }

        [AssemblyInitializeAttribute]
        public static void SuiteSetup(TestContext testContext)
        {
            RunInBrowser = testContext.Properties["runInBrowser"].ToString();
        }

        public static void Init(string testName)
        {
            Log.Init(testName);
            ScreenRecorder = new ScreenRecorder(Path.GetTempPath(), testName);

            if (Wd != null) return; //use the same instance
            
            if (RunInBrowser == "chrome")
            {
                Wd = new ChromeDriver();
            }
            else if (RunInBrowser == "firefox-headless")
            {
                var options = new FirefoxOptions();
                options.AddArguments("--headless");
                Wd = new FirefoxDriver(options);
            }
            else
            {
                Wd = new FirefoxDriver();
            }
        }

        public static void CleanUp()
        {
            Wd?.Dispose();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            CleanUp();
        }
    }
}
