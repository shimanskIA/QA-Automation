﻿using System;
using Task4.Entities.Details;
using Task4.Helpers;

namespace Task4.Entities.Vehicles
{
    [Serializable]
    public class Car : Vehicle
    {
        public byte AmountOfPassengerPlaces { get; set; } // should be less than 255
        
        public Car(Manufacturers manufacturer, Engine engine, Chassis chassis, Transmission transmission, byte amountOfPassengerPlaces) : base (manufacturer, engine, chassis, transmission)
        {
            AmountOfPassengerPlaces = amountOfPassengerPlaces;
        }

        public Car()
        {
            AmountOfPassengerPlaces = default;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType().Equals(typeof(Car)))
            {
                if ((obj as Car).AmountOfPassengerPlaces == AmountOfPassengerPlaces &&
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
            return HashCode.Combine(base.GetHashCode(), AmountOfPassengerPlaces);
        }

        public override string GetInformation() // method to get infos about this car
        {
            return "A car" + base.GetInformation() + ", that can also carry " + AmountOfPassengerPlaces + " passengers";
        }
    }
}
