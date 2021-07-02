using Task4new.Enums;
using Task4new.Entities.Details;

namespace Task4new.Entities.Vehicles
{
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
