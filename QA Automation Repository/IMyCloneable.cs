using System;
using System.Collections.Generic;
using System.Text;

namespace HW4
{
    interface IMyCloneable<T> // user interface for cloning
    {
        T[] Clone();
    }
}
