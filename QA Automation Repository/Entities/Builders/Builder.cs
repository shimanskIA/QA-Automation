using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace HW7.Entities.Builders
{
    public abstract class Builder<T>
    {
        public abstract List<T> Build(XmlDocument xmlDocument);
    }
}
