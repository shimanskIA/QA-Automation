using HW7.Entities.Education;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace HW7.Entities.Builders
{
    class SpecialtyBuilder : Builder<Specialty>
    {
        public List<AcademicSubject> Subjects { get; set; }

        public SpecialtyBuilder(List<AcademicSubject> subjects)
        {
            Subjects = subjects;
        }
        
        public override List<Specialty> Build(XmlDocument xmlDocument)
        {
            List<Specialty> specialties = new List<Specialty>();
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
                    List<AcademicSubject> subjects = new List<AcademicSubject>();
                    foreach (XmlNode childNode in xmlNode.ChildNodes)
                    {
                        if (childNode.Name == "subjects")
                        {
                            foreach (XmlNode childOfChild in childNode.ChildNodes)
                            {
                                subjects.AddRange(Subjects.Where(x => x.Id == Convert.ToInt32(childOfChild.Attributes.GetNamedItem("id").Value)));
                            }
                        }
                    }
                    specialties.Add(new Specialty(Convert.ToInt32(parameters["id"]), parameters["name"], subjects));
                }
                parameters.Clear();
            }
            return specialties;
        }
    }
}
