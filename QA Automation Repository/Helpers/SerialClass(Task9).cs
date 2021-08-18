using Task8.Enums;

namespace Task8.Helpers
{
    public class SerialClass // a class created to enable serialization of an object of anonymous class that appears in one of linq statementns
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
