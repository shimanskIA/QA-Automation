using HW7.Entities.Departments;
using HW7.Entities.People;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW7.Entities.Education
{
    class University
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Department> Departments { get; set; }
        public List<Student> Students { get; set; }
        public List<ScienceWorker> ScienceWorkers { get; set; } 
        public List<StaffWorker> StaffWorkers { get; set; }
        private static int AmountOfObjects { get; set; } = 0;

        public University(string name, List<Department> departments, List<Student> students, List<ScienceWorker> scienceWorkers, List<StaffWorker> staffWorkers)
        {
            Name = name;
            Departments = departments;
            Students = students;
            ScienceWorkers = scienceWorkers;
            StaffWorkers = staffWorkers;
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
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public override bool Equals(object university)
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
