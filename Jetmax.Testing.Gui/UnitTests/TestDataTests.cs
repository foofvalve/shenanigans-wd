using Jetmax.Testing.Gui.Core;
using Jetmax.Testing.Gui.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;

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
            testData.Find("meh").ShouldBe("the-val");
        }

        [TestMethod]
        public void TestRetrievingSingleAttributeWithCast()
        {
            var testData = new TestData();
            testData.Add("meh", true);
            testData.Get<bool>("meh").ShouldBeTrue();
        }

        [TestMethod]
        public void TestResettingContent()
        {
            var testData = new TestData();
            testData.Add("meh", true);
            testData.Add("meh2", true);
            testData.Reset();
            testData.Count.ShouldBe(0);
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
            result.ShouldContain("Firstname : John");
            result.ShouldContain("Paid : True");
        }

        [TestMethod]
        public void TestUpdateValue()
        {
            var testData = new TestData();
            testData.Add("meh", 33);
            testData.Update("meh", 42);
            testData.Get<int>("meh").ShouldBe(42);
            testData.Count.ShouldBe(1);
        }

        [TestMethod]
        public void TestKeysAreCaseInsensitive()
        {
            var testData = new TestData();
            testData.Add("mEh", 33);
            testData.Get<int>("Meh").ShouldBe(33);
            testData.Count.ShouldBe(1);
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

            testData.Find("Origin").ShouldBe("SYD");
            testData.Find("Destination").ShouldBe("AKL");
            testData.Print();
        }

        [TestMethod]
        public void TestDefaultsValuesForChildrenAndInfantIsZero()
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
            testData.Find("Children").ShouldBe("0");
            testData.Find("Infants").ShouldBe("0");
        }

        [TestMethod]
        public void TestSeedingCustomerDetails()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void TestSeedingMixedPaxCustomerDetails()
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
