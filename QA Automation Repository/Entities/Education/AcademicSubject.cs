using HW7.Entities.People;
using HW7.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace HW7.Entities.Education
{
    public class AcademicSubject : ISerializable<AcademicSubject>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCreditSubject { get; set; }
        private static int AmountOfObjects { get; set; } = 0;
        
        public AcademicSubject(string name, string description, bool isCreditSubject)
        {
            Name = name;
            Description = description;
            IsCreditSubject = isCreditSubject;
            Id = AmountOfObjects;
            AmountOfObjects++;
        }

        public void Serialize()
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load("C://Users//Наташа Лапушка//Desktop//QA Automation//Homework 7//HW7//HW7//DAL//Subjects.xml");
            XmlElement xmlRoot = xmlDocument.DocumentElement;
            XmlElement subjectElement = xmlDocument.CreateElement("subject");
            XmlAttribute idAttribute = xmlDocument.CreateAttribute("id");
            XmlAttribute nameAttribute = xmlDocument.CreateAttribute("name");
            XmlAttribute descriptionAttribute = xmlDocument.CreateAttribute("description");
            XmlAttribute creditAttribute = xmlDocument.CreateAttribute("is_credit_subject");

            XmlText idText = xmlDocument.CreateTextNode(Id.ToString());
            XmlText nameText = xmlDocument.CreateTextNode(Name);
            XmlText descriptionText = xmlDocument.CreateTextNode(Description);
            XmlText iscreditText = xmlDocument.CreateTextNode(IsCreditSubject.ToString());

            idAttribute.AppendChild(idText);
            nameAttribute.AppendChild(nameText);
            descriptionAttribute.AppendChild(descriptionText);
            creditAttribute.AppendChild(iscreditText);

            subjectElement.Attributes.Append(idAttribute);
            subjectElement.Attributes.Append(nameAttribute);
            subjectElement.Attributes.Append(descriptionAttribute);
            subjectElement.Attributes.Append(creditAttribute);
            xmlRoot.AppendChild(subjectElement);
            xmlDocument.Save("C://Users//Наташа Лапушка//Desktop//QA Automation//Homework 7//HW7//HW7//DAL//Subjects.xml");
        }

        public List<AcademicSubject> Deserealize()
        {
            return new List<AcademicSubject>();
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public override bool Equals(object subject)
        {
            if (subject.GetType() == typeof(AcademicSubject))
            {
                if (subject.GetHashCode() == Id)
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
