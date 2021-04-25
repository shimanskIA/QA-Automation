using System;
using System.Collections.Generic;
using System.Text;

namespace HW3
{
    class Car : Vehicle
    {
        public byte _amountOfPassengerPlaces { get; set; } // should be less than 255
        public Car(string manufacturer, double engineVolume, string transmissionType, double maximalSpeed, byte amountOfPassengerPlaces) : base (manufacturer, engineVolume, transmissionType, maximalSpeed)
        {
            _amountOfPassengerPlaces = amountOfPassengerPlaces;
        }
        
        public override Vehicle Clone() // method to perform deep copy
        {
            return new Car(_manufacturer, _engineVolume, _transmissionType, _maximalSpeed, _amountOfPassengerPlaces);
        }

        public override string GetFullInfo() // method to show info
        {
            return "That's a " + _manufacturer + " car with engine of " + _engineVolume + " liters, " + _transmissionType + " type transmission, " + _maximalSpeed + " of maximal speed that can also carry " + _amountOfPassengerPlaces + " passengers";
        }
    }
}
