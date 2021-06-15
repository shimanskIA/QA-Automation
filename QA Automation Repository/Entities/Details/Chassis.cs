using System;
using Task4.Interfaces;

namespace Task4.Entities.Details
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

        public override bool Equals(object obj)
        {
            if (obj.GetType().Equals(typeof(Chassis)))
            {
                if ((obj as Chassis).AmountOfWheels == AmountOfWheels &&
                    (obj as Chassis).MaximalLoad - MaximalLoad < 1e-10 &&
                    (obj as Chassis).SerialNumber == SerialNumber)
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
            return HashCode.Combine(AmountOfWheels, Math.Round(MaximalLoad, 5), SerialNumber);
        }

        public string GetInformation()
        {
            return "chassis with " + AmountOfWheels + " wheels, maximal load of " + MaximalLoad + " kilograms and serial number: " + SerialNumber;
        }
    }
}
