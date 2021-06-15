using System;
using Task4.Interfaces;

namespace Task4.Entities.Details
{
    class Chassis : IReadable
    {
        public int AmountOfWheels { get; set; }
        public double MaximalLoad { get; set; }
        public int SerialNumber { get; set; }

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
            string tmp = MaximalLoad.ToString();
            int index = tmp.IndexOf(".");
            tmp.Remove(index + 5);
            return HashCode.Combine(AmountOfWheels, tmp, SerialNumber);
        }

        public string GetInformation()
        {
            return "chassis with " + AmountOfWheels + " wheels, maximal load of " + MaximalLoad + " kilograms and serial number: " + SerialNumber;
        }
    }
}
