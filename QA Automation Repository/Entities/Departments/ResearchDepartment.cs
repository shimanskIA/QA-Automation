using HW7.Entities.People;
using HW7.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Linq;

namespace HW7.Entities.Departments
{
    public class ResearchDepartment : Department
    {
        public List<string> Publications { get; set; }
        public ResearchDepartment(Person departmentHead, List<ScienceWorker> scienceWorkers, List<StaffWorker> staffWorkers, List<string> publications) : base(departmentHead, scienceWorkers, staffWorkers)
        {
            Publications = publications;
        }

        public override void Serialize()
        {
            xmlDocument = new XmlDocument();
            xmlDocument.Load("C://Users//Наташа Лапушка//Desktop//QA Automation//Homework 7//HW7//HW7//DAL//Departments.xml");
            XmlElement xmlRoot = xmlDocument.DocumentElement;
            departmentElement = xmlDocument.CreateElement("research_department");
            base.Serialize();

            XmlElement publicationsElement = xmlDocument.CreateElement("publications");
            foreach (var publication in Publications)
            {
                XmlElement publicationElement = xmlDocument.CreateElement("publication");
                XmlText publicationText = xmlDocument.CreateTextNode(publication);
                XmlAttribute publicationAttribute = xmlDocument.CreateAttribute("theme");
                publicationAttribute.AppendChild(publicationText);
                publicationElement.Attributes.Append(publicationAttribute);
                publicationsElement.AppendChild(publicationElement);
            }

            departmentElement.AppendChild(publicationsElement);
            xmlRoot.AppendChild(departmentElement);
            xmlDocument.Save("C://Users//Наташа Лапушка//Desktop//QA Automation//Homework 7//HW7//HW7//DAL//Departments.xml");
        }

        public new List<Department> Deserealize()
        {
            return base.Deserealize();
        }

        public ResearchDepartment(Person departmentHead, List<string> publications) : base(departmentHead)
        {
            Publications = publications;
        }
    }
}
