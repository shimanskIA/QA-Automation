﻿using HW7.Entities.People;
using HW7.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Linq;
using HW7.Helpers;

namespace HW7.Entities.Departments
{
    public class ResearchDepartment : Department
    {
        public List<string> Publications { get; set; }
        public ResearchDepartment(int id, Person departmentHead, List<ScienceWorker> scienceWorkers, List<StaffWorker> staffWorkers, List<string> publications) : base(id, departmentHead, scienceWorkers, staffWorkers)
        {
            Publications = publications;
        }

        public ResearchDepartment(Person departmentHead, List<string> publications) : base(departmentHead)
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
            HelperMethods.SimpleFillXMLElement(xmlDocument, publicationsElement, "publication", "theme", Publications);

            departmentElement.AppendChild(publicationsElement);
            xmlRoot.AppendChild(departmentElement);
            xmlDocument.Save("C://Users//Наташа Лапушка//Desktop//QA Automation//Homework 7//HW7//HW7//DAL//Departments.xml");
        }
    }
}
