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
            testData.Get<int>("Children").ShouldBe(0);
            testData.Get<int>("Infants").ShouldBe(0);
        }

        [TestMethod]
        public void TestSeedingPassengerDetails()
        {
            var testData = new TestData();
            testData.Add(new TestParams
            {
                Origin = "SYD",
                Destination = "AKL",
                Departure = DateTime.Today.AddDays(10),
                Arrival = DateTime.Today.AddDays(15),
                Adults = 2,
                Children = 1,
                Infants = 1
            });
            testData.Find("passenger-0-type").ShouldBe("adult");
            testData.Find("passenger-0-firstname").ShouldBe("Adzero");
            testData.Find("passenger-1-type").ShouldBe("adult");
            testData.Find("passenger-1-firstname").ShouldBe("Adone");
            testData.Find("passenger-2-type").ShouldBe("child");
            testData.Find("passenger-2-firstname").ShouldBe("Chzero");
            testData.Find("passenger-3-type").ShouldBe("infant");
            testData.Find("passenger-3-firstname").ShouldBe("Inzero");
            testData.Find("passenger-3-middlename").ShouldBe("Autotest");
            testData.Find("passenger-3-lastname").ShouldBe("Test");
        }

        [TestMethod]
        public void TestSeedingContactDetails()
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
            var testParams = testData.Print().Split(Environment.NewLine.ToCharArray());
            testParams.ShouldContain("contact-first-name : Test");
            testParams.ShouldContain("contact-lastname-name : Autotest");
            testParams.ShouldContain("contact-email : autotest.byojet@gmail.com");
            testParams.ShouldContain("contact-mobile : 0421555777");
        }

        [TestMethod]
        public void TestSeedingAddressDetails()
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
            var testParams = testData.Print().Split(Environment.NewLine.ToCharArray());
            testParams.ShouldContain("street-number : Flat 95");
            testParams.ShouldContain("street-name : North End House, Fitzjames Avenue");
            testParams.ShouldContain("suburb : London");
            testParams.ShouldContain("state : London");
            testParams.ShouldContain("postcode : W14 0RY");
            testParams.ShouldContain("country : uk");
        }

        [TestMethod]
        public void TestSeedingFormOfPaymentDetails()
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
            var testParams = testData.Print().Split(Environment.NewLine.ToCharArray());
            testParams.ShouldContain("card-brand : visa");
            testParams.ShouldContain("card-type : credit");
            testParams.ShouldContain("card-number : 4111111111111111");
            testParams.ShouldContain("card-holder : MR BYOJET AUTOTEST");
            testParams.ShouldContain("card-cvv : 123");
            testParams.ShouldContain("card-expiry-month : 10");
            testParams.ShouldContain("card-expiry-year : " + DateTime.Now.AddYears(2).Year);
        }
    }
}