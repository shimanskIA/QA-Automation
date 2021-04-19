using System;
using System.Collections.Generic;

namespace HW2
{
    class Program
    {
        static void Main(string[] args)
        {
            int symbol_length = FindLongestString(args); // finding the longest substring in which characters are not repeated
            if (symbol_length == 0)
            {
                Console.WriteLine("You've entered more than 1 or less than 1 string"); // in case of wrong input
            }
            else
            {
                Console.WriteLine(symbol_length);
            }
        }

        static int FindLongestString(string[] typed_string)
        {
            if (typed_string.Length > 1)
            {
                return 0;
            }
            else
            {
                int max_length = -1;
                for (int j = 0; j < typed_string[0].Length; j++)
                {
                    if (j + max_length > typed_string[0].Length)
                    {
                        break;
                    }
                    max_length = FindLongestStringStartingFormAnElementNumber(j, typed_string[0], max_length); // finding the longest substring starting at a given element number
                }
                return max_length;
            }
        }

        static int FindLongestStringStartingFormAnElementNumber (int element_number, string typed_string, int previous_max_length)
        {
            int local_max_length = 0;
            string symbol_array = "";
            for (int i = element_number; i < typed_string.Length; i++)
            {
                if (i == element_number)
                {
                    symbol_array = symbol_array + typed_string[i];
                    local_max_length++;
                }
                else
                {
                    if (symbol_array.Contains(typed_string[i]))
                    {
                        if (local_max_length > previous_max_length)
                        {
                            previous_max_length = local_max_length;
                        }
                        break;
                    }
                    else
                    {
                        symbol_array = symbol_array + typed_string[i];
                        local_max_length++;
                    }
                    if (i == typed_string.Length - 1)
                    {
                        if (local_max_length > previous_max_length)
                        {
                            return local_max_length;
                        }
                    }
                }
            }
            return previous_max_length;
        }
    }
}
