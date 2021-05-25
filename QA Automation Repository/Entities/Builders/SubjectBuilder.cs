using HW7.Entities.Education;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace HW7.Entities.Builders
{
    class SubjectBuilder : Builder<AcademicSubject>
    {
        public override List<AcademicSubject> Build(XmlDocument xmlDocument)
        {
            List<AcademicSubject> subjects = new List<AcademicSubject>();
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            XmlElement xmlRoot = xmlDocument.DocumentElement;
            foreach (XmlNode xmlNode in xmlRoot)
            {
                if (xmlNode.Attributes.Count > 0)
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
                    attribute = xmlNode.Attributes.GetNamedItem("description");
                    if (attribute != null)
                    {
                        parameters.Add("description", attribute.Value);
                    }
                    attribute = xmlNode.Attributes.GetNamedItem("is_credit_subject");
                    if (attribute != null)
                    {
                        parameters.Add("is_credit_subject", attribute.Value);
                    }
                    subjects.Add(new AcademicSubject(Convert.ToInt32(parameters["id"]), parameters["name"], parameters["description"], Convert.ToBoolean(parameters["is_credit_subject"])));
                }
                parameters.Clear();
            }
            return subjects;
        }
    }
}
