using HW7.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace HW7.Entities.People
{
    public class StaffWorker : Worker, ISerializable<StaffWorker>
    {
        public StaffVacancies Vacancy { get; set; }
        public StaffWorker(string name, string surname, int age, int experience, double loan, AdministrationDuties administrationDuty, StaffVacancies vacancy) : base(name, surname, age, experience, loan, administrationDuty)
        {
            Vacancy = vacancy;
        }

        public override void Serialize()
        {
            xmlDocument = new XmlDocument();
            xmlDocument.Load("C://Users//Наташа Лапушка//Desktop//QA Automation//Homework 7//HW7//HW7//DAL//StaffWorkers.xml");
            XmlElement xmlRoot = xmlDocument.DocumentElement;
            peopleElement = xmlDocument.CreateElement("staff_worker");
            base.Serialize();
            XmlAttribute vacancyAttribute = xmlDocument.CreateAttribute("vacancy");

            XmlText vacancyText = xmlDocument.CreateTextNode(Vacancy.ToString());

            vacancyAttribute.AppendChild(vacancyText);

            peopleElement.Attributes.Append(vacancyAttribute);
            xmlRoot.AppendChild(peopleElement);
            xmlDocument.Save("C://Users//Наташа Лапушка//Desktop//QA Automation//Homework 7//HW7//HW7//DAL//StaffWorkers.xml");
        }

        public new List<StaffWorker> Deserealize()
        {
            return new List<StaffWorker>();
        }
    }
}
