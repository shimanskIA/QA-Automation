using System;

namespace Task3
{
    public class Helpers
    {
        public static string ConvertFrom10(uint number, uint notation)
        {
            uint newNumber = number / notation;
            uint notationElement = number % notation;
            string tmp = "";
            if (newNumber != 0)
            {
                tmp = ConvertFrom10(newNumber, notation).ToString();
            }
            return tmp + notationElement.ToString();
        }

        public static bool Validate(string value1, string value2)
        {
            if (uint.TryParse(value1, out _) && uint.TryParse(value2, out uint temp2))
            {
                if (temp2 >= 2 && temp2 <= 20)
                {
                    return true;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Input notationt is out of bound (2 : 20)");
                }
            }
            else
            {
                throw new ArgumentException("Input symbols are not even a numbers");
            }
        }
    }
}
