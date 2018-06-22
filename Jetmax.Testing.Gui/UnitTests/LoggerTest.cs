using Jetmax.Testing.Gui.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jetmax.Testing.Gui.UnitTests
{
    [TestClass]
    public class LoggerTest
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void TestInitLogger()
        {
            var log = new Log();
            log.Init(TestContext.TestName);
            var logs = log.Print();
            Assert.IsTrue(logs == string.Empty);
        }

        [TestMethod]
        public void TestPrintLogs()
        {
            var log = new Log();
            log.Init(TestContext.TestName);
            log.Add("this message");
            var logs = log.Print();
            Assert.IsTrue(logs.Contains(TestContext.TestName + " this message"));
        }
    }
}
