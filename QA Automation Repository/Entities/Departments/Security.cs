using HW7.Entities.People;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW7.Entities.Departments
{
    class Security : Department
    {
        public List<InventoryControl<SecurityEquipmentTypes>> Equipment { get; set; }
        public Security(Person departmentHead, List<ScienceWorker> scienceWorkers, List<StaffWorker> staffWorkers, List<InventoryControl<SecurityEquipmentTypes>> equipment) : base(departmentHead, scienceWorkers, staffWorkers)
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
    }
}
