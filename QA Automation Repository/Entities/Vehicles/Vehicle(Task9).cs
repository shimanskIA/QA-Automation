using System;
using System.Xml.Serialization;
using Task8.Enums;
using Task8.Entities.Details;
using Task8.Interfaces;
using Task8.Helpers;

namespace Task8.Entities.Vehicles
{
    [Serializable]
    [XmlInclude(typeof(Car))]
    [XmlInclude(typeof(Bus))]
    [XmlInclude(typeof(Lorry))]
    [XmlInclude(typeof(Scooter))]
    public abstract class Vehicle : IReadable
    {
        [XmlIgnore]
        public int Id { get; set; }
        
        public ManufacturersForTransmissionsAndVehicles Manufacturer { get; set; }
        
        public Engine VehicleEngine { get; set; }
        
        public Chassis VehicleChassis { get; set; }
        
        public Transmission VehicleTransmission { get; set; }

        public Vehicle(ManufacturersForTransmissionsAndVehicles manufacturer, Engine engine, Chassis chassis, Transmission transmission)
        {
            Id = IDController.GetId();
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

        public virtual string GetInformation()
        {
            return ", produced by " + Manufacturer + " with " + VehicleEngine.GetInformation() + ", " + VehicleChassis.GetInformation() + ", " + VehicleTransmission.GetInformation();
        }
    }

}
