using HW7.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace HW7.Entities.Education
{
    public class Specialty : ISerializable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<AcademicSubject> Subjects { get; set; }
        private static int AmountOfObjects { get; set; } = 0;
        private static List<int> ForbiddenIDs { get; set; } = new List<int>();

        public Specialty(int id, string name, List<AcademicSubject> subjects) 
        {
            Name = name;
            Subjects = subjects;
            Id = id;
            if (!ForbiddenIDs.Contains(id))
            {
                ForbiddenIDs.Add(id);
            }
        }

        public Specialty(string name)
        {
            Name = name;
            while (ForbiddenIDs.Contains(AmountOfObjects))
            {
                AmountOfObjects++;
            }
            Id = AmountOfObjects;
            ForbiddenIDs.Add(Id);
            AmountOfObjects++;
            Subjects = new List<AcademicSubject>();
        }

        public void Add(AcademicSubject subject)
        {
            Subjects.Add(subject);
        }

        public void Serialize()
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load("C://Users//Наташа Лапушка//Desktop//QA Automation//Homework 7//HW7//HW7//DAL//Specialties.xml");
            XmlElement xmlRoot = xmlDocument.DocumentElement;
            XmlElement specialtyElement = xmlDocument.CreateElement("specialty");

            XmlAttribute idAttribute = xmlDocument.CreateAttribute("id");
            XmlAttribute nameAttribute = xmlDocument.CreateAttribute("name");

            XmlText idText = xmlDocument.CreateTextNode(Id.ToString());
            XmlText nameText = xmlDocument.CreateTextNode(Name);
            XmlElement subjectsElement = xmlDocument.CreateElement("subjects");
            foreach (var subject in Subjects)
            {
                XmlElement subjectElement = xmlDocument.CreateElement("subject");
                XmlText subjectText = xmlDocument.CreateTextNode(subject.Id.ToString());
                XmlAttribute subjectIdAttribute = xmlDocument.CreateAttribute("id");
                subjectIdAttribute.AppendChild(subjectText);
                subjectElement.Attributes.Append(subjectIdAttribute);
                subjectsElement.AppendChild(subjectElement);
            }

            idAttribute.AppendChild(idText);
            nameAttribute.AppendChild(nameText);

            specialtyElement.Attributes.Append(idAttribute);
            specialtyElement.Attributes.Append(nameAttribute);
            specialtyElement.AppendChild(subjectsElement);
            xmlRoot.AppendChild(specialtyElement);
            xmlDocument.Save("C://Users//Наташа Лапушка//Desktop//QA Automation//Homework 7//HW7//HW7//DAL//Specialties.xml");
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public override bool Equals(object specialty)
        {
            if (specialty.GetType() == typeof(Specialty))
            {
                if (specialty.GetHashCode() == Id)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

    }
}
