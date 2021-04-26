using System;
using System.Collections.Generic;
using System.Text;

namespace HW3
{
    class Donkey : IReadable, ICloneable
    {
        public string Name { get; set; }
        public double LiftingCapacity { get; set; }

        public Donkey(string name, double liftingCapacity)
        {
            Name = name;
            LiftingCapacity = liftingCapacity; 
        }

        public object Clone()
        {
            return new Donkey(Name, LiftingCapacity);
        }

        public string GetFullInfo()
        {
            return "That's a donkey named " + Name + " that can carry " + LiftingCapacity + " kilograms of weight";
        }
    }
}
