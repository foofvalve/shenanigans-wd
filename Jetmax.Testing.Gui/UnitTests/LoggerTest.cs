using Jetmax.Testing.Gui.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace Jetmax.Testing.Gui.UnitTests
{
    [TestClass]
    public class LoggerTest
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void TestInitLogger()
        {
            Log.Init(TestContext.TestName);
            var logs = Log.Print();
            logs.ShouldBe("TEST DATA\r\n"); 
        }

        [TestMethod]
        public void TestPrintLogs()
        {
            Log.Init(TestContext.TestName);
            Log.Add("this message");
            var logs = Log.Print();
            logs.ShouldContain(TestContext.TestName + " this message");
        }
    }
}
