﻿using HW7.Entities.Departments;
using HW7.Entities.Education;
using HW7.Entities.People;
using System;
using System.Collections.Generic;
using System.Linq;
using HW7.Helpers;

namespace HW7
{
    class Program
    {
        static void Main(string[] args)
        {
            University OxfordUniversity = new University("Oxford");
            Student Student1 = new Student("Name1", "One", 20, 6, 3);
            Student Student2 = new Student("Name2", "Two", 21, 5, 4);
            Student Student3 = new Student("Name3", "Three", 19, 4, 4);
            Student Student4 = new Student("Name4", "Four", 20, 3, 3);
            Student Student5 = new Student("Name5", "Five", 21, 5, 4);
            Student Student6 = new Student("Name6", "Six", 18, 3, 1);
            Student Student7 = new Student("Name7", "Seven", 21, 1, 4);
            Student Student8 = new Student("Name8", "Eight", 21, 8, 4);
            Student Student9 = new Student("Name9", "Nine", 18, 9, 1);
            Student Student10 = new Student("Name10", "Ten", 17, 3, 1);
            Student Student11 = new Student("Name11", "Eleven", 22, 1, 5);
            ScienceWorker SciWorker1 = new ScienceWorker("Name1", "One", 50, 25, 5000, AdministrationDuties.Dean, ScienceDegrees.Professor, 1992, "Theme1");
            ScienceWorker SciWorker2 = new ScienceWorker("Name2", "Two", 65, 40, 4000, AdministrationDuties.DeputyDean, ScienceDegrees.Docent, 1986, "Theme2");
            ScienceWorker SciWorker3 = new ScienceWorker("Name3", "Three", 42, 19, 2100, AdministrationDuties.NoDuties, ScienceDegrees.Lecturer, 2005, "Theme3");
            ScienceWorker SciWorker4 = new ScienceWorker("Name4", "Four", 59, 36, 7100, AdministrationDuties.Dean, ScienceDegrees.PhCandidate, 1991, "Theme4");
            ScienceWorker SciWorker5 = new ScienceWorker("Name5", "Five", 78, 54, 11500, AdministrationDuties.Rector, ScienceDegrees.PhDoctor, 1971, "Theme5");
            ScienceWorker SciWorker6 = new ScienceWorker("Name6", "Six", 66, 48, 5100, AdministrationDuties.ViceRectorForEducationalWork, ScienceDegrees.Professor, 1979, "Theme6");
            ScienceWorker SciWorker7 = new ScienceWorker("Name7", "Seven", 29, 4, 2200, AdministrationDuties.NoDuties, ScienceDegrees.SeniorLecturer, 2015, "Theme7");
            ScienceWorker SciWorker8 = new ScienceWorker("Name8", "Eight", 34, 9, 3300, AdministrationDuties.NoDuties, ScienceDegrees.Docent, 2010, "Theme8");
            StaffWorker StaffWorker1 = new StaffWorker("Name1", "One", 35, 10, 4100, AdministrationDuties.DepartmentHead, StaffVacancies.HeadEngineer);
            StaffWorker StaffWorker2 = new StaffWorker("Name2", "Two", 58, 22, 3200, AdministrationDuties.NoDuties, StaffVacancies.Engineer);
            StaffWorker StaffWorker3 = new StaffWorker("Name3", "Three", 47, 14, 2500, AdministrationDuties.DepartmentHead, StaffVacancies.HeadOfSecurity);
            StaffWorker StaffWorker4 = new StaffWorker("Name4", "Four", 42, 10, 1600, AdministrationDuties.NoDuties, StaffVacancies.SecurityGuard);
            StaffWorker StaffWorker5 = new StaffWorker("Name5", "Five", 61, 43, 900, AdministrationDuties.NoDuties, StaffVacancies.Cleaner);
            StaffWorker StaffWorker6 = new StaffWorker("Name6", "Six", 70, 50, 2100, AdministrationDuties.DepartmentHead, StaffVacancies.HeadOfClericalWorkers);
            StaffWorker StaffWorker7 = new StaffWorker("Name7", "Seven", 44, 8, 1200, AdministrationDuties.NoDuties, StaffVacancies.ClericalWorker);
            Specialty CS = new Specialty("ComputerSecurity");
            Specialty AI = new Specialty("AppliedInformatics");
            Specialty TS = new Specialty("Translation");
            Specialty IR = new Specialty("InternationalRight");
            AcademicSubject Programming = new AcademicSubject("Programming", "Desc1", true);
            AcademicSubject MCs = new AcademicSubject("Microcontrollers", "Desc2", true);
            AcademicSubject CT = new AcademicSubject("CloudTechnologies", "Desc3", false);
            AcademicSubject Linguistic = new AcademicSubject("Linguistic", "Desc4", true);
            AcademicSubject Culture = new AcademicSubject("Culture", "Desc5", true);
            AcademicSubject Translation = new AcademicSubject("Translation", "Desc6", true);
            CS.Add(Programming);
            CS.Add(MCs);
            AI.Add(Programming);
            AI.Add(CT);
            TS.Add(Linguistic);
            TS.Add(Culture);
            IR.Add(Culture);
            IR.Add(Translation);
            Student1.Add(CS);
            Student3.Add(CS);
            Student4.Add(CS);
            Student5.Add(CS);
            Student2.Add(AI);
            Student6.Add(AI);
            Student7.Add(AI);
            Student8.Add(AI);
            Student9.Add(TS);
            Student10.Add(TS);
            Student11.Add(IR);
            SciWorker1.Add(Programming);
            SciWorker1.Add(CT);
            SciWorker2.Add(MCs);
            SciWorker3.Add(MCs);
            SciWorker3.Add(CT);
            SciWorker4.Add(Linguistic);
            SciWorker4.Add(Culture);
            SciWorker4.Add(Translation);
            SciWorker5.Add(Translation);
            SciWorker5.Add(Culture);
            SciWorker6.Add(Linguistic);
            List<Specialty> Specialties = new List<Specialty>() { CS, AI, TS, IR };
            List<AcademicSubject> Subjects = new List<AcademicSubject>() { Programming, MCs, CT, Linguistic, Culture, Translation};
            List<ScienceWorker> SciWorkers = new List<ScienceWorker>() { SciWorker1, SciWorker2, SciWorker3, SciWorker4, SciWorker5, SciWorker6, SciWorker7, SciWorker8 };
            List<StaffWorker> StaffWorkers = new List<StaffWorker>() { StaffWorker1, StaffWorker2, StaffWorker3, StaffWorker4, StaffWorker5, StaffWorker6, StaffWorker7}; 
            List<Student> Students = new List<Student>() { Student1, Student2, Student3, Student4, Student5, Student6, Student7, Student8, Student9, Student10, Student11 };
            Faculty RadiophysicsFaculty = new Faculty("Radiophysics faculty", SciWorker1);
            RadiophysicsFaculty.AddScienceWorkers(SciWorker1);
            RadiophysicsFaculty.AddScienceWorkers(SciWorker2);
            RadiophysicsFaculty.AddScienceWorkers(SciWorker3);
            RadiophysicsFaculty.AddScienceWorkers(SciWorker7);
            RadiophysicsFaculty.Add(CS);
            RadiophysicsFaculty.Add(AI);
            Faculty HumaintarianFaculty = new Faculty("Language faculty", SciWorker4);
            HumaintarianFaculty.AddScienceWorkers(SciWorker4);
            HumaintarianFaculty.AddScienceWorkers(SciWorker5);
            HumaintarianFaculty.AddScienceWorkers(SciWorker6);
            HumaintarianFaculty.AddScienceWorkers(SciWorker8);
            HumaintarianFaculty.Add(TS);
            HumaintarianFaculty.Add(IR);
            Administration AdministrativeDepartment = new Administration(SciWorker5, 45000);
            AdministrativeDepartment.AddScienceWorkers(SciWorker5);
            AdministrativeDepartment.AddScienceWorkers(SciWorker6);
            InventoryControl<MaintenanceEquipmentTypes> inventory1 = new InventoryControl<MaintenanceEquipmentTypes>(5, MaintenanceEquipmentTypes.Mop);
            InventoryControl<MaintenanceEquipmentTypes> inventory2 = new InventoryControl<MaintenanceEquipmentTypes>(7, MaintenanceEquipmentTypes.Rag);
            MaintenanceDepartment Maintenance = new MaintenanceDepartment(StaffWorker6);
            Maintenance.Add(inventory1);
            Maintenance.Add(inventory2);
            Maintenance.AddStaffWorkers(StaffWorker6);
            Maintenance.AddStaffWorkers(StaffWorker7);
            Maintenance.AddStaffWorkers(StaffWorker5);
            InventoryControl<SecurityEquipmentTypes> inventory3 = new InventoryControl<SecurityEquipmentTypes>(5, SecurityEquipmentTypes.PepperSpray);
            InventoryControl<SecurityEquipmentTypes> inventory4 = new InventoryControl<SecurityEquipmentTypes>(10, SecurityEquipmentTypes.MetalDetector);
            Security SecurityDepartment = new Security(StaffWorker3);
            SecurityDepartment.Add(inventory3);
            SecurityDepartment.Add(inventory4);
            SecurityDepartment.AddStaffWorkers(StaffWorker3);
            SecurityDepartment.AddStaffWorkers(StaffWorker4);
            ResearchDepartment Research = new ResearchDepartment(SciWorker5, new List<string>() { "publication1", "publication2", "publication3"});
            Research.AddScienceWorkers(SciWorker5);
            Research.AddScienceWorkers(SciWorker6);
            Research.AddScienceWorkers(SciWorker4);
            Research.AddScienceWorkers(SciWorker1);
            Research.AddStaffWorkers(StaffWorker1);
            Research.AddStaffWorkers(StaffWorker2);
            OxfordUniversity.AddDepartment(RadiophysicsFaculty);
            OxfordUniversity.AddDepartment(HumaintarianFaculty);
            OxfordUniversity.AddDepartment(AdministrativeDepartment);
            OxfordUniversity.AddDepartment(SecurityDepartment);
            OxfordUniversity.AddDepartment(Maintenance);
            OxfordUniversity.AddDepartment(Research);
            OxfordUniversity.Students = Students;
            OxfordUniversity.StaffWorkers = StaffWorkers;
            OxfordUniversity.ScienceWorkers = SciWorkers;
            OxfordUniversity.Subjects = Subjects;
            OxfordUniversity.Specialties = Specialties;
            OxfordUniversity.Serialize();
            University newUniversity = new University();
            newUniversity.Deserealize();
            var test1 = newUniversity.ScienceWorkers.Where(x => x.ScienceDegree == ScienceDegrees.Professor && x.LecturedSubjects.Count >= 1).ToList();
            var test2 = newUniversity.Students.Where(x => x.Specialties.Contains(AI)).ToList();
            var test3 = newUniversity.Students.Where(x => x.Specialties.Intersect(x.Specialties.Where(x => x.Subjects.Contains(CT))).Count() == 1).ToList();
            var test4 = newUniversity.GetDoubledSubjects();
            var test5 = newUniversity.ScienceWorkers.Where(x => x.ScienceDegree == ScienceDegrees.Professor || x.ScienceDegree == ScienceDegrees.Docent).ToList().Count;
            var test6 = newUniversity.Subjects;
            var test7 = newUniversity.StaffWorkers.Count + newUniversity.ScienceWorkers.Count;
            var test8 = newUniversity.Departments.Where(x => x.GetType() == typeof(Faculty)).Where(x => (x as Faculty).Name == "Radiophysics faculty").Select(x => (x.ScienceWorkers.Where(x => x.ScienceDegree == ScienceDegrees.Docent), x.ScienceWorkers.Where(x => x.ScienceDegree == ScienceDegrees.Docent).Select(x => x.LecturedSubjects))).ToList();
        }
    }
}
