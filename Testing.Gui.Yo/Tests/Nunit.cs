using NUnit.Framework;
using System;

namespace Testing.Gui.Yo.Tests
{
    [TestFixture]
    public class Nunit
    {
        [SetUp]
        public void Setup()
        {
            Console.WriteLine("setup");
        }

        private static int retry = 0;
        [Test]
        [Retry(4)]
        public void TestUnit()
        {
            Console.WriteLine("test" + retry.ToString());
            //Assert.Fail("fail");
            throw new Exception("retry :" + retry);
            retry++;
        }


        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("TearDown");
        }

    }
}
