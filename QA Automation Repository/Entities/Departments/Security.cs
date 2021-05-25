using HW7.Entities.People;
using HW7.Helpers;
using HW7.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace HW7.Entities.Departments
{
    public class Security : Department
    {
        public List<InventoryControl<SecurityEquipmentTypes>> Equipment { get; set; }
        public Security(int id, Person departmentHead, List<ScienceWorker> scienceWorkers, List<StaffWorker> staffWorkers, List<InventoryControl<SecurityEquipmentTypes>> equipment) : base(id, departmentHead, scienceWorkers, staffWorkers)
        {
            Equipment = equipment;
        }

        public Security(Person departmentHead, List<InventoryControl<SecurityEquipmentTypes>> equipment) : base(departmentHead)
        {
            Equipment = equipment;
        }

        public Security(Person departmentHead) : base(departmentHead)
        {
            Equipment = new List<InventoryControl<SecurityEquipmentTypes>>();
        }

        public void Add(InventoryControl<SecurityEquipmentTypes> iventoryElement)
        {
            Equipment.Add(iventoryElement);
        }

        public override void Serialize()
        {
            xmlDocument = new XmlDocument();
            xmlDocument.Load("C://Users//Наташа Лапушка//Desktop//QA Automation//Homework 7//HW7//HW7//DAL//Departments.xml");
            XmlElement xmlRoot = xmlDocument.DocumentElement;
            departmentElement = xmlDocument.CreateElement("security");
            base.Serialize();

            XmlElement equipmentsElement = xmlDocument.CreateElement("equipment_warehouse");
            HelperMethods.GroupFillXMLElement(xmlDocument, equipmentsElement, "equipment", Equipment);

            departmentElement.AppendChild(equipmentsElement);
            xmlRoot.AppendChild(departmentElement);
            xmlDocument.Save("C://Users//Наташа Лапушка//Desktop//QA Automation//Homework 7//HW7//HW7//DAL//Departments.xml");
        }
    }
}
