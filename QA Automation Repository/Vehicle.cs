using System;
using System.Collections.Generic;
using System.Text;

namespace HW3
{
    abstract class Vehicle 
    {
        protected string Manufacturer { get; set; }
        protected double EngineVolume { get; set; } // in liters
        protected string TransmissionType { get; set; } // amount of wheels frontside and backside
        protected double MaximalSpeed { get; set; } // in kilometers per hour

        public Vehicle(string manufacturer, double engineVolume, string transmissionType, double maximalSpeed)
        {
            Manufacturer = manufacturer;
            EngineVolume = engineVolume;
            TransmissionType = transmissionType;
            MaximalSpeed = maximalSpeed;
        }
  
    }
}
