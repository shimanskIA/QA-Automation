using System;
using System.Collections.Generic;
using System.Text;

namespace HW3
{
    class Lorry : Vehicle
    {
        public double _liftingCapacity { get; set; } // in kilograms
        public Lorry(string manufacturer, double engineVolume, string transmissionType, double maximalSpeed, double liftingCapacity) : base(manufacturer, engineVolume, transmissionType, maximalSpeed)
        {
            _liftingCapacity = liftingCapacity;
        }

        public override Vehicle Clone() // method performing deep copy
        {
            return new Lorry(_manufacturer, _engineVolume, _transmissionType, _maximalSpeed, _liftingCapacity);
        }

        public override string GetFullInfo() // method showing info
        {
            return "That's a " + _manufacturer + " lorry with engine of " + _engineVolume + " liters, " + _transmissionType + " type transmission, " + _maximalSpeed + " of maximal speed that can also carry " + _liftingCapacity + " kilograms of weight";
        }
    }
}
