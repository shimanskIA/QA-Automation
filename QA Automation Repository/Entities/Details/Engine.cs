using System;
using Task4.Enums;
//using Task4.Helpers;
using Task4.Interfaces;

namespace Task4.Entities.Details
{
    //[Serializable]
    public class Engine : IReadable
    {
        public uint Power { get; set; } // in horse powers

        public double Volume { get; set; } // in liters

        public EngineTypes EngineType { get; set; }

        public uint SerialNumber { get; set; } // 7 numbers

        public Engine(uint power, double volume, EngineTypes engineType, uint serialNumber)
        {
            Power = power;
            Volume = volume;
            EngineType = engineType;
            SerialNumber = serialNumber;
        }

        public Engine()
        {
            Power = default;
            Volume = default;
            EngineType = default;
            SerialNumber = default;
        }

        public string GetInformation()
        {
            return EngineType + " engine of " + Volume + " liters with " + Power + " horse powers and serial number: " + SerialNumber; 
        }
    }
}
