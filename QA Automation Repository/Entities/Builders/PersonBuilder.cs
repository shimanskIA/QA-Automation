using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace HW7.Entities.Builders
{
    public abstract class PersonBuilder<T> : Builder<T>
    {

        public void FillThePersonParameters(Dictionary<string, string> parameters, XmlNode xmlNode)
        {

            XmlNode attribute = xmlNode.Attributes.GetNamedItem("id");
            if (attribute != null)
            {
                parameters.Add("id", attribute.Value);
            }
            attribute = xmlNode.Attributes.GetNamedItem("name");
            if (attribute != null)
            {
                parameters.Add("name", attribute.Value);
            }
            attribute = xmlNode.Attributes.GetNamedItem("surname");
            if (attribute != null)
            {
                parameters.Add("surname", attribute.Value);
            }
            attribute = xmlNode.Attributes.GetNamedItem("age");
            if (attribute != null)
            {
                parameters.Add("age", attribute.Value);
            }
        }
    }
}
