using System;
using System.Collections.Generic;
using System.Text;

namespace HW3
{
    class Bus : Vehicle, IReadable, ICloneable
    {
        public int AmountOfPassengerPlaces { get; set; } 
        public byte EcologicalLevel { get; set; } 
        public Bus(string manufacturer, double engineVolume, string transmissionType, double maximalSpeed, int amountOfPassengerPlaces, byte ecologicalLevel) : base(manufacturer, engineVolume, transmissionType, maximalSpeed)
        {
            AmountOfPassengerPlaces = amountOfPassengerPlaces;
            EcologicalLevel = ecologicalLevel;
        }

        public object Clone() // method to perform deep copy
        {
            return new Bus(Manufacturer, EngineVolume, TransmissionType, MaximalSpeed, AmountOfPassengerPlaces, EcologicalLevel);
        }

        public string GetFullInfo() // method to show info
        {
            return "That's a " + Manufacturer + " bus with engine of " + EngineVolume + " liters, " + TransmissionType + " type transmission, " + MaximalSpeed + " of maximal speed that can carry " + AmountOfPassengerPlaces + " passengers and has " + EcologicalLevel + "th ecological level";
        }
    }
}
