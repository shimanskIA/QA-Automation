using Task4new.Enums;
using Task4new.Entities.Details;

namespace Task4new.Entities.Vehicles
{
    public class Scooter : Vehicle
    {
        public double TimeFrom0To100 { get; set; } // time to reach 100 kilometers per hour in seconds

        public Scooter(ManufacturersForTransmissionsAndVehicles manufacturer, Engine engine, Chassis chassis, Transmission transmission, double timeFrom0To100) : base(manufacturer, engine, chassis, transmission)
        {
            TimeFrom0To100 = timeFrom0To100;
        }

        public Scooter()
        {
            TimeFrom0To100 = default;
        }

        public override string GetInformation()
        {
            return "A scooter" + base.GetInformation() + ", that can reach 100 km/h in just " + TimeFrom0To100 + " seconds, wow!";
        }
    }
}
