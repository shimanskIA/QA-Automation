using System;
using System.Collections.Generic;
using System.Text;

namespace HW7.Entities.People
{
    abstract class Worker : Person
    {
        public int Experience { get; set; }
        public double Loan { get; set; }
        public AdministrationDuties AdministrationDuty { get; set; }
        public Worker(string name, string surname, int age, int experience, double loan, AdministrationDuties administrationDuty) : base(name, surname, age)
        {
            Experience = experience;
            Loan = loan;
            AdministrationDuty = administrationDuty;
        }
    }
}
