using HW7.Entities;
using HW7.Entities.Education;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW7.Entities.People
{
    class ScienceWorker : Worker
    {
        public ScienceDegrees ScienceDegree { get; set; }
        public int DiplomaProtectionYear { get; set; }
        public string DiplomaTheme { get; set; }
        public List<AcademicSubject> LecturedSubjects { get; set; }
        public ScienceWorker(string name, string surname, int age, int experience, double loan, AdministrationDuties administrationDuty, ScienceDegrees scienceDegree, int diplomaProtectionYear, string diplomaTheme, List<AcademicSubject> lecturedSubjects) : base(name, surname, age, experience, loan, administrationDuty)
        {
            ScienceDegree = scienceDegree;
            DiplomaProtectionYear = diplomaProtectionYear;
            DiplomaTheme = diplomaTheme;
            LecturedSubjects = lecturedSubjects;
        }

        public ScienceWorker(string name, string surname, int age, int experience, double loan, AdministrationDuties administrationDuty, ScienceDegrees scienceDegree, int diplomaProtectionYear, string diplomaTheme) : base(name, surname, age, experience, loan, administrationDuty)
        {
            ScienceDegree = scienceDegree;
            DiplomaProtectionYear = diplomaProtectionYear;
            DiplomaTheme = diplomaTheme;
            LecturedSubjects = new List<AcademicSubject>();
        }
        
        public void Add(AcademicSubject subject)
        {
            LecturedSubjects.Add(subject);
        }
    }
}
