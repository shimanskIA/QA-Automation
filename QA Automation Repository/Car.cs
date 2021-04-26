using System;
using System.Collections.Generic;
using System.Text;

namespace HW3
{
    class Car : Vehicle, IReadable, ICloneable
    {
        public byte AmountOfPassengerPlaces { get; set; } // should be less than 255
        public Car(string manufacturer, double engineVolume, string transmissionType, double maximalSpeed, byte amountOfPassengerPlaces) : base (manufacturer, engineVolume, transmissionType, maximalSpeed)
        {
            AmountOfPassengerPlaces = amountOfPassengerPlaces;
        }
        
        public object Clone() // method to perform deep copy
        {
            return new Car(Manufacturer, EngineVolume, TransmissionType, MaximalSpeed, AmountOfPassengerPlaces);
        }

        public string GetFullInfo() // method to show info
        {
            return "That's a " + Manufacturer + " car with engine of " + EngineVolume + " liters, " + TransmissionType + " type transmission, " + MaximalSpeed + " of maximal speed that can also carry " + AmountOfPassengerPlaces + " passengers";
        }
    }
}
