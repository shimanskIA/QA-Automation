using System;
using System.Collections.Generic;
using System.Text;

namespace HW3
{
    class Lorry : Vehicle, IReadable, ICloneable
    {
        public double LiftingCapacity { get; set; } // in kilograms
        public Lorry(string manufacturer, double engineVolume, string transmissionType, double maximalSpeed, double liftingCapacity) : base(manufacturer, engineVolume, transmissionType, maximalSpeed)
        {
            LiftingCapacity = liftingCapacity;
        }

        public object Clone() // method performing deep copy
        {
            return new Lorry(Manufacturer, EngineVolume, TransmissionType, MaximalSpeed, LiftingCapacity);
        }

        public string GetFullInfo() // method showing info
        {
            return "That's a " + Manufacturer + " lorry with engine of " + EngineVolume + " liters, " + TransmissionType + " type transmission, " + MaximalSpeed + " of maximal speed that can also carry " + LiftingCapacity + " kilograms of weight";
        }
    }
}
