using HW7.Entities.People;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW7.Entities.Departments
{
    class Administration : Department
    {
        public double Budget { get; set; }
        public Administration(Person departmentHead, List<ScienceWorker> scienceWorkers, List<StaffWorker> staffWorkers, double budget) : base(departmentHead, scienceWorkers, staffWorkers)
        {
            Budget = budget;
        }

        public Administration(Person departmentHead, double budget) : base(departmentHead)
        {
            Budget = budget;
        }
    }
}
