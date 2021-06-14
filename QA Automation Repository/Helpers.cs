using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public class Helpers
    {
        public static string ConvertFrom10(int number, int notation)
        {
            if (number >= 0 && notation > 1)
            {
                int newNumber = number / notation;
                int notationElement = number % notation;
                string tmp = "";
                if (newNumber != 0)
                {
                    tmp = ConvertFrom10(newNumber, notation).ToString();
                }
                return tmp + notationElement.ToString();
            }
            else
            {
                return "There's no sense in choosing notation less than 1 or you've chosen negative number";
            }
        }
    }
}
