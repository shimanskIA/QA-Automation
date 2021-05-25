using HW7.Entities.People;
using HW7.Helpers;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

namespace HW7.Entities.Departments
{
    public class MaintenanceDepartment : Department
    {
        public List<InventoryControl<MaintenanceEquipmentTypes>> Equipment;
        public MaintenanceDepartment(int id, Person departmentHead, List<ScienceWorker> scienceWorkers, List<StaffWorker> staffWorkers, List<InventoryControl<MaintenanceEquipmentTypes>> equipment) : base(id, departmentHead, scienceWorkers, staffWorkers)
        {
            Equipment = equipment;
        }

        public MaintenanceDepartment(Person departmentHead, List<InventoryControl<MaintenanceEquipmentTypes>> equipment) : base(departmentHead)
        {
            Equipment = equipment;
        }

        public MaintenanceDepartment(Person departmentHead) : base(departmentHead)
        {
            Equipment = new List<InventoryControl<MaintenanceEquipmentTypes>>();
        }

        public void Add(InventoryControl<MaintenanceEquipmentTypes> iventoryElement)
        {
            Equipment.Add(iventoryElement);
        }

        public override void Serialize()
        {
            xmlDocument = new XmlDocument();
            xmlDocument.Load("C://Users//Наташа Лапушка//Desktop//QA Automation//Homework 7//HW7//HW7//DAL//Departments.xml");
            XmlElement xmlRoot = xmlDocument.DocumentElement;
            departmentElement = xmlDocument.CreateElement("maintenance");
            base.Serialize();

            XmlElement equipmentsElement = xmlDocument.CreateElement("equipment_warehouse");
            HelperMethods.GroupFillXMLElement(xmlDocument, equipmentsElement, "equipment", Equipment);
        
            departmentElement.AppendChild(equipmentsElement);
            xmlRoot.AppendChild(departmentElement);
            xmlDocument.Save("C://Users//Наташа Лапушка//Desktop//QA Automation//Homework 7//HW7//HW7//DAL//Departments.xml");
        }
    }
}
