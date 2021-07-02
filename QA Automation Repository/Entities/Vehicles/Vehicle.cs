using Task4new.Enums;
using Task4new.Entities.Details;
using Task4new.Interfaces;

namespace Task4new.Entities.Vehicles
{
    public abstract class Vehicle : IReadable
    {
        public ManufacturersForTransmissionsAndVehicles Manufacturer { get; set; }
        public Engine VehicleEngine { get; set; }
        public Chassis VehicleChassis { get; set; }
        public Transmission VehicleTransmission { get; set; }

        public Vehicle(ManufacturersForTransmissionsAndVehicles manufacturer, Engine engine, Chassis chassis, Transmission transmission)
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

        public virtual string GetInformation()
        {
            return ", produced by " + Manufacturer + " with " + VehicleEngine.GetInformation() + ", " + VehicleChassis.GetInformation() + ", " + VehicleTransmission.GetInformation();
        }
    }
}