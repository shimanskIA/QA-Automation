using System;
using System.Collections.Generic;
using System.Text;

namespace HW3
{
    abstract class Vehicle 
    {
        protected string _manufacturer { get; set; }
        protected double _engineVolume { get; set; } // in liters
        protected string _transmissionType { get; set; } // amount of wheels frontside and backside
        protected double _maximalSpeed { get; set; } // in kilometers per hour

        public Vehicle(string manufacturer, double engineVolume, string transmissionType, double maximalSpeed)
        {
            _manufacturer = manufacturer;
            _engineVolume = engineVolume;
            _transmissionType = transmissionType;
            _maximalSpeed = maximalSpeed;
        }

        public abstract Vehicle Clone(); // method to perferm deep copy 

        virtual public string GetFullInfo() // method to show info
        {
            return "That's a " + _manufacturer + " vehicle with engine of " + _engineVolume + " liters, " + _transmissionType + " type transmission and " + _maximalSpeed + " of maximal speed";
        }
       
    }
}
