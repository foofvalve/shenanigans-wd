using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Testing.Gui.Yo.Core;
using Testing.Gui.Yo.Pages.BYOJet;

namespace Testing.Gui.Yo.Tests
{
    [TestClass]
    public class Unit : BaseTest
    {
        [TestInitialize]
        public void Setup()
        {
            Init();
        }

        [TestMethod]
        public void TestMethod1()
        {
            Console.WriteLine("Test");
            Wd.Visit("https://byojet.com");
            Wd.Get(HomePage.SearchForm).SetText("fsd");
        }

        [ClassCleanup()]
        public static void ClassCleanup()
        {
            CleanUp();
        }
    }
}
