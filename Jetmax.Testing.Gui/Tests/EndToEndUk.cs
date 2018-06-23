using Jetmax.Testing.Gui.Actions;
using Jetmax.Testing.Gui.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jetmax.Testing.Gui.Tests
{
    [TestClass]
    public class EndToEndUk : AutotestContext
    {
        private TestData _testData;

        [TestInitialize]
        public void Setup()
        {
            Init(TestContext.TestName);
            ScreenRecorder.StartRecording();
            _testData = new TestData();
        }

        [TestMethod]
        public void BookOWOneAdultInternational()
        {
            _testData.Add("email", "autotest.byojet@gmail.com");
            _testData.Add("password", "Qtp12345");

            Wd.Visit(
                "https://staging.byojet.com/AJAX_DeepLink.asp?referrer=Wego_AU&Cookie=10314aXBAWvzsUkcAs5Cb5nN0sckw62VfHVOqr9wP266AoewD7YFPs3cpqLzH1P7zhUTUWGpbWLS1Sv0pnlBQzkJ43zftwKYy5CS0KowFa&index=2&utm_source=Wego_AU&utm_medium=meta&utm_campaign=Flights");
            Wd.Visit("https://bookingstaging.byojet.com/#/login");
            LoginActions.CreateAccount(_testData);
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            ScreenRecorder.StopRecording();
            _testData?.Print();
            Log.Print();
        }
    }
}
