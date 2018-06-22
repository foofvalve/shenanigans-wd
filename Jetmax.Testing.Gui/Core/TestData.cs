using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public void Add(TestParams testParams)
        {
            var paramsAsDict = testParams.GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .ToDictionary(prop => prop.Name, prop => prop.GetValue(testParams, null));

            foreach (var param in paramsAsDict)
            {
                Add(param.Key, param.Value);
            }
        }

        public void Add(string key, object value)
        {
            var valueExists = Dictionary.TryGetValue(key, out var outVal);
            if (valueExists)
            {
                throw new Exception($"Test data with key [{key}] already exists");
            }

            Dictionary[key] = value;
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
            var valueExists = Dictionary.TryGetValue(key, out var outVal);
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
    }
}
