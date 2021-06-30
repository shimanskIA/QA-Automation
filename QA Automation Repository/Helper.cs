using System;

namespace Task3
{
    public class Helper
    {
        private static char[] _notationElements = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
        
        public static string ConvertNumberFrom10NotationToAnyOtherNotation(uint number, uint notation)
        {
            uint newNumber = number / notation;
            char notationElement =  _notationElements[number % notation];
            string convertedNumberAtActualIterationAsString = "";
            if (newNumber != 0)
            {
                convertedNumberAtActualIterationAsString = ConvertNumberFrom10NotationToAnyOtherNotation(newNumber, notation);
            }
            return convertedNumberAtActualIterationAsString + notationElement;
        }

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
