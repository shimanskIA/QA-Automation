using System;
using Task8.Enums;
using Task8.Entities.Details;
using Task8.Exceptions;

namespace Task8.Entities.Vehicles
{
    [Serializable]
    public class Bus : Vehicle
    {
        private int _amountOfPassengerPlaces;
        public int AmountOfPassengerPlaces 
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

        private byte _ecologicalLevel;
        public byte EcologicalLevel 
        {
            get { return _ecologicalLevel; }

            set 
            { 
                if (value <= 0 && value >= 10)
                {
                    throw new InitializeException("Unable to initialize an object with this value");
                }
                else
                {
                    _ecologicalLevel = value;
                }
            }
        } // 1, 2, 3 or so

        public Bus(ManufacturersForTransmissionsAndVehicles manufacturer, Engine engine, Chassis chassis, Transmission transmission, int amountOfPassengerPlaces, byte ecologicalLevel) : base(manufacturer, engine, chassis, transmission)
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

            try
            {
                EcologicalLevel = ecologicalLevel;
            }
            catch (InitializeException ex)
            {
                Console.WriteLine(ex.Message);
                EcologicalLevel = 1;
            }
        }

        public Bus() : base()
        {
            AmountOfPassengerPlaces = default;
            EcologicalLevel = 1;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType().Equals(typeof(Bus)))
            {
                if ((obj as Bus).AmountOfPassengerPlaces == AmountOfPassengerPlaces &&
                    (obj as Bus).EcologicalLevel == EcologicalLevel &&
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
            return HashCode.Combine(base.GetHashCode(), AmountOfPassengerPlaces, EcologicalLevel);
        }

        public override string GetInformation()
        {
            return "A bus" + base.GetInformation() + ", that can also carry " + AmountOfPassengerPlaces + " passengers and has " + EcologicalLevel + " ecological level";
        }
    }
}
