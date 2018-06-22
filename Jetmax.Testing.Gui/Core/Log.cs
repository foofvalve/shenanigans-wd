using System;
using System.Collections.Generic;
using System.Linq;

namespace Jetmax.Testing.Gui.Core
{
    public class Log
    {
        private static List<LogEvent> _logsEvents;
        private static string _classification;

        public static void Init(string classification)
        {
            _classification = classification;
            _logsEvents = new List<LogEvent>();
        }

        public static void Add(string message)
        {
            _logsEvents.Add(new LogEvent
            {
                EventDate = DateTime.Now, Message = message, Classification = _classification
            });
        }

        public static string Print()
        {
            var entriesStringed = _logsEvents.Select(x => x.ToString());
            var formattedEntries = "TEST DATA" + Environment.NewLine + string.Join(Environment.NewLine, entriesStringed.ToArray());
            Console.WriteLine(formattedEntries);
            return formattedEntries;
        }
    }
}
