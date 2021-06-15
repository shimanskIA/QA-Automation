using System;
using System.Collections.Generic;
using System.Text;

namespace HW3
{
    class Motorbike : Vehicle, IReadable, ICloneable
    {
        public double TimeFrom0To100 { get; set; } // time to reach 100 kilometers per hour in seconds
        public Motorbike(string manufacturer, double engineVolume, string transmissionType, double maximalSpeed, double timeFrom0To100) : base(manufacturer, engineVolume, transmissionType, maximalSpeed)
        {
            TimeFrom0To100 = timeFrom0To100;
        }

        public object Clone() // method to perform deep copy
        {
            return new Motorbike(Manufacturer, EngineVolume, TransmissionType, MaximalSpeed, TimeFrom0To100);
        }

        public string GetFullInfo() // method to show info
        {
            return "That's a " + Manufacturer + " motorbike with engine of " + EngineVolume + " liters, " + TransmissionType + " type transmission, " + MaximalSpeed + " of maximal speed that can reach 100 km/h just in " + TimeFrom0To100 + " seconds";
        }
    }
}
