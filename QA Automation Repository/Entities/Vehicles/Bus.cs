//using System;
using Task4.Enums;
using Task4.Entities.Details;
//using Task4.Helpers;

namespace Task4.Entities.Vehicles
{
    //[Serializable]
    public class Bus : Vehicle
    {
        public int AmountOfPassengerPlaces { get; set; }
        
        public byte EcologicalLevel { get; set; } // 1, 2, 3 or so

        public Bus(ManufacturersForTransmissionsAndVehicles manufacturer, Engine engine, Chassis chassis, Transmission transmission, int amountOfPassengerPlaces, byte ecologicalLevel) : base(manufacturer, engine, chassis, transmission)
        {
            AmountOfPassengerPlaces = amountOfPassengerPlaces;
            EcologicalLevel = ecologicalLevel;
        }

        public Bus()
        {
            AmountOfPassengerPlaces = default;
            EcologicalLevel = default;
        }

        public override string GetInformation() 
        {
            return "A bus" + base.GetInformation() + ", that can also carry " + AmountOfPassengerPlaces + " passengers and has " + EcologicalLevel + " ecological level";
        }
    }
}
