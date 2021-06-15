using System;
using Task4.Entities.Details;
using Task4.Helpers;
using Task4.Interfaces;

namespace Task4.Entities.Vehicles
{
    public abstract class Vehicle : IReadable
    {
        public Manufacturers Manufacturer { get; set; }
        public Engine VehicleEngine { get; set; }
        public Chassis VehicleChassis { get; set; }
        public Transmission VehicleTransmission { get; set; }

        public Vehicle(Manufacturers manufacturer, Engine engine, Chassis chassis, Transmission transmission)
        {
            Manufacturer = manufacturer;
            VehicleEngine = engine;
            VehicleChassis = chassis;
            VehicleTransmission = transmission;
        }

        public Vehicle()
        {
            Manufacturer = default;
            VehicleEngine = default;
            VehicleChassis = default;
            VehicleTransmission = default;
        }

        public override bool Equals(object obj)
        {
            if ((obj as Vehicle).Manufacturer == Manufacturer &&
                (obj as Vehicle).VehicleEngine.Equals(VehicleEngine) &&
                (obj as Vehicle).VehicleChassis.Equals(VehicleChassis) &&
                (obj as Vehicle).VehicleTransmission.Equals(VehicleTransmission))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(VehicleEngine.GetHashCode(), VehicleChassis.GetHashCode(), VehicleTransmission.GetHashCode(), Manufacturer);
        }

        public virtual string GetInformation() // method to get infos about this vehicle
        {
            return ", produced by " + Manufacturer + " with " + VehicleEngine.GetInformation() + ", " + VehicleChassis.GetInformation() + ", " + VehicleTransmission.GetInformation();
        }
    }

}
