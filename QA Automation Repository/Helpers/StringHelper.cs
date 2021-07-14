using System;
using System.Collections.Generic;
using System.Text;

namespace Task11
{
    public class StringHelper
    {
        public static int FindLongestStringLength(string inputString) 
        {
            if (inputString != null)
            {
                int maxLength = 0;
                for (int j = 0; j < inputString.Length; j++)
                {
                    if (j + maxLength > inputString.Length)
                    {
                        break;
                    }
                    var tempLength = FindLongestStringLengthStartingFormAnElementNumber(j, inputString); 
                    if (tempLength > maxLength)
                    {
                        maxLength = tempLength;
                    }
                }
                return maxLength;
            }
            else
            {
                return 0;
            }
        }

        public static int FindLongestStringLengthWithTheSameElements(string inputString, Func<int, string, char> getNext)
        {
            if (inputString != null)
            {
                int maxLength = 0;
                int intermediateMaxLength = 0;
                char actualRepeatingSymbol = getNext(0, inputString);

                for (int j = 0; j < inputString.Length; j++)
                {
                    if (actualRepeatingSymbol == inputString[j])
                    {
                        intermediateMaxLength++;
                    }
                    else
                    {   
                        if (intermediateMaxLength > maxLength)
                        {
                            maxLength = intermediateMaxLength;
                        }
                        intermediateMaxLength = 0;
                        actualRepeatingSymbol = getNext(j + 1, inputString);
                    }
                }
                if (intermediateMaxLength > maxLength)
                {
                    maxLength = intermediateMaxLength;
                }
                return maxLength;
            }
            else
            {
                return 0;
            }
        }

        private static int FindLongestStringLengthStartingFormAnElementNumber(int elementNumber, string inputString)
        {
            if (inputString != null)
            {
                int maxLength = 0;
                string symbolArray = "";
                for (int i = elementNumber; i < inputString.Length; i++)
                {
                    if (i == elementNumber)
                    {
                        symbolArray += inputString[i];
                        maxLength++;
                    }
                    else
                    {
                        if (!symbolArray.Contains(inputString[i]))
                        {
                            symbolArray += inputString[i];
                            maxLength++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                return maxLength;
            }
            else
            {
                return 0;
            }
        }

        public static char GetNextSymbol(int elementNumber, string inputString)
        {
            char symbol = (char)0;
            for (int i = elementNumber; i < inputString.Length; i++)
            {
                if (inputString[i] >= 65 && inputString[i] <= 90 || inputString[i] >= 97 && inputString[i] <= 122)
                {
                    symbol = inputString[i];
                    return symbol;
                }
            }
            return symbol;
        }

        public static char GetNextNumber(int elementNumber, string inputString)
        {
            char number = (char)0;
            for (int i = elementNumber; i < inputString.Length; i++)
            {
                if (inputString[i] >= 48 && inputString[i] <= 57)
                {
                    number = inputString[i];
                    return number;
                }
            }
            return number;
        }
    }
}
