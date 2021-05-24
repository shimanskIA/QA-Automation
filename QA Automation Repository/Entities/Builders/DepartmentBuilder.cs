using HW7.Entities.Departments;
using HW7.Entities.Education;
using HW7.Entities.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace HW7.Entities.Builders
{
    class DepartmentBuilder : Builder<Department>
    {
        public List<ScienceWorker> ScienceWorkers { get; set; }
        public List<StaffWorker> StaffWorkers { get; set; }
        public List<Specialty> Specialties { get; set; }

        public DepartmentBuilder(List<ScienceWorker> scienceWorkers, List<StaffWorker> staffWorkers, List<Specialty> specialties)
        {
            ScienceWorkers = scienceWorkers;
            StaffWorkers = staffWorkers;
            Specialties = specialties;
        }

        public override List<Department> Build(XmlDocument xmlDocument)
        {
            List<Department> departments = new List<Department>();
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            XmlElement xmlRoot = xmlDocument.DocumentElement;
            foreach (XmlNode xmlNode in xmlRoot)
            {
                if (xmlNode.Attributes.Count > 0)
                {
                    XmlNode attribute = xmlNode.Attributes.GetNamedItem("id");
                    if (attribute != null)
                    {
                        parameters.Add("id", attribute.Value);
                    }
                    attribute = xmlNode.Attributes.GetNamedItem("department_head");
                    Person departmentHead = null;
                    if (attribute != null)
                    {
                        departmentHead = ScienceWorkers.Find(x => x.Id == Convert.ToInt32(attribute.Value));
                        if (departmentHead != null)
                        {
                            departmentHead = StaffWorkers.Find(x => x.Id == Convert.ToInt32(attribute.Value));
                        }
                    }
                    List<StaffWorker> staffWorkers = new List<StaffWorker>();
                    List<ScienceWorker> scienceWorkers = new List<ScienceWorker>();
                    foreach (XmlNode childNode in xmlNode.ChildNodes)
                    {
                        if (childNode.Name == "staff_workers")
                        {
                            foreach (XmlNode childOfChild in childNode.ChildNodes)
                            {
                                staffWorkers.AddRange(StaffWorkers.Where(x => x.Id == Convert.ToInt32(childOfChild.Attributes.GetNamedItem("id").Value)));
                            }
                        }
                        if (childNode.Name == "science_workers")
                        {
                            foreach (XmlNode childOfChild in childNode.ChildNodes)
                            {
                                scienceWorkers.AddRange(ScienceWorkers.Where(x => x.Id == Convert.ToInt32(childOfChild.Attributes.GetNamedItem("id").Value)));
                            }
                        }
                    }

                    if (xmlNode.Name == "faculty")
                    {
                        List<Specialty> specialties = new List<Specialty>();
                        attribute = xmlNode.Attributes.GetNamedItem("name");
                        foreach (XmlNode childNode in xmlNode.ChildNodes)
                        {
                            if (childNode.Name == "specialties")
                            {
                                foreach (XmlNode childOfChild in childNode.ChildNodes)
                                {
                                    specialties.AddRange(Specialties.Where(x => x.Id == Convert.ToInt32(childOfChild.Attributes.GetNamedItem("id").Value)));
                                }
                                departments.Add(new Faculty(Convert.ToInt32(parameters["id"]), attribute.Value, departmentHead, scienceWorkers, staffWorkers, specialties));
                            }
                        }
                    }

                    if (xmlNode.Name == "administration")
                    {
                        attribute = xmlNode.Attributes.GetNamedItem("budget");
                        departments.Add(new Administration(Convert.ToInt32(parameters["id"]), departmentHead, scienceWorkers, staffWorkers, Convert.ToInt32(attribute.Value)));
                    }

                    if (xmlNode.Name == "research_department")
                    {
                        List<string> publications = new List<string>();
                        foreach (XmlNode childNode in xmlNode.ChildNodes)
                        {
                            if (childNode.Name == "publications")
                            {
                                foreach (XmlNode childOfChild in childNode.ChildNodes)
                                {
                                    publications.Add(childOfChild.Attributes.GetNamedItem("theme").Value);
                                }
                                departments.Add(new ResearchDepartment(Convert.ToInt32(parameters["id"]), departmentHead, scienceWorkers, staffWorkers, publications));
                            }
                        }
                    }

                    if (xmlNode.Name == "security")
                    {
                        List<InventoryControl<SecurityEquipmentTypes>> equipment = new List<InventoryControl<SecurityEquipmentTypes>>();
                        foreach (XmlNode childNode in xmlNode.ChildNodes)
                        {
                            if (childNode.Name == "equipment_warehouse")
                            {
                                foreach (XmlNode childOfChild in childNode.ChildNodes)
                                {
                                    
                                    equipment.Add(new InventoryControl<SecurityEquipmentTypes>(Convert.ToInt32(childOfChild.Attributes.GetNamedItem("amount").Value), (SecurityEquipmentTypes)Enum.Parse(typeof(SecurityEquipmentTypes), childOfChild.Attributes.GetNamedItem("item").Value)));
                                }
                                departments.Add(new Security(Convert.ToInt32(parameters["id"]), departmentHead, scienceWorkers, staffWorkers, equipment));
                            }
                        }
                    }

                    if (xmlNode.Name == "maintenance")
                    {
                        List<InventoryControl<MaintenanceEquipmentTypes>> equipment = new List<InventoryControl<MaintenanceEquipmentTypes>>();
                        foreach (XmlNode childNode in xmlNode.ChildNodes)
                        {
                            if (childNode.Name == "equipment_warehouse")
                            {
                                foreach (XmlNode childOfChild in childNode.ChildNodes)
                                {

                                    equipment.Add(new InventoryControl<MaintenanceEquipmentTypes>(Convert.ToInt32(childOfChild.Attributes.GetNamedItem("amount").Value), (MaintenanceEquipmentTypes)Enum.Parse(typeof(MaintenanceEquipmentTypes), childOfChild.Attributes.GetNamedItem("item").Value)));
                                }
                                departments.Add(new MaintenanceDepartment(Convert.ToInt32(parameters["id"]), departmentHead, scienceWorkers, staffWorkers, equipment));
                            }
                        }
                    }
                }
                parameters.Clear();
            }
            return departments;
        }
    }
}
