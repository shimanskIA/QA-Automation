using HW7.Entities.People;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW7.Entities.Departments
{
    class MaintenanceDepartment : Department
    {
        public List<InventoryControl<MaintenanceEquipmentTypes>> Equipment;
        public MaintenanceDepartment(Person departmentHead, List<ScienceWorker> scienceWorkers, List<StaffWorker> staffWorkers, List<InventoryControl<MaintenanceEquipmentTypes>> equipment) : base(departmentHead, scienceWorkers, staffWorkers)
        {
            Equipment = equipment;
        }

        public MaintenanceDepartment(Person departmentHead, List<InventoryControl<MaintenanceEquipmentTypes>> equipment) : base(departmentHead)
        {
            Equipment = equipment;
        }

        public MaintenanceDepartment(Person departmentHead) : base(departmentHead)
        {
            Equipment = new List<InventoryControl<MaintenanceEquipmentTypes>>();
        }

        public void Add(InventoryControl<MaintenanceEquipmentTypes> iventoryElement)
        {
            Equipment.Add(iventoryElement);
        }
    }
}
