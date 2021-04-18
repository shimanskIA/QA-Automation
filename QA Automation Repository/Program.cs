using System;
using System.Collections.Generic;

namespace HW2
{
    class Program
    {
        static void Main(string[] args)
        {
            int symbol_length = ConvertString(args);
            if (symbol_length == 0)
            {
                Console.WriteLine("You've entered more than 1 or less than 1 string");
            }
            else
            {
                Console.WriteLine(symbol_length);
            }
        }

        static int ConvertString(string[] args)
        {
            if (args.Length > 1)
            {
                return 0;
            }
            else
            {
                int max_length = -1;
                int length = args[0].Length;
                for (int j = 0; j < length; j++)
                {
                    if (j + max_length > length)
                    {
                        break;
                    }
                    int local_max_length = 0;
                    string symbol_array = "";
                    for (int i = j; i < length; i++)
                    {
                        if (i == j)
                        {
                            symbol_array = symbol_array + args[0][i];
                            local_max_length++;
                        }
                        else
                        {
                            if (symbol_array.Contains(args[0][i]))
                            {
                                if (local_max_length > max_length)
                                {
                                    max_length = local_max_length;
                                    local_max_length = 0;
                                }
                                break;
                            }
                            else
                            {
                                symbol_array = symbol_array + args[0][i];
                                local_max_length++;
                            }
                            if (i == length - 1)
                            {
                                if (local_max_length > max_length)
                                {
                                    return local_max_length;
                                }
                            }
                        }
                    }
                }
                return max_length;
            }
        }
    }
}
