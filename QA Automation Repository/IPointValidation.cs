using System;
using System.Collections.Generic;
using System.Text;

namespace HW5
{
    // interface that check if its possible to create a triangle of the type
    interface IPointValidation
    {
        public bool Validate(Point point1, Point point2, Point point3); // validation methode for points
    }
}