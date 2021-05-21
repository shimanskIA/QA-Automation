using HW7.Entities.Education;
using HW7.Entities.People;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW7.Entities.Departments
{
    class Faculty : Department
    {
        public string Name { get; set; }
        public List<Specialty> Specialties { get; set; }

        public Faculty(string name, Person departmentHead, List<ScienceWorker> scienceWorkers, List<StaffWorker> staffWorkers, List<Specialty> specialties) : base(departmentHead, scienceWorkers, staffWorkers)
        {
            Name = name;
            Specialties = specialties;
        }

        public Faculty(string name, Person departmentHead) : base(departmentHead)
        {
            Name = name;
            Specialties = new List<Specialty>();
        }

        public void Add(Specialty specialty)
        {
            Specialties.Add(specialty);
        }
    }
}
