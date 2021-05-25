using HW7.Entities.People;
using HW7.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace HW7.Entities.Departments
{
    public class Administration : Department
    {
        public double Budget { get; set; }
        public Administration(int id, Person departmentHead, List<ScienceWorker> scienceWorkers, List<StaffWorker> staffWorkers, double budget) : base(id, departmentHead, scienceWorkers, staffWorkers)
        {
            Budget = budget;
        }

        public Administration(Person departmentHead, double budget) : base(departmentHead)
        {
            Budget = budget;
        }

        public override void Serialize() 
        {
            xmlDocument = new XmlDocument();
            xmlDocument.Load("C://Users//Наташа Лапушка//Desktop//QA Automation//Homework 7//HW7//HW7//DAL//Departments.xml");
            XmlElement xmlRoot = xmlDocument.DocumentElement;
            departmentElement = xmlDocument.CreateElement("administration");
            base.Serialize();
            XmlAttribute budgetAttribute = xmlDocument.CreateAttribute("budget");

            XmlText budgetText = xmlDocument.CreateTextNode(Budget.ToString());

            budgetAttribute.AppendChild(budgetText);

            departmentElement.Attributes.Append(budgetAttribute);
            xmlRoot.AppendChild(departmentElement);
            xmlDocument.Save("C://Users//Наташа Лапушка//Desktop//QA Automation//Homework 7//HW7//HW7//DAL//Departments.xml");
        }
    }
}
