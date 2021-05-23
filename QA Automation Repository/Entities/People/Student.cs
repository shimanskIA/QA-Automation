using HW7.Entities;
using HW7.Entities.Education;
using HW7.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace HW7.Entities.People
{
    public class Student : Person, ISerializable<Student>
    {
        public int GroupNumber { get; set; }
        public int Course { get; set; }
        public List<Specialty> Specialties { get; set; }
        public Student(string name, string surname, int age, int groupNumber, int course, List<Specialty> specialties) : base (name, surname, age)
        {
            GroupNumber = groupNumber;
            Course = course;
            Specialties = specialties;
        }

        public Student(string name, string surname, int age, int groupNumber, int course) : base (name, surname, age)
        {
            GroupNumber = groupNumber;
            Course = course;
            Specialties = new List<Specialty>();
        }

        public override void Serialize()
        {
            xmlDocument = new XmlDocument();
            xmlDocument.Load("C://Users//Наташа Лапушка//Desktop//QA Automation//Homework 7//HW7//HW7//DAL//Students.xml");
            XmlElement xmlRoot = xmlDocument.DocumentElement;
            peopleElement = xmlDocument.CreateElement("student");
            base.Serialize();
            XmlAttribute groupAttribute = xmlDocument.CreateAttribute("group");
            XmlAttribute courseAttribute = xmlDocument.CreateAttribute("course");

            XmlText groupText = xmlDocument.CreateTextNode(GroupNumber.ToString());
            XmlText courseText = xmlDocument.CreateTextNode(Course.ToString());

            XmlElement specialtiesElement = xmlDocument.CreateElement("specialties");
            foreach (var specialty in Specialties)
            {
                XmlElement specialtyElement = xmlDocument.CreateElement("specialty");
                XmlText specialtyText = xmlDocument.CreateTextNode(specialty.Id.ToString());
                XmlAttribute idAttribute = xmlDocument.CreateAttribute("id");
                idAttribute.AppendChild(specialtyText);
                specialtyElement.Attributes.Append(idAttribute);
                specialtiesElement.AppendChild(specialtyElement);
            }

            groupAttribute.AppendChild(groupText);
            courseAttribute.AppendChild(courseText);

            peopleElement.Attributes.Append(groupAttribute);
            peopleElement.Attributes.Append(courseAttribute);
            peopleElement.AppendChild(specialtiesElement);
            xmlRoot.AppendChild(peopleElement);
            xmlDocument.Save("C://Users//Наташа Лапушка//Desktop//QA Automation//Homework 7//HW7//HW7//DAL//Students.xml");
        }

        public new List<Student> Deserealize()
        {
            return new List<Student>();
        }

        public void Add(Specialty specialty)
        {
            Specialties.Add(specialty);
        }
    }
}
