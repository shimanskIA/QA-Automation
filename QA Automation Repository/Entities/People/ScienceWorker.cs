using HW7.Entities;
using HW7.Entities.Education;
using HW7.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace HW7.Entities.People
{
    public class ScienceWorker : Worker, ISerializable<ScienceWorker>
    {
        public ScienceDegrees ScienceDegree { get; set; }
        public int DiplomaProtectionYear { get; set; }
        public string DiplomaTheme { get; set; }
        public List<AcademicSubject> LecturedSubjects { get; set; }
        public ScienceWorker(string name, string surname, int age, int experience, double loan, AdministrationDuties administrationDuty, ScienceDegrees scienceDegree, int diplomaProtectionYear, string diplomaTheme, List<AcademicSubject> lecturedSubjects) : base(name, surname, age, experience, loan, administrationDuty)
        {
            ScienceDegree = scienceDegree;
            DiplomaProtectionYear = diplomaProtectionYear;
            DiplomaTheme = diplomaTheme;
            LecturedSubjects = lecturedSubjects;
        }

        public ScienceWorker(string name, string surname, int age, int experience, double loan, AdministrationDuties administrationDuty, ScienceDegrees scienceDegree, int diplomaProtectionYear, string diplomaTheme) : base(name, surname, age, experience, loan, administrationDuty)
        {
            ScienceDegree = scienceDegree;
            DiplomaProtectionYear = diplomaProtectionYear;
            DiplomaTheme = diplomaTheme;
            LecturedSubjects = new List<AcademicSubject>();
        }
        
        public void Add(AcademicSubject subject)
        {
            LecturedSubjects.Add(subject);
        }

        public override void Serialize()
        {
            xmlDocument = new XmlDocument();
            xmlDocument.Load("C://Users//Наташа Лапушка//Desktop//QA Automation//Homework 7//HW7//HW7//DAL//ScienceWorkers.xml");
            XmlElement xmlRoot = xmlDocument.DocumentElement;
            peopleElement = xmlDocument.CreateElement("science_worker");
            base.Serialize();
            XmlAttribute degreeAttribute = xmlDocument.CreateAttribute("science_degree");
            XmlAttribute diplomaProtectionAttribute = xmlDocument.CreateAttribute("diploma_protection_year");
            XmlAttribute diplomaThemeAttribute = xmlDocument.CreateAttribute("diploma_theme");

            XmlText degreeText = xmlDocument.CreateTextNode(ScienceDegree.ToString());
            XmlText diplomaProtectionText = xmlDocument.CreateTextNode(DiplomaProtectionYear.ToString());
            XmlText diplomaThemeText = xmlDocument.CreateTextNode(DiplomaTheme);

            XmlElement subjectsElement = xmlDocument.CreateElement("subjects");
            foreach (var subject in LecturedSubjects)
            {
                XmlElement subjectElement = xmlDocument.CreateElement("subject");
                XmlText subjectText = xmlDocument.CreateTextNode(subject.Id.ToString());
                XmlAttribute subjectIdAttribute = xmlDocument.CreateAttribute("id");
                subjectIdAttribute.AppendChild(subjectText);
                subjectElement.Attributes.Append(subjectIdAttribute);
                subjectsElement.AppendChild(subjectElement);
            }

            degreeAttribute.AppendChild(degreeText);
            diplomaProtectionAttribute.AppendChild(diplomaProtectionText);
            diplomaThemeAttribute.AppendChild(diplomaThemeText);

            peopleElement.Attributes.Append(degreeAttribute);
            peopleElement.Attributes.Append(diplomaProtectionAttribute);
            peopleElement.Attributes.Append(diplomaThemeAttribute);
            peopleElement.AppendChild(subjectsElement);
            xmlRoot.AppendChild(peopleElement);
            xmlDocument.Save("C://Users//Наташа Лапушка//Desktop//QA Automation//Homework 7//HW7//HW7//DAL//ScienceWorkers.xml");
        }

        public new List<ScienceWorker> Deserealize()
        {
            return new List<ScienceWorker>();
        }
    }
}
