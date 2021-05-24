using HW7.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace HW7.Entities.People
{
    public abstract class Worker : Person, ISerializable
    {
        public int Experience { get; set; }
        public double Loan { get; set; }
        public AdministrationDuties AdministrationDuty { get; set; }
        public Worker(int id, string name, string surname, int age, int experience, double loan, AdministrationDuties administrationDuty) : base(id, name, surname, age)
        {
            Experience = experience;
            Loan = loan;
            AdministrationDuty = administrationDuty;
        }

        public Worker(string name, string surname, int age, int experience, double loan, AdministrationDuties administrationDuty) : base(name, surname, age)
        {
            Experience = experience;
            Loan = loan;
            AdministrationDuty = administrationDuty;
        }

        public override void Serialize()
        {
            base.Serialize();
            XmlAttribute experienceAttribute = xmlDocument.CreateAttribute("experience");
            XmlAttribute loanAttribute = xmlDocument.CreateAttribute("loan");
            XmlAttribute dutiesAttribute = xmlDocument.CreateAttribute("administrational_duties");

            XmlText experienceText = xmlDocument.CreateTextNode(Experience.ToString());
            XmlText loanText = xmlDocument.CreateTextNode(Loan.ToString());
            XmlText dutiesText = xmlDocument.CreateTextNode(AdministrationDuty.ToString());

            experienceAttribute.AppendChild(experienceText);
            loanAttribute.AppendChild(loanText);
            dutiesAttribute.AppendChild(dutiesText);

            peopleElement.Attributes.Append(experienceAttribute);
            peopleElement.Attributes.Append(loanAttribute);
            peopleElement.Attributes.Append(dutiesAttribute);
        }
    }
}
