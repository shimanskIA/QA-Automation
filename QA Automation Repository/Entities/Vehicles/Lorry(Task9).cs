using System;
using Task8.Enums;
using Task8.Entities.Details;
using Task8.Exceptions;

namespace Task8.Entities.Vehicles
{
    [Serializable]
    public class Lorry : Vehicle
    {
        private double _liftingCapacity;
        public double LiftingCapacity 
        { 
            get { return _liftingCapacity; }
            
            set
            {
                if (value < 0)
                {
                    throw new InitializeException("Unable to initialize an object with this value");
                }
                else
                {
                    _liftingCapacity = value;
                }
            }
             
        } // in kilograms

        public Lorry(ManufacturersForTransmissionsAndVehicles manufacturer, Engine engine, Chassis chassis, Transmission transmission, double liftingCapacity) : base(manufacturer, engine, chassis, transmission)
        {
            try
            {
                LiftingCapacity = liftingCapacity;
            }
            catch(InitializeException ex)
            {
                Console.WriteLine(ex.Message);
                LiftingCapacity = default;
            }
        }

        public Lorry() : base()
        {
            LiftingCapacity = default;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType().Equals(typeof(Lorry)))
            {
                if (Math.Abs((obj as Lorry).LiftingCapacity - LiftingCapacity) < 1e-10 && base.Equals(obj))
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

        public override string GetInformation()
        {
            return "A lorry" + base.GetInformation() + ", that can also carry " + LiftingCapacity + " kilogramms";
        }
    }
}
