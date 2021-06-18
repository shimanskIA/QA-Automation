using System;
using Task4.Entities.Details;
using Task4.Helpers;

namespace Task4.Entities.Vehicles
{
    [Serializable]
    public class Lorry : Vehicle
    {
        public double LiftingCapacity { get; set; } // in kilograms

        public Lorry(Manufacturers manufacturer, Engine engine, Chassis chassis, Transmission transmission, double liftingCapacity) : base(manufacturer, engine, chassis, transmission)
        {
            LiftingCapacity = liftingCapacity;
        }

        public Lorry()
        {
            LiftingCapacity = default;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType().Equals(typeof(Lorry)))
            {
                if (Math.Abs((obj as Lorry).LiftingCapacity - LiftingCapacity) < 1e-10 &&
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
            return HashCode.Combine(base.GetHashCode(), Math.Round(LiftingCapacity, 5));
        }

        public override string GetInformation() // method to get infos about this lorry
        {
            return "A lorry" + base.GetInformation() + ", that can also carry " + LiftingCapacity + " kilogramms";
        }
    }
}
