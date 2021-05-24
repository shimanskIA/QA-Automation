using HW7.Entities.Education;
using HW7.Entities.People;
using HW7.Helpers;
using HW7.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace HW7.Entities.Departments
{
    public class Faculty : Department
    {
        public string Name { get; set; }
        public List<Specialty> Specialties { get; set; }

        public Faculty(int id, string name, Person departmentHead, List<ScienceWorker> scienceWorkers, List<StaffWorker> staffWorkers, List<Specialty> specialties) : base(id, departmentHead, scienceWorkers, staffWorkers)
        {
            Name = name;
            Specialties = specialties;
        }

        public Faculty(string name, Person departmentHead) : base(departmentHead)
        {
            Name = name;
            Specialties = new List<Specialty>();
        }

        public void Add(Specialty specialty)
        {
            Specialties.Add(specialty);
        }

        public override void Serialize()
        {
            xmlDocument = new XmlDocument();
            xmlDocument.Load("C://Users//Наташа Лапушка//Desktop//QA Automation//Homework 7//HW7//HW7//DAL//Departments.xml");
            XmlElement xmlRoot = xmlDocument.DocumentElement;
            departmentElement = xmlDocument.CreateElement("faculty");
            base.Serialize();
            XmlAttribute nameAttribute = xmlDocument.CreateAttribute("name");

            XmlText nameText = xmlDocument.CreateTextNode(Name);

            XmlElement specialtiesElement = xmlDocument.CreateElement("specialties");
            HelperMethods.FillXMLElement(xmlDocument, specialtiesElement, "specialty", "Id", "id", Specialties);

            nameAttribute.AppendChild(nameText);

            departmentElement.Attributes.Append(nameAttribute);
            departmentElement.AppendChild(specialtiesElement);
            xmlRoot.AppendChild(departmentElement);
            xmlDocument.Save("C://Users//Наташа Лапушка//Desktop//QA Automation//Homework 7//HW7//HW7//DAL//Departments.xml");
        }
    }
}
