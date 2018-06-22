using System;

namespace Jetmax.Testing.Gui.Core
{
    public class LogEvent
    {
        public DateTime EventDate { get; set; }
        public string Classification { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return $"{EventDate:s} {Classification} {Message}";
        }
    }
}