using System;
using System.Collections.Generic;
using System.Text;

namespace HW3
{
    class Motorbike : Vehicle
    {
        public double _timeFrom0To100 { get; set; } // time to reach 100 kilometers per hour in seconds
        public Motorbike(string manufacturer, double engineVolume, string transmissionType, double maximalSpeed, double timeFrom0To100) : base(manufacturer, engineVolume, transmissionType, maximalSpeed)
        {
            _timeFrom0To100 = timeFrom0To100;
        }

        public override Vehicle Clone() // method to perform deep copy
        {
            return new Motorbike(_manufacturer, _engineVolume, _transmissionType, _maximalSpeed, _timeFrom0To100);
        }

        public override string GetFullInfo() // method to show info
        {
            return "That's a " + _manufacturer + " motorbike with engine of " + _engineVolume + " liters, " + _transmissionType + " type transmission, " + _maximalSpeed + " of maximal speed that can reach 100 km/h just in " + _timeFrom0To100 + " seconds";
        }
    }
}
