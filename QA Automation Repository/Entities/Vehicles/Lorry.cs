using System;
using Task4.Entities.Details;
using Task4.Helpers;

namespace Task4.Entities.Vehicles
{
    class Lorry : Vehicle
    {
        public double LiftingCapacity { get; set; } // in kilograms

        public Lorry(Manufacturers manufacturer, Engine engine, Chassis chassis, Transmission transmission, double liftingCapacity) : base(manufacturer, engine, chassis, transmission)
        {
            LiftingCapacity = liftingCapacity;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType().Equals(typeof(Lorry)))
            {
                if ((obj as Lorry).LiftingCapacity - LiftingCapacity < 1e-10 &&
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
            string tmp = LiftingCapacity.ToString();
            int index = tmp.IndexOf(".");
            tmp.Remove(index + 5);
            return HashCode.Combine(base.GetHashCode(), tmp);
        }

        public override string GetInformation()
        {
            return "A lorry" + base.GetInformation() + ", that can also carry " + LiftingCapacity + " kilogramms";
        }
    }
}
