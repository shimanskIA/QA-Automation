using HW7.Entities.Departments;
using HW7.Entities.People;
using HW7.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using HW7.Helpers;

namespace HW7.Entities.Education
{
    public class University : ISerializable<University>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Department> Departments { get; set; }
        public List<Student> Students { get; set; }
        public List<ScienceWorker> ScienceWorkers { get; set; } 
        public List<StaffWorker> StaffWorkers { get; set; }
        public List<Specialty> Specialties { get; set; }
        public List<AcademicSubject> Subjects { get; set; }
        private static int AmountOfObjects { get; set; } = 0;

        public University(string name, List<Department> departments, List<Student> students, List<ScienceWorker> scienceWorkers, List<StaffWorker> staffWorkers, List<Specialty> specialties, List<AcademicSubject> subjects)
        {
            Name = name;
            Departments = departments;
            Students = students;
            ScienceWorkers = scienceWorkers;
            StaffWorkers = staffWorkers;
            Specialties = specialties;
            Subjects = subjects;
            Id = AmountOfObjects;
            AmountOfObjects++;
        }

        public University(string name)
        {
            Name = name;
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
            foreach (var department in Departments)
            {
                XmlElement departmentElement = xmlDocument.CreateElement("department");
                XmlText departmentText = xmlDocument.CreateTextNode(department.Id.ToString());
                XmlAttribute departmentIdAttribute = xmlDocument.CreateAttribute("id");
                departmentIdAttribute.AppendChild(departmentText);
                departmentElement.Attributes.Append(departmentIdAttribute);
                departmentsElement.AppendChild(departmentElement);
            }

            XmlElement studentsElement = xmlDocument.CreateElement("students");
            foreach (var student in Students)
            {
                XmlElement studentElement = xmlDocument.CreateElement("student");
                XmlText studentText = xmlDocument.CreateTextNode(student.Id.ToString());
                XmlAttribute studentIdAttribute = xmlDocument.CreateAttribute("id");
                studentIdAttribute.AppendChild(studentText);
                studentElement.Attributes.Append(studentIdAttribute);
                studentsElement.AppendChild(studentElement);
            }

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

            XmlElement specialtiesElement = xmlDocument.CreateElement("specialties");
            foreach (var specialty in Specialties)
            {
                XmlElement specialtyElement = xmlDocument.CreateElement("specialty");
                XmlText specialtyText = xmlDocument.CreateTextNode(specialty.Id.ToString());
                XmlAttribute specialtyIdAttribute = xmlDocument.CreateAttribute("id");
                specialtyIdAttribute.AppendChild(specialtyText);
                specialtyElement.Attributes.Append(specialtyIdAttribute);
                specialtiesElement.AppendChild(specialtyElement);
            }

            XmlElement subjectsElement = xmlDocument.CreateElement("subjects");
            foreach (var subject in Subjects)
            {
                XmlElement subjectElement = xmlDocument.CreateElement("subject");
                XmlText subjectText = xmlDocument.CreateTextNode(subject.Id.ToString());
                XmlAttribute subjectIdAttribute = xmlDocument.CreateAttribute("id");
                subjectIdAttribute.AppendChild(subjectText);
                subjectElement.Attributes.Append(subjectIdAttribute);
                subjectsElement.AppendChild(subjectElement);
            }

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

        public List<University> Deserealize()
        {
            return new List<University>();
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
