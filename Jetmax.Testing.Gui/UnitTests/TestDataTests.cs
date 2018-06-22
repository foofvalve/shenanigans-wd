using System;
using System.CodeDom;
using Jetmax.Testing.Gui.Core;
using Jetmax.Testing.Gui.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jetmax.Testing.Gui.UnitTests
{
    [TestClass]
    public class TestDataTests
    {
        [TestMethod]
        [ExpectedException(typeof(System.Exception),
            "Test data with key ")]
        public void TestAddingDuplicateTestAttribute()
        {
            var testData = new TestData();
            testData.Add("dupe", true);
            testData.Add("dupe", true);
        }

        [TestMethod]
        public void TestRetrieveSimpleStringTestAttribute()
        {
            var testData = new TestData();
            testData.Add("meh", "the-val");
            var expectedResult = testData.Find("meh");
            Assert.AreEqual("the-val", expectedResult);
        }

        [TestMethod]
        public void TestRetrievingSingleAttributeWithCast()
        {
            var testData = new TestData();
            testData.Add("meh", true);
            var value = testData.Get<bool>("meh");
            Assert.AreEqual(value, true);
        }

        [TestMethod]
        public void TestResettingContent()
        {
            var testData = new TestData();
            testData.Add("meh", true);
            testData.Add("meh2", true);
            testData.Reset();
            Assert.IsTrue(testData.Count == 0);
        }

        [TestMethod]
        public void TestPrintingEntireTestDataContent()
        {
            var testData = new TestData();
            testData.Add("Firstname", "John");
            testData.Add("Lastname", "Smith");
            testData.Add("Age", 22);
            testData.Add("Paid", true);
            var result = testData.Print();
            Assert.IsTrue(result.Contains("Firstname : John"));
            Assert.IsTrue(result.Contains("Paid : True"));
        }

        [TestMethod]
        public void TestAddingFlightSearchDataContent()
        {
            var testData = new TestData();
            testData.Add(new TestParams
            {
                Origin = "SYD",
                Destination = "AKL",
                Departure = DateTime.Today.AddDays(10),
                Arrival = DateTime.Today.AddDays(15),
                Adults = 1
            });

            Assert.IsTrue(testData.Find("Origin") == "SYD");
            testData.Print();
        }

        [TestMethod]
        public void TestSeedingCustomerDetails()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void TestSeedingContactDetails()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void TestSeedingAddressDetails()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void TestSeedingFormOfPaymentDetails()
        {
            throw new NotImplementedException();
        }
    }
}
