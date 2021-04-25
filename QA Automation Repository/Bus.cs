using System;
using System.Collections.Generic;
using System.Text;

namespace HW3
{
    class Bus : Vehicle
    {
        public int _amountOfPassengerPlaces { get; set; } 
        public byte _ecologicalLevel { get; set; } 
        public Bus(string manufacturer, double engineVolume, string transmissionType, double maximalSpeed, int amountOfPassengerPlaces, byte ecologicalLevel) : base(manufacturer, engineVolume, transmissionType, maximalSpeed)
        {
            _amountOfPassengerPlaces = amountOfPassengerPlaces;
            _ecologicalLevel = ecologicalLevel;
        }

        public override Vehicle Clone() // method to perform deep copy
        {
            return new Bus(_manufacturer, _engineVolume, _transmissionType, _maximalSpeed, _amountOfPassengerPlaces, _ecologicalLevel);
        }

        public override string GetFullInfo() // method to show info
        {
            return "That's a " + _manufacturer + " bus with engine of " + _engineVolume + " liters, " + _transmissionType + " type transmission, " + _maximalSpeed + " of maximal speed that can carry " + _amountOfPassengerPlaces + " passengers and has " + _ecologicalLevel + "th ecological level";
        }
    }
}
