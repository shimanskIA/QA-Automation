//using System;
//using System.Xml.Serialization;
using Task4.Enums;
using Task4.Entities.Details;
//using Task4.Helpers;
using Task4.Interfaces;

namespace Task4.Entities.Vehicles
{
    /*[Serializable]
    [XmlInclude(typeof(Car))]
    [XmlInclude(typeof(Bus))]
    [XmlInclude(typeof(Lorry))]
    [XmlInclude(typeof(Scooter))]*/
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
