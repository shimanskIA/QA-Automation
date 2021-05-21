using System;
using System.Collections.Generic;
using System.Text;

namespace HW7.Entities.Builders
{
    abstract class Builder
    {
        public Builder()
        {

        }

        public abstract Builder Build();
    }
}
