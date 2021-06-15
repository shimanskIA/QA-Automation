using System;
using Task4.Entities.Details;
using Task4.Helpers;

namespace Task4.Entities.Vehicles
{
    class Car : Vehicle
    {
        public byte AmountOfPassengerPlaces { get; set; } // should be less than 255
        
        public Car(Manufacturers manufacturer, Engine engine, Chassis chassis, Transmission transmission, byte amountOfPassengerPlaces) : base (manufacturer, engine, chassis, transmission)
        {
            AmountOfPassengerPlaces = amountOfPassengerPlaces;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType().Equals(typeof(Car)))
            {
                if ((obj as Car).AmountOfPassengerPlaces == AmountOfPassengerPlaces &&
                    (obj as Vehicle).Equals(this))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), AmountOfPassengerPlaces);
        }

        public override string GetInformation()
        {
            return "A car" + base.GetInformation() + ", that can also carry " + AmountOfPassengerPlaces + " passengers";
        }
    }
}
