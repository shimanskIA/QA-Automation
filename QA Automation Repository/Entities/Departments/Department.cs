using HW7.Entities.People;
using HW7.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace HW7.Entities.Departments
{
    public abstract class Department : ISerializable<Department>
    {
        public int Id { get; set; }
        public Person DepartmentHead { get; set; }
        public List<ScienceWorker> ScienceWorkers { get; set; }
        public List<StaffWorker> StaffWorkers { get; set; }
        protected static int AmountOfObjects { get; set; } = 0;
        public XmlDocument xmlDocument { get; protected set; }
        public XmlElement departmentElement { get; protected set; }

        public Department(Person departmentHead, List<ScienceWorker> scienceWorkers, List<StaffWorker> staffWorkers)
        {
            DepartmentHead = departmentHead;
            ScienceWorkers = scienceWorkers;
            StaffWorkers = staffWorkers;
            Id = AmountOfObjects;
            AmountOfObjects++;
        }

        public Department(Person departmentHead)
        {
            DepartmentHead = departmentHead;
            ScienceWorkers = new List<ScienceWorker>();
            StaffWorkers = new List<StaffWorker>();
            Id = AmountOfObjects;
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
            foreach (var scienceWorker in ScienceWorkers)
            {
                XmlElement scienceWorkerElement = xmlDocument.CreateElement("science_worker");
                XmlText scienceWorkerText = xmlDocument.CreateTextNode(scienceWorker.Id.ToString());
                XmlAttribute workerIdAttribute = xmlDocument.CreateAttribute("id");
                workerIdAttribute.AppendChild(scienceWorkerText);
                scienceWorkerElement.Attributes.Append(workerIdAttribute);
                scienceWorkersElement.AppendChild(scienceWorkerElement);
            }

            XmlElement staffWorkersElement = xmlDocument.CreateElement("staff_workers");
            foreach (var staffWorker in StaffWorkers)
            {
                XmlElement staffWorkerElement = xmlDocument.CreateElement("staff_worker");
                XmlText staffWorkerText = xmlDocument.CreateTextNode(staffWorker.Id.ToString());
                XmlAttribute workerIdAttribute = xmlDocument.CreateAttribute("id");
                workerIdAttribute.AppendChild(staffWorkerText);
                staffWorkerElement.Attributes.Append(workerIdAttribute);
                staffWorkersElement.AppendChild(staffWorkerElement);
            }


            idAttribute.AppendChild(idText);
            headAttribute.AppendChild(headText);

            departmentElement.Attributes.Append(idAttribute);
            departmentElement.Attributes.Append(headAttribute);
            departmentElement.AppendChild(scienceWorkersElement);
            departmentElement.AppendChild(staffWorkersElement);
        }

        public virtual List<Department> Deserealize()
        {
            return new List<Department>();
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
