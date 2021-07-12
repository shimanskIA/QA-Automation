using System;
using Task8.Enums;
using Task8.Entities.Details;
using Task8.Exceptions;

namespace Task8.Entities.Vehicles
{
    [Serializable]
    public class Car : Vehicle
    {
        private byte _amountOfPassengerPlaces { get; set; }
        public byte AmountOfPassengerPlaces 
        {
            get { return _amountOfPassengerPlaces; }

            set 
            {
                if (value < 0)
                {
                    throw new InitializeException("Unable to initialize an object with this value");
                }
                else
                {
                    _amountOfPassengerPlaces = value;
                }
            } 
        }

        public Car(ManufacturersForTransmissionsAndVehicles manufacturer, Engine engine, Chassis chassis, Transmission transmission, byte amountOfPassengerPlaces) : base(manufacturer, engine, chassis, transmission)
        {
            try
            {
                AmountOfPassengerPlaces = amountOfPassengerPlaces;
            }
            catch(InitializeException ex)
            {
                Console.WriteLine(ex.Message);
                AmountOfPassengerPlaces = default;
            }
        }

        public Car() : base()
        {
            AmountOfPassengerPlaces = default;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType().Equals(typeof(Car)))
            {
                if ((obj as Car).AmountOfPassengerPlaces == AmountOfPassengerPlaces &&
                    base.Equals(obj))
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
