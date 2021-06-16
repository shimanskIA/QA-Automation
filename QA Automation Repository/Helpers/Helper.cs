using System;

namespace Task5.Helpers
{
    public class Helper
    {
        public static bool Validate(double x, double y, double z)
        {
            if (x >= 0 && y >= 0 && z >= 0)
            {
                return true;
            }
            else
            {
                throw new ArgumentException("coordinates can not have negative values");
            }
        }
    }
}
