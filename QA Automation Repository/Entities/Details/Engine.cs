using Task4new.Enums;
using Task4new.Interfaces;

namespace Task4new.Entities.Details
{
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
