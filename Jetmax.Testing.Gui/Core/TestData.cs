﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Humanizer;
using Jetmax.Testing.Gui.Models;

namespace Jetmax.Testing.Gui.Core
{
    public class TestData
    {
        private Dictionary<object, object> Dictionary { get; set; }
        public int Count => Dictionary.Count;

        public TestData()
        {
            Reset();
            Dictionary = new Dictionary<object, object>();
        }

        public void Add(string key, object value)
        {
            var valueExists = Dictionary.TryGetValue(key.ToLower(), out var outVal);
            if (valueExists)
            {
                throw new Exception($"Test data with key [{key.ToLower()}] already exists");
            }

            Dictionary[key.ToLower()] = value;
        }

        public void Update(string key, object value)
        {
            var valueExists = Dictionary.TryGetValue(key, out var outVal);
            if (valueExists)
            {
                Dictionary[key] = value;
            }
        }

        public string Print()
        {
            var result = "";
            foreach (KeyValuePair<object, object> kvp in Dictionary)
            {
                result += string.Format("{0} : {1}", kvp.Key, kvp.Value) + Environment.NewLine;
            }

            Console.WriteLine(result);
            return result;
        }

        public string Find(string key)
        {
            return Get<string>(key);
        }

        public object Get(string key)
        {
            var valueExists = Dictionary.TryGetValue(key.ToLower(), out var outVal);
            if (valueExists)
            {
                return outVal;
            }
            throw new Exception("Unable to find value for => " + key);
        }

        public T Get<T>(string key)
        {
            return (T)Get(key);
        }

        public void Reset()
        {
            Dictionary?.Clear();
        }
        
        public void Add(TestParams testParams)
        {
            var paramsAsDict = testParams.GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .ToDictionary(prop => prop.Name, prop => prop.GetValue(testParams, null));

            foreach (var param in paramsAsDict)
            {
                Add(param.Key, param.Value);
            }

            AddPassengers();
            AddContact();
            AddUkAddress();
            AddVisaPayment("visa");
        }

        public TestData AddPassengers()
        {
            string[] titles = { "Mr", "Ms" };
            var passengerIndex = 0;

            for (var i = 0; i < Get<int>("adults"); i++)
            {
                Add($"passenger-{passengerIndex}-type", "adult");
                Add($"passenger-{passengerIndex}-title", titles[new Random().Next(0, titles.Length)]);
                Add($"passenger-{passengerIndex}-firstname", "Ad" + i.ToWords());
                Add($"passenger-{passengerIndex}-middlename", "Autotest");
                Add($"passenger-{passengerIndex}-lastname", "Test");
                Add($"passenger-{passengerIndex}-dob", DateTime.Now.AddYears(-30).AddDays(i));
                passengerIndex++;
            }

            for (var i = 0; i < Get<int>("children"); i++)
            {
                Add($"passenger-{passengerIndex}-type", "child");
                Add($"passenger-{passengerIndex}-title", titles[new Random().Next(0, titles.Length)]);
                Add($"passenger-{passengerIndex}-firstname", "Ch" + i.ToWords());
                Add($"passenger-{passengerIndex}-middlename", "Autotest");
                Add($"passenger-{passengerIndex}-lastname", "Test");
                Add($"passenger-{passengerIndex}-dob", DateTime.Now.AddYears(-7).AddDays(i));
                passengerIndex++;
            }

            for (var i = 0; i < Get<int>("infants"); i++)
            {
                Add($"passenger-{passengerIndex}-type", "infant");
                Add($"passenger-{passengerIndex}-title", titles[new Random().Next(0, titles.Length)]);
                Add($"passenger-{passengerIndex}-firstname", "In" + i.ToWords());
                Add($"passenger-{passengerIndex}-middlename", "Autotest");
                Add($"passenger-{passengerIndex}-lastname", "Test");
                Add($"passenger-{passengerIndex}-dob", DateTime.Now.AddMonths(-3).AddDays(i));
                passengerIndex++;
            }
            return this;
        }

        public TestData AddContact()
        {
            Add("contact-first-name", "Test");
            Add("contact-lastname-name", "Autotest");
            Add("contact-email", "autotest.byojet@gmail.com");
            Add("contact-mobile", "0421555777");

            return this;
        }

        public TestData AddUkAddress()
        {
            Add("street-number", "Flat 95");
            Add("street-name", "North End House, Fitzjames Avenue");
            Add("suburb", "London");
            Add("state", "London");
            Add("postcode", "W14 0RY");
            Add("country","uk");

            return this;
        }

        public TestData AddVisaPayment(string formOfPayment)
        {
            Add("card-brand", "visa");
            Add("card-type", "credit");
            Add("card-number", "4111111111111111");
            Add("card-holder", "MR BYOJET AUTOTEST");
            Add("card-cvv", "123");
            Add("card-expiry-month", "10");
            Add("card-expiry-year", DateTime.Now.AddYears(2).Year);
            
            return this;
        }
    }
}
