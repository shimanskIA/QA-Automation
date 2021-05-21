using HW7.Entities.People;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW7.Entities.Departments
{
    abstract class Department
    {
        public int Id { get; set; }
        public Person DepartmentHead { get; set; }
        public List<ScienceWorker> ScienceWorkers { get; set; }
        public List<StaffWorker> StaffWorkers { get; set; }
        protected static int AmountOfObjects { get; set; } = 0;

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

        public void AddScienceWorkers(ScienceWorker scienceWorker)
        {
            ScienceWorkers.Add(scienceWorker);
        }

        public void AddStaffWorkers(StaffWorker staffWorker)
        {
            StaffWorkers.Add(staffWorker);
        }
    }
}
