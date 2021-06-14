using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public class Helpers
    {
        public static int FindLongestString(string[] inputString) // methode finding the longest substring in which characters are not repeated
        {
            if (inputString.Length > 1  || inputString.Length == 0 || inputString[0] == null)
            {
                return 0;
            }
            else
            {
                int maxLength = 0;
                for (int j = 0; j < inputString[0].Length; j++)
                {
                    if (j + maxLength > inputString[0].Length)
                    {
                        break;
                    }
                    var tempLength = FindLongestStringStartingFormAnElementNumber(j, inputString[0]); // finding the longest substring starting at a given element number
                    if (tempLength > maxLength)
                    {
                        maxLength = tempLength;
                    }
                }
                return maxLength;
            }
        }

        public static int FindLongestStringStartingFormAnElementNumber(int element_number, string inputString) // methode finding the longest substring starting at a given element number
        {
            if (inputString != null)
            {
                int maxLength = 0;
                string symbolArray = "";
                for (int i = element_number; i < inputString.Length; i++)
                {
                    if (i == element_number)
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
