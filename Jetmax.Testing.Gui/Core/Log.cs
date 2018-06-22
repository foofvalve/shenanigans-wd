using System;
using System.Collections.Generic;
using System.Linq;

namespace Jetmax.Testing.Gui.Core
{
    public class Log
    {
        private List<LogEvent> _logsEvents;
        private string _classification;

        public void Init(string classification)
        {
            _classification = classification;
            _logsEvents = new List<LogEvent>();
        }

        public void Add(string message)
        {
            _logsEvents.Add(new LogEvent
            {
                EventDate = DateTime.Now, Message = message, Classification = _classification
            });
        }

        public string Print()
        {
            var entriesStringed = _logsEvents.Select(x => x.ToString());
            var formattedEntries = string.Join(Environment.NewLine, entriesStringed.ToArray());
            Console.WriteLine(formattedEntries);
            return formattedEntries;
        }
    }
}
