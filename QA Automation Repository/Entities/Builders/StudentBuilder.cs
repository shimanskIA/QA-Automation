using HW7.Entities.Education;
using HW7.Entities.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace HW7.Entities.Builders
{
    class StudentBuilder : PersonBuilder<Student>
    {
        protected List<Specialty> Specialties { get; set; }

        public StudentBuilder(List<Specialty> specialties)
        {
            Specialties = specialties;
        }

        public override List<Student> Build(XmlDocument xmlDocument)
        {
            List<Student> students = new List<Student>();
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            XmlElement xmlRoot = xmlDocument.DocumentElement;
            foreach (XmlNode xmlNode in xmlRoot)
            {
                if (xmlNode.Attributes.Count > 0)
                {
                    base.FillThePersonParameters(parameters, xmlNode);
                    XmlNode attribute = xmlNode.Attributes.GetNamedItem("group");
                    if (attribute != null)
                    {
                        parameters.Add("group", attribute.Value);
                    }
                    attribute = xmlNode.Attributes.GetNamedItem("course");
                    if (attribute != null)
                    {
                        parameters.Add("course", attribute.Value);
                    }
                    List<Specialty> specialties = new List<Specialty>();
                    foreach (XmlNode childNode in xmlNode.ChildNodes)
                    {
                        if (childNode.Name == "specialties")
                        {
                            foreach (XmlNode childOfChild in childNode.ChildNodes)
                            {
                                specialties.AddRange(Specialties.Where(x => x.Id == Convert.ToInt32(childOfChild.Attributes.GetNamedItem("id").Value)));
                            }
                        }
                    }
                    students.Add(new Student(Convert.ToInt32(parameters["id"]), parameters["name"], parameters["surname"], Convert.ToInt32(parameters["age"]),  Convert.ToInt32(parameters["group"]), Convert.ToInt32(parameters["course"]), specialties));
                }
                parameters.Clear();
            }
            return students;
        }
    }
}
