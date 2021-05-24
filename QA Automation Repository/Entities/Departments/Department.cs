using HW7.Entities.People;
using HW7.Helpers;
using HW7.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace HW7.Entities.Departments
{
    public abstract class Department : ISerializable
    {
        public int Id { get; set; }
        public Person DepartmentHead { get; set; }
        public List<ScienceWorker> ScienceWorkers { get; set; }
        public List<StaffWorker> StaffWorkers { get; set; }
        protected static int AmountOfObjects { get; set; } = 0;
        private static List<int> ForbiddenIDs { get; set; } = new List<int>();
        public XmlDocument xmlDocument { get; protected set; }
        public XmlElement departmentElement { get; protected set; }

        public Department(int id, Person departmentHead, List<ScienceWorker> scienceWorkers, List<StaffWorker> staffWorkers)
        {
            DepartmentHead = departmentHead;
            ScienceWorkers = scienceWorkers;
            StaffWorkers = staffWorkers;
            Id = id;
            if (!ForbiddenIDs.Contains(id))
            {
                ForbiddenIDs.Add(id);
            }
        }

        public Department(Person departmentHead)
        {
            DepartmentHead = departmentHead;
            ScienceWorkers = new List<ScienceWorker>();
            StaffWorkers = new List<StaffWorker>();
            while (ForbiddenIDs.Contains(AmountOfObjects))
            {
                AmountOfObjects++;
            }
            Id = AmountOfObjects;
            ForbiddenIDs.Add(Id);
            AmountOfObjects++;
        }

        public void AddScienceWorkers(ScienceWorker scienceWorker)
        {
            ScienceWorkers.Add(scienceWorker);
        }

        public void AddStaffWorkers(StaffWorker staffWorker)
        {
            StaffWorkers.Add(staffWorker);
        }

        public virtual void Serialize() 
        {
            XmlAttribute idAttribute = xmlDocument.CreateAttribute("id");
            XmlAttribute headAttribute = xmlDocument.CreateAttribute("department_head");

            XmlText idText = xmlDocument.CreateTextNode(Id.ToString());
            XmlText headText = xmlDocument.CreateTextNode(DepartmentHead.Id.ToString());
            XmlElement scienceWorkersElement = xmlDocument.CreateElement("science_workers");
            HelperMethods.FillXMLElement(xmlDocument, scienceWorkersElement, "science_worker", "Id", "id", ScienceWorkers);

            XmlElement staffWorkersElement = xmlDocument.CreateElement("staff_workers");
            HelperMethods.FillXMLElement(xmlDocument, staffWorkersElement, "staff_worker", "Id", "id", StaffWorkers);

            idAttribute.AppendChild(idText);
            headAttribute.AppendChild(headText);

            departmentElement.Attributes.Append(idAttribute);
            departmentElement.Attributes.Append(headAttribute);
            departmentElement.AppendChild(scienceWorkersElement);
            departmentElement.AppendChild(staffWorkersElement);
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public override bool Equals(object department)
        {
            if (department.GetType() == typeof(Department))
            {
                if (department.GetHashCode() == Id)
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
