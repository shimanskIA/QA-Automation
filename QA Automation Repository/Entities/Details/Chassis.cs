using Task4new.Interfaces;

namespace Task4new.Entities.Details
{
    public class Chassis : IReadable
    {
        public int AmountOfWheels { get; set; }

        public double MaximalLoad { get; set; } // in kilograms

        public int SerialNumber { get; set; } // 7 numbers

        public Chassis(int amountOfWheels, double maximalLoad, int serialNumber)
        {
            AmountOfWheels = amountOfWheels;
            MaximalLoad = maximalLoad;
            SerialNumber = serialNumber;
        }

        public Chassis()
        {
            AmountOfWheels = default;
            MaximalLoad = default;
            SerialNumber = default;
        }

        public string GetInformation()
        {
            return "chassis with " + AmountOfWheels + " wheels, maximal load of " + MaximalLoad + " kilograms and serial number: " + SerialNumber;
        }
    }
}