using HW7.Entities.People;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW7.Entities.Departments
{
    class ResearchDepartment : Department
    {
        public List<string> Publications { get; set; }
        public ResearchDepartment(Person departmentHead, List<ScienceWorker> scienceWorkers, List<StaffWorker> staffWorkers, List<string> publications) : base(departmentHead, scienceWorkers, staffWorkers)
        {
            Publications = publications;
        }

        public ResearchDepartment(Person departmentHead, List<string> publications) : base(departmentHead)
        {
            Publications = publications;
        }
    }
}
