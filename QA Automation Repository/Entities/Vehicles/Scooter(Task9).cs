using System;
using Task8.Enums;
using Task8.Entities.Details;
using Task8.Exceptions;

namespace Task8.Entities.Vehicles
{
    [Serializable]
    public class Scooter : Vehicle
    {
        private double _timeFrom0To100;
        public double TimeFrom0To100 
        {
            get { return _timeFrom0To100; }
            
            set
            {
                if (value <= 0)
                {
                    throw new InitializeException("Unable to initialize an object with this value");
                }
                else
                {
                    _timeFrom0To100 = value;
                }
            }
        } // time to reach 100 kilometers per hour in seconds

        public Scooter(ManufacturersForTransmissionsAndVehicles manufacturer, Engine engine, Chassis chassis, Transmission transmission, double timeFrom0To100) : base(manufacturer, engine, chassis, transmission)
        {
            try
            {
                TimeFrom0To100 = timeFrom0To100;
            }
            catch(InitializeException ex)
            {
                Console.WriteLine(ex.Message);
                TimeFrom0To100 = 1.0;
            }
        }

        public Scooter() : base()
        {
            TimeFrom0To100 = 1.0;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType().Equals(typeof(Scooter)))
            {
                if (Math.Abs((obj as Scooter).TimeFrom0To100 - TimeFrom0To100) < 1e-10 && base.Equals(obj))
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
            return HashCode.Combine(base.GetHashCode(), Math.Round(TimeFrom0To100, 5));
        }

        public override string GetInformation()
        {
            return "A scooter" + base.GetInformation() + ", that can reach 100 km/h in just " + TimeFrom0To100 + " seconds, wow!";
        }
    }
}
