using System;
using System.Collections.Generic;
using System.Text;

namespace Task4.Helpers
{
    public class SerialClass
    {
        public EngineTypes EngineType { get; set; }
        public uint SerialNumber { get; set; }
        public uint Power { get; set; }

        public SerialClass(EngineTypes engineType, uint serialNumber, uint power)
        {
            EngineType = engineType;
            SerialNumber = serialNumber;
            Power = power;
        }

        public SerialClass()
        {
            EngineType = default;
            SerialNumber = default;
            Power = default;
        }
    }
}
