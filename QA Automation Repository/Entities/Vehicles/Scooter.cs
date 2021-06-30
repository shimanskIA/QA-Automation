using System;
using Task4.Enums;
using Task4.Entities.Details;

namespace Task4.Entities.Vehicles
{
    [Serializable]
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
