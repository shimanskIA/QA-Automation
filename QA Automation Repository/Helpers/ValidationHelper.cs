using System;

namespace Task3.Helpers
{
    public class ValidationHelper
    {
        public static bool Validate(string inputString1, string inputString2)
        {
            if (uint.TryParse(inputString1, out _) && uint.TryParse(inputString2, out uint convertedStringToInt))
            {
                if (convertedStringToInt >= 2 && convertedStringToInt <= 20)
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
