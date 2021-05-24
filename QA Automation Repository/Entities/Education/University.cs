using HW7.Entities.Departments;
using HW7.Entities.People;
using HW7.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using HW7.Helpers;
using HW7.Entities.Builders;

namespace HW7.Entities.Education
{
    public class University : ISerializable, IDeserealizable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Department> Departments { get; set; }
        public List<Student> Students { get; set; }
        public List<ScienceWorker> ScienceWorkers { get; set; } 
        public List<StaffWorker> StaffWorkers { get; set; }
        public List<Specialty> Specialties { get; set; }
        public List<AcademicSubject> Subjects { get; set; }
        private static int AutoIncrement { get; set; } = 0;
        private static List<int> ForbiddenIDs { get; set; } = new List<int>();

        public University(int id, string name, List<Department> departments, List<Student> students, List<ScienceWorker> scienceWorkers, List<StaffWorker> staffWorkers, List<Specialty> specialties, List<AcademicSubject> subjects)
        {
            Name = name;
            Departments = departments;
            Students = students;
            ScienceWorkers = scienceWorkers;
            StaffWorkers = staffWorkers;
            Specialties = specialties;
            Subjects = subjects;
            Id = id;
            if (!ForbiddenIDs.Contains(id))
            {
                ForbiddenIDs.Add(id);
            }
        }

        public University(string name)
        {
            Name = name;
            while (ForbiddenIDs.Contains(AutoIncrement))
            {
                AutoIncrement++;
            }
            Id = AutoIncrement;
            ForbiddenIDs.Add(Id);
            AutoIncrement++;
            Departments = new List<Department>();
            Students = new List<Student>();
            ScienceWorkers = new List<ScienceWorker>();
            StaffWorkers = new List<StaffWorker>();
            Specialties = new List<Specialty>();
            Subjects = new List<AcademicSubject>();
        }

        public University()
        {
            Departments = new List<Department>();
            Students = new List<Student>();
            ScienceWorkers = new List<ScienceWorker>();
            StaffWorkers = new List<StaffWorker>();
            Specialties = new List<Specialty>();
            Subjects = new List<AcademicSubject>();
        }

        public void Serialize()
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load("C://Users//Наташа Лапушка//Desktop//QA Automation//Homework 7//HW7//HW7//DAL//Universities.xml");
            XmlElement xmlRoot = xmlDocument.DocumentElement;
            xmlRoot.RemoveAll();
            XmlElement universityElement = xmlDocument.CreateElement("university");

            XmlAttribute idAttribute = xmlDocument.CreateAttribute("id");
            XmlAttribute nameAttribute = xmlDocument.CreateAttribute("name");

            XmlText idText = xmlDocument.CreateTextNode(Id.ToString());
            XmlText nameText = xmlDocument.CreateTextNode(Name);

            XmlElement departmentsElement = xmlDocument.CreateElement("departments");
            HelperMethods.FillXMLElement(xmlDocument,departmentsElement, "department", "Id", "id", Departments);
            
            XmlElement studentsElement = xmlDocument.CreateElement("students");
            HelperMethods.FillXMLElement(xmlDocument, studentsElement, "student", "Id", "id", Students);

            XmlElement scienceWorkersElement = xmlDocument.CreateElement("science_workers");
            HelperMethods.FillXMLElement(xmlDocument, scienceWorkersElement, "science_worker", "Id", "id", ScienceWorkers);

            XmlElement staffWorkersElement = xmlDocument.CreateElement("staff_workers");
            HelperMethods.FillXMLElement(xmlDocument, staffWorkersElement, "staff_worker", "Id", "id", StaffWorkers);

            XmlElement specialtiesElement = xmlDocument.CreateElement("specialties");
            HelperMethods.FillXMLElement(xmlDocument, specialtiesElement, "specialty", "Id", "id", Specialties);

            XmlElement subjectsElement = xmlDocument.CreateElement("subjects");
            HelperMethods.FillXMLElement(xmlDocument, subjectsElement, "subject", "Id", "id", Subjects);

            idAttribute.AppendChild(idText);
            nameAttribute.AppendChild(nameText);

            universityElement.Attributes.Append(idAttribute);
            universityElement.Attributes.Append(nameAttribute);
            universityElement.AppendChild(departmentsElement);
            universityElement.AppendChild(studentsElement);
            universityElement.AppendChild(scienceWorkersElement);
            universityElement.AppendChild(staffWorkersElement);
            universityElement.AppendChild(specialtiesElement);
            universityElement.AppendChild(subjectsElement);
            xmlRoot.AppendChild(universityElement);
            xmlDocument.Save("C://Users//Наташа Лапушка//Desktop//QA Automation//Homework 7//HW7//HW7//DAL//Universities.xml");

            HelperMethods.ClearXMLFile(FileNames.Departments.ToString()+".xml");
            HelperMethods.ClearXMLFile(FileNames.ScienceWorkers.ToString() + ".xml");
            HelperMethods.ClearXMLFile(FileNames.StaffWorkers.ToString() + ".xml");
            HelperMethods.ClearXMLFile(FileNames.Students.ToString() + ".xml");
            HelperMethods.ClearXMLFile(FileNames.Subjects.ToString() + ".xml");
            HelperMethods.ClearXMLFile(FileNames.Specialties.ToString() + ".xml");

            HelperMethods.SaveToFile(Departments);
            HelperMethods.SaveToFile(ScienceWorkers);
            HelperMethods.SaveToFile(StaffWorkers);
            HelperMethods.SaveToFile(Students);
            HelperMethods.SaveToFile(Specialties);
            HelperMethods.SaveToFile(Subjects);

        }

        public void Deserealize()
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load("C://Users//Наташа Лапушка//Desktop//QA Automation//Homework 7//HW7//HW7//DAL//Subjects.xml");
            SubjectBuilder subjectBuilder = new SubjectBuilder();
            List<AcademicSubject> subjects = subjectBuilder.Build(xmlDocument);
            xmlDocument.Load("C://Users//Наташа Лапушка//Desktop//QA Automation//Homework 7//HW7//HW7//DAL//Specialties.xml");
            SpecialtyBuilder specialtyBuilder = new SpecialtyBuilder(subjects);
            List<Specialty> specialties = specialtyBuilder.Build(xmlDocument);
            xmlDocument.Load("C://Users//Наташа Лапушка//Desktop//QA Automation//Homework 7//HW7//HW7//DAL//Students.xml");
            StudentBuilder studentBuilder = new StudentBuilder(specialties);
            List<Student> students = studentBuilder.Build(xmlDocument);
            xmlDocument.Load("C://Users//Наташа Лапушка//Desktop//QA Automation//Homework 7//HW7//HW7//DAL//ScienceWorkers.xml");
            ScienceWorkersBuilder scienceWorkersBuilder = new ScienceWorkersBuilder(subjects);
            List<ScienceWorker> scienceWorkers = scienceWorkersBuilder.Build(xmlDocument);
            xmlDocument.Load("C://Users//Наташа Лапушка//Desktop//QA Automation//Homework 7//HW7//HW7//DAL//StaffWorkers.xml");
            StaffWorkersBuilder staffWorkersBuilder = new StaffWorkersBuilder();
            List<StaffWorker> staffWorkers = staffWorkersBuilder.Build(xmlDocument);
            xmlDocument.Load("C://Users//Наташа Лапушка//Desktop//QA Automation//Homework 7//HW7//HW7//DAL//Departments.xml");
            DepartmentBuilder departmentsBuilder = new DepartmentBuilder(scienceWorkers, staffWorkers, specialties);
            List<Department> departments = departmentsBuilder.Build(xmlDocument);

            xmlDocument.Load("C://Users//Наташа Лапушка//Desktop//QA Automation//Homework 7//HW7//HW7//DAL//Universities.xml");
            XmlElement xmlRoot = xmlDocument.DocumentElement;
            XmlNode xmlNode = xmlRoot.FirstChild;
            if (xmlNode.Attributes.Count > 0)
            {
                XmlNode attribute = xmlNode.Attributes.GetNamedItem("id");
                if (attribute != null)
                {
                    Id = Convert.ToInt32(attribute.Value);
                }
                attribute = xmlNode.Attributes.GetNamedItem("name");
                if (attribute != null)
                {
                    Name = attribute.Value;
                }     
            }
            Departments = departments;
            Students = students;
            ScienceWorkers = scienceWorkers;
            StaffWorkers = staffWorkers;
            Specialties = specialties;
            Subjects = subjects;
        }

        public new int GetHashCode()
        {
            return Id;
        }

        public new bool Equals(object university)
        {
            if (university.GetType() == typeof(University))
            {
                if (university.GetHashCode() == Id)
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

        public void AddDepartment(Department department)
        {
            Departments.Add(department);
        }

        public void AddStudent(Student student)
        {
            Students.Add(student);
        }

        public void AddScienceWorker(ScienceWorker scienceWorker)
        {
            ScienceWorkers.Add(scienceWorker);
        }

        public void AddStaffWorker(StaffWorker staffWorker)
        {
            StaffWorkers.Add(staffWorker);
        }
    }
}
