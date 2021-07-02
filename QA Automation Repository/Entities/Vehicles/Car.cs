using Task4new.Enums;
using Task4new.Entities.Details;

namespace Task4new.Entities.Vehicles
{
    public class Car : Vehicle
    {
        public byte AmountOfPassengerPlaces { get; set; }

        public Car(ManufacturersForTransmissionsAndVehicles manufacturer, Engine engine, Chassis chassis, Transmission transmission, byte amountOfPassengerPlaces) : base(manufacturer, engine, chassis, transmission)
        {
            AmountOfPassengerPlaces = amountOfPassengerPlaces;
        }

        public Car()
        {
            AmountOfPassengerPlaces = default;
        }

        public override string GetInformation()
        {
            return "A car" + base.GetInformation() + ", that can also carry " + AmountOfPassengerPlaces + " passengers";
        }
    }
}