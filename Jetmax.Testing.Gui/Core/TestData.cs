using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var valueExists = Dictionary.TryGetValue(key, out var outVal);
            if (valueExists)
            {
                throw new Exception($"Test data with key [{key}] already exists");
            }
            else
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
