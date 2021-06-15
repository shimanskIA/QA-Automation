﻿using System;
using Task4.Entities.Details;
using Task4.Helpers;

namespace Task4.Entities.Vehicles
{
    class Bus : Vehicle
    {
        public int AmountOfPassengerPlaces { get; set; }
        public byte EcologicalLevel { get; set; }

        public Bus(Manufacturers manufacturer, Engine engine, Chassis chassis, Transmission transmission, int amountOfPassengerPlaces, byte ecologicalLevel) : base(manufacturer, engine, chassis, transmission)
        {
            AmountOfPassengerPlaces = amountOfPassengerPlaces;
            EcologicalLevel = ecologicalLevel;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType().Equals(typeof(Bus)))
            {
                if ((obj as Bus).AmountOfPassengerPlaces == AmountOfPassengerPlaces &&
                    (obj as Bus).EcologicalLevel == EcologicalLevel &&
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
            return HashCode.Combine(base.GetHashCode(), AmountOfPassengerPlaces, EcologicalLevel);
        }

        public override string GetInformation()
        {
            return "A bus" + base.GetInformation() + ", that can also carry " + AmountOfPassengerPlaces + " passengers and has " + EcologicalLevel + " ecological level";
        }
    }
}
