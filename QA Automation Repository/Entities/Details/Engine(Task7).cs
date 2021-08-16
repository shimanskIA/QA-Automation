using System;
using Task4.Enums;
using Task4.Interfaces;

namespace Task4.Entities.Details
{
    [Serializable]
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

        public override bool Equals(object obj)
        {
            if (obj.GetType().Equals(typeof(Engine)))
            {
                if ((obj as Engine).Power == Power &&
                    Math.Abs((obj as Engine).Volume - Volume) < 1e-10 &&
                    (obj as Engine).EngineType == EngineType &&
                    (obj as Engine).SerialNumber == SerialNumber)
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
            return HashCode.Combine(Power, Math.Round(Volume, 5), EngineType, SerialNumber);
        }

        public string GetInformation()
        {
            return EngineType + " engine of " + Volume + " liters with " + Power + " horse powers and serial number: " + SerialNumber; 
        }
    }
}
