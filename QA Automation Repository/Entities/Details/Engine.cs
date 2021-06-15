using System;
using Task4.Helpers;
using Task4.Interfaces;

namespace Task4.Entities.Details
{
    class Engine : IReadable
    {
        public int Power { get; set; }
        public double Volume { get; set; }
        public EngineTypes EngineType { get; set; }
        public int SerialNumber { get; set; }

        public Engine(int power, double volume, EngineTypes engineType, int serialNumber)
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
                    (obj as Engine).Volume - Volume < 1e-10 && 
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
            string tmp = Volume.ToString();
            int index = tmp.IndexOf(".");
            tmp.Remove(index + 5);
            return HashCode.Combine(Power, tmp, EngineType, SerialNumber);
        }

        public string GetInformation()
        {
            return EngineType + " engine of " + Volume + " liters with " + Power + " horse powers and serial number: " + SerialNumber; 
        }
    }
}
