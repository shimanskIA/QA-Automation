using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public class Helper
    {
        public static int FindLongestStringLength(string inputString) // methode finding the longest substring in which characters are not repeated
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
                    var tempLength = FindLongestStringLengthStartingFormAnElementNumber(j, inputString); // finding the longest substring starting at a given element number
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

        public static int FindLongestStringLengthStartingFormAnElementNumber(int elementNumber, string inputString) 
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
    }
}
