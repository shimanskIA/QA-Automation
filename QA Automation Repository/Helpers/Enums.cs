using System;
using System.Collections.Generic;
using System.Text;

namespace HW7
{
    public enum ScienceDegrees
    {
        ResearchAssistant,
        JuniorResearcher,
        SeniorResearcher,
        Lecturer,
        SeniorLecturer,
        Docent,
        Professor,
        PhCandidate,
        PhDoctor
    }

    public enum AdministrationDuties
    { 
        NoDuties,
        DepartmentHead,
        DeputyDean,
        DeputyDeanForEducationalWork,
        Dean,
        ViceRector,
        ViceRectorForEducationalWork,
        Rector
    }
  
    public enum StaffVacancies
    {
        Watchman,
        SecurityGuard,
        HeadOfSecurity,
        CloakroomAttendant,
        Cleaner,
        Engineer,
        HeadEngineer,
        ClericalWorker,
        HeadOfClericalWorkers
    }

    public enum SecurityEquipmentTypes
    {
        Club,
        StunGun,
        Handcuffs,
        MetalDetector,
        PepperSpray,
        BulletproofVest
    }

    public enum MaintenanceEquipmentTypes
    {
        Mop,
        Rag,
        Detergent,
        Sponge,
        Hammer,
        Saw,
        Drill,
        Insulation
    }

    public enum FileNames
    { 
        Departments,
        ScienceWorkers,
        Specialties,
        StaffWorkers,
        Students,
        Subjects,
        Universities
    }

}
