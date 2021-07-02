namespace Task3.Helpers
{
    public class ConvertionHelper
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
    }
}
