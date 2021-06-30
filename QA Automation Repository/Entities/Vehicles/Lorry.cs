//using System;
using Task4.Enums;
using Task4.Entities.Details;
//using Task4.Helpers;

namespace Task4.Entities.Vehicles
{
    //[Serializable]
    public class Lorry : Vehicle
    {
        public double LiftingCapacity { get; set; } // in kilograms

        public Lorry(ManufacturersForTransmissionsAndVehicles manufacturer, Engine engine, Chassis chassis, Transmission transmission, double liftingCapacity) : base(manufacturer, engine, chassis, transmission)
        {
            LiftingCapacity = liftingCapacity;
        }

        public Lorry()
        {
            LiftingCapacity = default;
        }

        public override string GetInformation() 
        {
            return "A lorry" + base.GetInformation() + ", that can also carry " + LiftingCapacity + " kilogramms";
        }
    }
}
