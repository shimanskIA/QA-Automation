using System;
using Task4.Helpers;
using Task4.Interfaces;

namespace Task4.Entities.Details
{
    [Serializable]
    public class Transmission : IReadable
    {
        public string TransmissionType { get; set; } // like 2x2 or 2x4 or so
        public int AmountOfGears { get; set; }
        public Manufacturers Manufacturer { get; set; }

        public Transmission(string transmissionType, int amountOfGears, Manufacturers manufacturer)
        {
            TransmissionType = transmissionType;
            AmountOfGears = amountOfGears;
            Manufacturer = manufacturer;
        }

        public Transmission()
        {
            TransmissionType = default;
            AmountOfGears = default;
            Manufacturer = default;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType().Equals(typeof(Transmission)))
            {
                if ((obj as Transmission).AmountOfGears == AmountOfGears &&
                    (obj as Transmission).TransmissionType == TransmissionType &&
                    (obj as Transmission).Manufacturer == Manufacturer)
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
            return HashCode.Combine(TransmissionType, AmountOfGears, Manufacturer);
        }

        public string GetInformation()
        {
            return TransmissionType + " transmission with " + AmountOfGears + " gears, pruduced by " + Manufacturer;
        }
    }
}
