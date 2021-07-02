using Task4new.Enums;
using Task4new.Entities.Details;

namespace Task4new.Entities.Vehicles
{
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