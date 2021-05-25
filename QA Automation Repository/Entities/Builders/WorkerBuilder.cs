using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace HW7.Entities.Builders
{
    public abstract class WorkerBuilder<T> : PersonBuilder<T>
    {
        public void FillTheWorkerParameters(Dictionary<string, string> parameters, XmlNode xmlNode)
        {
            base.FillThePersonParameters(parameters, xmlNode);
            XmlNode attribute = xmlNode.Attributes.GetNamedItem("experience");
            if (attribute != null)
            {
                parameters.Add("experience", attribute.Value);
            }
            attribute = xmlNode.Attributes.GetNamedItem("loan");
            if (attribute != null)
            {
                parameters.Add("loan", attribute.Value);
            }
            attribute = xmlNode.Attributes.GetNamedItem("administrational_duties");
            if (attribute != null)
            {
                parameters.Add("administrational_duties", attribute.Value);
            }
        }
    }
}
