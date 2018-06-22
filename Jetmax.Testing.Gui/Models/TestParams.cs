using System;

namespace Jetmax.Testing.Gui.Models
{
    public class TestParams
    {
        public int Adults { get; set; }
        public int Children { get; set; } = 0;
        public int Infants { get; set; } = 0;
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
    }
}
